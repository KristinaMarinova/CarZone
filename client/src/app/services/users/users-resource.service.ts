import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLoginModel } from '../../models/userLoginModel';
import { UserModel } from '../../models/userModel';

@Injectable({
  providedIn: 'root'
})
export class UsersResource {
  constructor(private http: HttpClient) { }

  getUserById(id: number): Observable<any> {
    return this.http.get(`api/Users/${id}`);
  }

  createUser(user: UserModel): Observable<any> {
    return this.http.post('api/Users', user);
  }

  loginUser(user: UserLoginModel): Observable<any> {
    return this.http.post('api/Users/login', user);
  }

  logout(cookie: string): any {
    this.http.post('api/Users/logout', cookie);
  }
}
