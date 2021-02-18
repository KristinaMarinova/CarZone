import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PartDescriptionModel } from '../models/partDescriptionModel';

@Injectable({
  providedIn: 'root'
})
export class CarDetailService {

  constructor(private http: HttpClient) { }

  addDetails(carId: number, details: PartDescriptionModel[]): Observable<any> {
    return this.http.post(`api/Cars/${carId}/description`, details);
  }

  getDetails(carId: number): Observable<any> {
    return this.http.get(`api/Cars/${carId}/description`)
  }

  updateDetail(carId: number, historyDetails: any): Observable<any> {
    return this.http.put(`api/Cars/${carId}/description`, historyDetails)
  }
}
