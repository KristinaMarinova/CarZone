import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { EMPTY, Observable } from "rxjs";
import { CarsService } from "../cars.service";

@Injectable({
    providedIn: 'root'
})
export class CarByIdResolver implements Resolve<any> {
    constructor(
        private resource: CarsService
    ) { }

    resolve(
        route: ActivatedRouteSnapshot,
        _: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        const id = +route.params['id'];

        if (isNaN(id)) {
            return EMPTY;
        }
        return this.resource.get(id);
    }
}