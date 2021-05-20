import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { CarsService } from "../cars.service";

@Injectable({
    providedIn: 'root'
})
export class CarsResolver implements Resolve<any> {
    constructor(
        private resource: CarsService
    ) { }

    resolve(
        route: ActivatedRouteSnapshot,
        _: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        return this.resource.getAll();
    }
}