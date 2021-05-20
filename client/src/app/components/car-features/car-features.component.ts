import { Component, Input, OnInit } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { UserModel } from 'src/app/models/userModel';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-car-features',
  templateUrl: './car-features.component.html',
  styleUrls: ['./car-features.component.css']
})
export class CarFeaturesComponent implements OnInit {
  @Input() car: CarModel;
  sellerInfo = new UserModel();

  constructor(private userService: UsersService) { }
  ngOnInit(): void {
    this.userService.getById(this.car.userId)
      .subscribe(data => this.sellerInfo = data);
  }
}