import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CarPictureModel } from 'src/app/models/car-picture-model';
import { CarPicturesService } from 'src/app/services/cars/car-pictures-service';

@Component({
  selector: 'car-pictures-create-table',
  templateUrl: './car-pictures-create-table.component.html',
})
export class CarPicturesCreateTableComponent implements OnInit {
  pics: CarPictureModel[];
  @Input() currentCar: any;

  constructor(
    private picService: CarPicturesService,
    private toastrService: ToastrService,
  ) {
  }

  ngOnInit(): void {
    this.picService
      .getCarPictures(this.currentCar.id)
      .subscribe(data => this.pics = data);

  }

  addRow() {
    const newItem = new CarPictureModel();
    this.pics.push(newItem);
  }

  delete(index: number) {
    this.pics.splice(index, 1);
  }

  update() {
    this.picService
      .updatePictures(this.currentCar.id, this.pics)
      .subscribe(() => {
        this.toastrService.success("Successfully updated.");
      });
  }

}
