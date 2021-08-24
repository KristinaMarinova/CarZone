import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
import { UsersResource } from '../users/users-resource.service';

@Injectable({
  providedIn: 'root'
})

export class UserResolver implements Resolve<any> {
  userId: number = +localStorage.getItem('userId');

  constructor(
    private resource: UsersResource
  ) { }

  resolve(
    route: ActivatedRouteSnapshot,
    _: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {

    if (isNaN(this.userId)) {
      return EMPTY;
    }

    return this.resource.getUserById(this.userId);
  }
}