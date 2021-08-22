import { Component, Input } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { CarLikesService } from 'src/app/services/cars/car-likes.service';

@Component({
    selector: 'car-likes-btn',
    templateUrl: 'car-likes.component.html'
})

export class CarLikesComponent {
    @Input() car: CarModel;
    @Input() disabled: boolean;

    constructor(
        private carLikesService: CarLikesService,
    ) { }

    addLike(): void {
        this.carLikesService.addLike(this.car.id)
            .subscribe((data: any) => this.car.likesCount = data);
    }

    // getLikes(): void {
    //     this.carLikesService.getLikes(this.car.id)
    //         .subscribe((data: any) => this.car.likesCount = data);
    // }
}