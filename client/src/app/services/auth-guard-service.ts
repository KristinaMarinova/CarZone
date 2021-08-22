import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { UsersService } from './users/users.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuardService implements CanActivate {

  constructor(private router: Router, private authService: UsersService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree {

    const expectedRole = route.data.expectedRole;
    const userRole = localStorage.getItem('role');

    if (!this.authService.isLogged()) {
      this.router.navigate(["home"], { queryParams: { retUrl: route.url } });
      return false;
    }

    if (expectedRole != null) {
      if (userRole == expectedRole) {
        return true;
      }
      this.router.navigate(["home"], { queryParams: { retUrl: route.url } });
      return false;
    }

    return true;
  }

}
