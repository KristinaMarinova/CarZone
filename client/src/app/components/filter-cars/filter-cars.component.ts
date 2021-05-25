import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FilterModel, FilterObjectsModel } from 'src/app/services/filter.service';

@Component({
  selector: 'app-filter-cars',
  templateUrl: './filter-cars.component.html',
  styleUrls: ['./filter-cars.component.css']
})
export class FilterCarsComponent {

  constructor(
    public filterModel: FilterModel,
    public filterObjectsModel: FilterObjectsModel,
  ) { }

  @Output() searchClicked: EventEmitter<FilterModel> = new EventEmitter();

  search(): void {
    this.searchClicked.emit(this.filterModel);
  }

  clear(): void {
    this.filterModel = new FilterModel();
    this.filterObjectsModel = new FilterObjectsModel();
    this.searchClicked.emit(this.filterModel);
  }
}
