import { Component, Input, OnInit } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { CarsService } from 'src/app/services/cars.service';

@Component({
  selector: 'edit-car-btn',
  templateUrl: './edit-car-btn.component.html',
  styleUrls: ['./edit-car-btn.component.css']
})
export class EditCarBtnComponent implements OnInit {

  @Input() currentCar: CarModel;
  hideDiv: boolean = false;

  constructor(private carService: CarsService) { }

  ngOnInit(): void {
  }

  editInfo(): void {
    this.carService.editInfo(this.currentCar.id, this.currentCar)
      .subscribe();
    this.hideDiv = true;
  }

}
