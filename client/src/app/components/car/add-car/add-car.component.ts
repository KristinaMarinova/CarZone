import { Component, OnInit } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { Router } from '@angular/router';
import { PartDescriptionModel } from 'src/app/models/partDescriptionModel';
import { CarDetailService } from 'src/app/services/cars/car-detail.service';
import { CarsService } from 'src/app/services/cars/cars.service';
import { CarPictureModel } from 'src/app/models/car-picture-model';
import { CarPicturesService } from 'src/app/services/cars/car-pictures-service';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit {

  carModel = new CarModel();
  partsArr: PartDescriptionModel[] = [];
  picsArr: CarPictureModel[] = [];

  constructor(private carService: CarsService,
    private carDetaiService: CarDetailService,
    private carPicService: CarPicturesService,
    private router: Router) { }

  ngOnInit(): void {
    this.carModel.userId = +localStorage.getItem('userId');
  }

  addCar() {
    this.carModel.model.trim();

    this.carService.addCar(this.carModel)
      .subscribe((data) => {
        this.router.navigate(['cars', data.id]);
        this.carModel.id = data.id;
        this.carDetaiService
          .addDetails(this.carModel.id, this.partsArr)
          .subscribe();
        this.carPicService
          .addPictures(this.carModel.id, this.picsArr)
          .subscribe();
      });
  }

  addRow(type: string) {
    if (type == 'part') {
      const partItem = new PartDescriptionModel();
      this.partsArr.push(partItem);
    }
    else {
      const picItem = new CarPictureModel();
      this.picsArr.push(picItem);
    }
  }

  deleteRow(index: number, type: string) {
    if (type == 'part') {
      this.partsArr.splice(index, 1);
    }
    else {
      this.picsArr.splice(index, 1);
    }
  }

}
