import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarLikesService {

  constructor(private http: HttpClient) { }

  addLike(carId: number): Observable<any> {
    return this.http.post(`api/Cars/${carId}/Likes`, null);
  }

  getLikes(carId: number): Observable<any> {
    return this.http.get(`api/Cars/${carId}/Likes`);
  }

  getUserLikedCars(): Observable<any> {
    return this.http.get(`api/Cars/Liked`);
  }

  removeLike(carId: number): Observable<any> {
    return this.http.delete(`api/Cars/${carId}/unlike`);
  }

}
