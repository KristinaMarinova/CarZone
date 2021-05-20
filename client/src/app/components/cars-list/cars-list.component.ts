import { Component, OnInit } from '@angular/core';
import { FilterModel } from 'src/app/services/filter.service';
import { CarsService } from 'src/app/services/cars.service'
import { CarModel } from 'src/app/models/carModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cars-list',
  templateUrl: './cars-list.component.html',
  styleUrls: ['./cars-list.component.css']
})
export class CarsListComponent implements OnInit {

  cars: CarModel[] = [];
  pageSize = 9;
  page = 1;

  constructor(
    private carService: CarsService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => this.cars = data.cars);
  }

  search(filter?: FilterModel): void {
    this.carService.search(filter)
      .subscribe((cars: any[]) => this.cars = cars);
  }
}