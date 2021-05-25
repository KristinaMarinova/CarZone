import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
    providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {

    constructor(
        private toastrService: ToastrService,
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req)
            .pipe(catchError((error: HttpErrorResponse) => {
                if (error) {
                    switch (error.status) {
                        case 400:
                            if (error.error.errors) {
                                const modalStateErrors = [];
                                for (const key in error.error.errors) {
                                    if (error.error.errors[key]) {
                                        modalStateErrors.push(error.error.errors[key]);
                                    }
                                }
                                throw modalStateErrors.map(e => e);
                            } else {
                                this.toastrService.error(error.error);
                            }
                        case 401:
                            this.toastrService.error(error.statusText, error.status.toString());
                            break;
                        case 500:
                            this.toastrService.error(error.error.message);
                            break;
                        case 504:
                            this.toastrService.error(error.error);
                            break;
                        default:
                            this.toastrService.error('Something unexpected went wrong');
                            break;
                    }
                }
                return throwError(error.error);
            }))
    }
}
