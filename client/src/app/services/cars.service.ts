import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarModel } from '../models/carModel';
import { FilterModel } from './filter.service';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  constructor(
    private http: HttpClient,
  ) { }

  getAll(): Observable<any> {
    return this.http.get('api/Cars');
  }

  get(id: number): Observable<any> {
    return this.http.get(`api/Cars/${id}`);
  }

  addCar(car: CarModel): Observable<any> {
    return this.http.post('api/Cars', car);
  }

  deleteCar(carId: number): Observable<any> {
    return this.http.delete(`api/Cars/${carId}`);
  }

  search(filterModel: FilterModel): Observable<any> {
    const params = { ...filterModel };
    return this.http.get<any>('api/Cars/search', { params });
  }

  editInfo(id: number, car: any): Observable<any> {
    return this.http.put(`api/Cars/${id}`, car);
  }
}