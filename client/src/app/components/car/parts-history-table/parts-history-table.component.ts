import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PartDescriptionModel } from 'src/app/models/partDescriptionModel';
import { CarDetailService } from 'src/app/services/cars/car-detail.service';

@Component({
  selector: 'parts-history-table',
  templateUrl: './parts-history-table.component.html',
})
export class PartsHistoryTableComponent implements OnInit {

  partsDetails: PartDescriptionModel[];
  @Input() currentCar: any;
  @Input() canEdit: any;

  constructor(
    private carDetaiService: CarDetailService,
    private toastrService: ToastrService,
  ) {
  }

  ngOnInit(): void {
    this.carDetaiService
      .getPartsHistory(this.currentCar.id)
      .subscribe(data => this.partsDetails = data);
  }

  update() {
    this.carDetaiService
      .updateDetail(this.currentCar.id, this.partsDetails)
      .subscribe(() => this.toastrService.success("Successfully updated."));
  }

  addRow() {
    const newItem = new PartDescriptionModel();
    this.partsDetails.push(newItem);
  }

  delete(index: number) {
    this.partsDetails.splice(index, 1);
  }

}
