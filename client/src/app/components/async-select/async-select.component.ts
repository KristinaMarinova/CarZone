import { HttpClient } from '@angular/common/http';
import { Component, ContentChild, ElementRef, EventEmitter, Input, OnDestroy, OnInit, Output, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { NgbDropdown } from '@ng-bootstrap/ng-bootstrap';
import { merge, of, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-async-select',
  templateUrl: './async-select.component.html',
  styleUrls: ['./async-select.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: AsyncSelectComponent,
      multi: true
    }
  ]
})
export class AsyncSelectComponent<T extends { name: string }> implements OnInit, OnDestroy {
  @Input() restUrl: string;
  @Input() placeholder: string;

  @Input() disabled: boolean;

  @Input() required: boolean;

  @Output() modelChange: EventEmitter<T> = new EventEmitter<T>();

  @ContentChild('dropdownItemTemplate', { static: true }) dropdownItemTemplate: TemplateRef<ElementRef>;
  @ContentChild('selectedItemTemplate', { static: true }) selectedItemTemplate: TemplateRef<ElementRef>;

  @ViewChild('dropdown', { static: true }) dropdown: NgbDropdown;
  @ViewChild('dropdownMenu', { static: true }) dropdownMenu: ElementRef;

  constructor(
    private http: HttpClient
  ) { }

  collection: T[] = [];
  selectedItem: T | null;
  displayValue: string = null;
  searchControl = new FormControl('');
  isOpen = false;
  isLoading = false;
  formControlChangeHandler: any;

  private searchSubscription: Subscription;
  private loadMore$ = new EventEmitter<boolean>();
  private limit = 25;
  private offset = 0;

  search$ = merge(
    this.searchControl.valueChanges.pipe(
      distinctUntilChanged()
    ),
    this.loadMore$,
  ).pipe(
    debounceTime(700),
    switchMap(value => {
      const filter: { textFilter?: string, limit?: number, offset?: number } = {};
      filter.textFilter = value === 'boolean' ? null : value;
      filter.limit = this.limit;
      filter.offset = typeof value === 'boolean' ? this.offset : 0;
      return of(filter);
    })
  );

  ngOnInit(): void {
    this.dropdown.openChange
      .subscribe((isOpen: boolean) => {
        if (this.disabled) {
          return;
        }

        this.isOpen = isOpen;
        this.searchControl.setValue('');
        if (this.isOpen) {
          this.getFiltered();
        }
      });

    this.searchSubscription = this.search$.subscribe(filter => this.getFiltered(filter));
  }

  ngOnDestroy(): void {
    if (!this.searchSubscription.closed) {
      this.searchSubscription.unsubscribe();
    }
  }

  registerOnChange(fn: any): void {
    this.formControlChangeHandler = fn;
  }

  registerOnTouched(fn: any): void { }

  writeValue(item: T): void {
    this.selectedItem = item;
    this.displayValue = this.getDisplayValue(item);
  }

  handleScroll(event: WheelEvent): void {
    const isAtBottom = this.isAtBottom(event, this.dropdownMenu.nativeElement);
    if (isAtBottom) {
      event.preventDefault();

      this.offset = this.collection.length;
      this.loadMore$.emit(true);
    }
  }

  clear(event: Event): void {
    event.preventDefault();
    event.stopPropagation();

    this.selectItem(null);
  }

  selectItem(item: T): void {
    this.selectedItem = item;
    this.displayValue = this.getDisplayValue(item);
    this.modelChange.emit(item);

    if (this.formControlChangeHandler) {
      this.formControlChangeHandler(item);
    }
  }

  private getFiltered(filter?: { textFilter?: string, limit?: number, offset?: number }): void {
    if (!filter) {
      filter = {};
      filter.textFilter = '';
      filter.limit = this.limit;
      filter.offset = 0;
    }

    this.isLoading = true;
    this.http
      .get<T[]>(`${this.restUrl}?textFilter=${filter.textFilter}&limit=${filter.limit}&offset=${filter.offset}`)
      .subscribe(items => {
        if (filter.offset === 0) {
          this.collection = items;
        }
        else {
          this.collection.push(...items);
        }

        this.isLoading = false;
      }, _ => this.isLoading = false);
  }

  private getDisplayValue(item: T | null): string | null {
    if (!item) {
      return null;
    }

    return item.name;
  }

  private isAtBottom(event: WheelEvent, target: HTMLElement): boolean {
    const atBottom = target.scrollHeight - Math.ceil(target.scrollTop) === target.clientHeight;

    return event.deltaY > 0 && atBottom;
  }

}
