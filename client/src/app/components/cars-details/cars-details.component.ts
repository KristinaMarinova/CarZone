import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarModel } from 'src/app/models/carModel';
import { PartDescriptionModel } from 'src/app/models/partDescriptionModel';
import { CarDetailService } from 'src/app/services/car-detail.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-cars-details',
  templateUrl: './cars-details.component.html',
  styleUrls: ['./cars-details.component.css']
})
export class CarsDetailsComponent implements OnInit {
  currentCar = new CarModel();
  historyDetails: PartDescriptionModel[] = [];

  userId: number = +localStorage.getItem('userId');
  canEdit: boolean = false;
  likesCount: number;


  constructor(
    private route: ActivatedRoute,
    private userService: UsersService,
    private carDetaiService: CarDetailService
  ) { }

  ngOnInit(): void {
    this.route.data.subscribe((data: any) => this.currentCar = data.car);
    this.carDetaiService.getDetails(this.currentCar.id)
      .subscribe((data: any) => this.historyDetails = data);
    this.likesCount = this.currentCar.likesCount;

    this.canEditPost();
  }

  canEditPost(): void {
    this.canEdit = this.userService.canEdit(this.userId, this.currentCar.userId);
  }
}