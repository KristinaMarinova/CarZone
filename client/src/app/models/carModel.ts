import { CarPictureModel } from "./car-picture-model";

export class CarModel {
    id: number;
    brand: any;
    brandId: number;
    model: string;
    price: number;
    km: number;
    transmission: any;
    transmissionId: number;
    color: any;
    colorId: number;
    fuel: any;
    fuelId: number;
    horsepower: number;
    likesCount: number;
    year: number;
    viewCount: number;
    userId: number;
    pictures: CarPictureModel[];
}