import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { PartDescriptionModel } from 'src/app/models/partDescriptionModel';
import { CarDetailService } from 'src/app/services/car-detail.service';

@Component({
  selector: 'parts-history-table',
  templateUrl: './parts-history-table.component.html',
  styleUrls: ['./parts-history-table.component.css']
})
export class PartsHistoryTableComponent implements OnInit {

  @Input() historyDetails: PartDescriptionModel[];
  @Input() currentCar: any;
  @Input() canEdit: any;

  constructor(private carDetaiService: CarDetailService) { }

  ngOnInit(): void {
  }

  update() {
    this.carDetaiService.updateDetail(this.currentCar.id, this.historyDetails).subscribe();
  }

  addRow() {
    const newItem = new PartDescriptionModel();
    this.historyDetails.push(newItem);
  }

  delete(index: number) {
    this.historyDetails.splice(index, 1);
  }

}
