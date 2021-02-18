import { Component, OnInit } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { CarsService } from 'src/app/services/cars.service';
import { Router } from '@angular/router';
import { PartDescriptionModel } from 'src/app/models/partDescriptionModel';
import { CarDetailService } from 'src/app/services/car-detail.service';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit {

  carModel = new CarModel();

  arr: PartDescriptionModel[] = [];

  constructor(private carService: CarsService,
    private carDetaiService: CarDetailService,
    private router: Router) { }

  ngOnInit(): void {
    this.carModel.userId = +localStorage.getItem('userId');
  }

  addCar() {
    this.carModel.model.trim();
    this.carModel.carPic.trim();

    this.carService.addCar(this.carModel)
      .subscribe((data) => {
        this.router.navigate(['cars', data.id]);
        this.carModel.id = data.id;
        this.carDetaiService.addDetails(this.carModel.id, this.arr).subscribe();
      });


  }

  addRow() {
    const newItem = new PartDescriptionModel();
    this.arr.push(newItem);
  }

  deleteRow(index: number) {
    this.arr.splice(index, 1);
  }

}
