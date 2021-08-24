import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs';
import jwt_decode from 'jwt-decode';
import { JwtHelperService } from "@auth0/angular-jwt";
import { Router } from '@angular/router';
import { Role } from 'src/app/models/enums/role';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(
    private http: HttpClient,
    private router: Router,
    public jwtHelper: JwtHelperService,
    private toastrService: ToastrService
  ) {
  }

  private readonly token_property = 'access_token';
  loginChanged: Subject<boolean> = new Subject();
  isAdmin: Subject<boolean> = new Subject();
  userId: number;

  login(token: string, userId: number, role: string, username: string): void {
    localStorage.setItem(this.token_property, token);
    localStorage.setItem('userId', userId.toString());
    localStorage.setItem('username', username);
    localStorage.setItem('role', Role[role]);
    this.userId = userId;
    this.isAdmin.next(this.isUserAdmin());
    this.loginChanged.next(true);
    this.toastrService.success('Login success');
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['home']);
    this.isAdmin.next(false);
    this.loginChanged.next(false);
  }

  isLogged(): boolean {
    const token = localStorage.getItem(this.token_property);

    if (this.jwtHelper.isTokenExpired(token)) {
      this.logout();
    }

    return token && token.length > 0;
  }

  isUserAdmin() {
    let role = localStorage.getItem('role');
    if (role == 'Admin') {
      this.isAdmin.next(true);
      return true;
    }
    else {
      this.isAdmin.next(false);
      return false;
    }
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
