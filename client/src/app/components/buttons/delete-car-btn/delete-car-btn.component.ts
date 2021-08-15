import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CarModel } from 'src/app/models/carModel';
import { CarsService } from 'src/app/services/cars/cars.service';

@Component({
  selector: 'delete-car-btn',
  templateUrl: './delete-car-btn.component.html',
  styleUrls: ['./delete-car-btn.component.css']
})
export class DeleteCarBtnComponent implements OnInit {
  @Input() currentCar: CarModel;

  constructor(
    private carService: CarsService,
    private router: Router,) { }

  ngOnInit(): void {
  }

  deleteCar(): void {
    this.carService.deleteCar(this.currentCar.id)
      .subscribe(() => {
        this.router.navigate(['cars']);
      });
  }
}
