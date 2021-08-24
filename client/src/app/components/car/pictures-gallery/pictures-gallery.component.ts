import { Component, Input, OnInit } from '@angular/core';
import { CarPictureModel } from 'src/app/models/car-picture-model';

@Component({
  selector: 'pictures-gallery',
  templateUrl: './pictures-gallery.component.html',
})
export class PicturesGalleryComponent {
  @Input() pics: CarPictureModel[];
}
