import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarModel } from 'src/app/models/carModel';
import { CarsService } from 'src/app/services/cars/cars.service';
import { FilterModel } from 'src/app/services/filter.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

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
