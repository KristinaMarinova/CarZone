import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CarPictureModel } from "src/app/models/car-picture-model";

@Injectable({
    providedIn: 'root'
})
export class CarPicturesService {

    constructor(private http: HttpClient) { }

    getCarPictures(carId: number): Observable<any> {
        return this.http.get(`api/Cars/${carId}/pics`);
    }

    addPictures(carId: number, pics: CarPictureModel[]): Observable<any> {
        return this.http.post(`api/Cars/${carId}/pics`, pics);
    }

    updatePictures(carId: number, pics: CarPictureModel[]): Observable<any> {
        return this.http.put(`api/Cars/${carId}/pics`, pics)
    }
}
