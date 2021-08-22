import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs';
import jwt_decode from 'jwt-decode';
import { JwtHelperService } from "@auth0/angular-jwt";
import { Router } from '@angular/router';
import { Role } from 'src/app/models/enums/role';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(
    private http: HttpClient,
    private router: Router,
    public jwtHelper: JwtHelperService
  ) {

    this.isUserAdmin();
  }

  private readonly token_property = 'access_token';
  loginChanged: Subject<boolean> = new Subject();
  isAdmin: boolean;

  login(token: string, userId: string, role: string, username: string): void {
    localStorage.setItem(this.token_property, token);
    localStorage.setItem('userId', userId);
    localStorage.setItem('role', role);
    localStorage.setItem('username', username);
    this.loginChanged.next(true);
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['home']);
    this.loginChanged.next(false);
  }

  isLogged(): boolean {
    const token = localStorage.getItem(this.token_property);

    if (this.jwtHelper.isTokenExpired(token)) {
      this.logout();
      this
    }

    return token && token.length > 0;
  }

  isUserAdmin() {
    let role = JSON.parse(localStorage.getItem('role'));

    if (Role[role] == 'Admin') {
      this.isAdmin = true;
    }
    else {
      this.isAdmin = false;
    }
  }

  getById(id: number): Observable<any> {
    return this.http.get(`api/Users/${id}`);
  }

  getUserId(): number {
    var decodedToken = this.getDecodedAccessToken(this.getToken());
    return decodedToken['nameid'];
  }

  canEdit(userId: number, carCreatorId: number): boolean {
    if (userId == carCreatorId) {
      return true;
    }
    return false;
  }

  editInfo(id: number, user: any): Observable<any> {
    return this.http.put(`api/Users/${id}`, user);
  }

  uploadFile(formData): Observable<any> {
    return this.http.post('api/Users/UploadFileAsync', formData, { reportProgress: true, observe: 'events' });
  }

  public getToken(): string {
    return localStorage.getItem('access_token');
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    }
    catch (Error) {
      return null;
    }
  }
}
