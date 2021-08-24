import { Component, Input, OnInit } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { UserModel } from 'src/app/models/userModel';
import { UsersResource } from 'src/app/services/users/users-resource.service';

@Component({
  selector: 'app-car-features',
  templateUrl: './car-features.component.html',
})

export class CarFeaturesComponent implements OnInit {
  @Input() car: CarModel;
  sellerInfo = new UserModel();

  constructor(private resource: UsersResource) {
  }

  ngOnInit(): void {
    this.resource.getUserById(this.car.userId)
      .subscribe(data => this.sellerInfo = data);
  }
}