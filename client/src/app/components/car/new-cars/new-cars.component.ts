import { Component, OnInit } from '@angular/core';
import { NewCarModel } from 'src/app/models/newCarModel';
import { CarsService } from 'src/app/services/cars/cars.service';

@Component({
  selector: 'app-new-cars',
  templateUrl: './new-cars.component.html',
})
export class NewCarsComponent implements OnInit {
  cars: NewCarModel[];

  constructor(private carService: CarsService) { }

  ngOnInit(): void {
    this.carService.getNewCars()
      .subscribe(data => this.cars = data);
  }

  getById(link: string) {
    this.carService.getNewCarById(link)
      .subscribe();
  }

}
