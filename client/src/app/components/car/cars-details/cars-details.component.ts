import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarModel } from 'src/app/models/carModel';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-cars-details',
  templateUrl: './cars-details.component.html',
  styleUrls: ['./cars-details.component.css']
})
export class CarsDetailsComponent implements OnInit {
  currentCar = new CarModel();
  userId: number = +localStorage.getItem('userId');
  canEdit: boolean = false;
  likesCount: number;

  constructor(
    private route: ActivatedRoute,
    private userService: UsersService,
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => {
        this.currentCar = data.car;
      });
    this.canEditPost();
    this.likesCount = this.currentCar.likesCount;
  }

  canEditPost(): void {
    this.canEdit = this.userService.canEdit(this.userId, this.currentCar.userId);
  }
}