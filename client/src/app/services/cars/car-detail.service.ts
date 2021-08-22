import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PartDescriptionModel } from '../../models/partDescriptionModel';

@Injectable({
  providedIn: 'root'
})
export class CarDetailService {

  constructor(private http: HttpClient) { }

  getPartsHistory(carId: number): Observable<any> {
    return this.http.get(`api/Cars/${carId}/part`);
  }

  addDetails(carId: number, details: PartDescriptionModel[]): Observable<any> {
    return this.http.post(`api/Cars/${carId}/part`, details);
  }

  updateDetail(carId: number, partsHistory: any): Observable<any> {
    return this.http.put(`api/Cars/${carId}/part`, partsHistory)
  }
}
