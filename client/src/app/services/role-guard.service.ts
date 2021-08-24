import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { UsersService } from './users/users.service';

@Injectable()
export class RoleGuardService implements CanActivate {

  constructor(private authService: UsersService, private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data.expectedRole;

    if (!this.authService.isLogged()) {

      this.router.navigate(["home"], { queryParams: { retUrl: route.url } });
      return false;
    }
    return true;
  }

}