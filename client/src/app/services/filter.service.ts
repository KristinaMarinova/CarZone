import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class FilterModel {
    brandId: any;
    fuelId: any;
    transmissionId: any;
    colorId: any;
    model: string;
}

@Injectable({
    providedIn: 'root'
})
export class FilterObjectsModel {
    brand: any;
    fuel: any;
    color: any;
    transmission: any;
    model: string;
}