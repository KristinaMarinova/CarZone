import { Component, OnInit } from '@angular/core';
import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { CarModel } from 'src/app/models/carModel';
import { CarLikesService } from 'src/app/services/car-likes.service';

@Component({
  selector: 'liked-cars-btn',
  templateUrl: './liked-cars-btn.component.html',
  styleUrls: ['./liked-cars-btn.component.css']
})
export class LikedCarsBtnComponent implements OnInit {
  faHeart = faHeart;
  hideDiv: boolean = false;
  likedCars: CarModel[] = [];

  constructor(private carLikesService: CarLikesService) { }

  ngOnInit(): void {
    this.carLikesService.getUserLikedCars()
      .subscribe((data: any) => this.likedCars = data);
  }

  unlikeCar(car: CarModel) {
    this.likedCars.filter(cars => cars !== car);

    this.carLikesService.removeLike(car.id)
      .subscribe((data) => {
        car.likesCount == data;
      });
  }

  hide() {
    this.hideDiv = true;
  }
}