import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CarsListComponent } from './components/cars-list/cars-list.component';
import { CarsDetailsComponent } from './components/cars-details/cars-details.component';
import { AddCarComponent } from './components/add-car/add-car.component';
import { HomeComponent } from './components/home/home.component';
import { AsyncSelectComponent } from './components/async-select/async-select.component';

import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { UserProfileComponent } from './components/user/user-profile/user-profile.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from '../infrastructure/interceptors/token-interceptor.service';
import { FilterCarsComponent } from './components/filter-cars/filter-cars.component';
import { CarLikesComponent } from './components/car-likes/car-likes.component';
import { CommentComponent } from './components/comment/comment.component';
import { CarFeaturesComponent } from './components/car-features/car-features.component';
import { EditCarBtnComponent } from './components/edit-car-btn/edit-car-btn.component';
import { DeleteCarBtnComponent } from './components/delete-car-btn/delete-car-btn.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';
import { CommentPreviewComponent } from './components/comment-preview/comment-preview.component';
import { PartsHistoryTableComponent } from './components/parts-history-table/parts-history-table.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LikedCarsBtnComponent } from './components/liked-cars-btn/liked-cars-btn.component';
import { NewCarsComponent } from './components/new-cars/new-cars.component';
import { ErrorInterceptor } from 'src/infrastructure/interceptors/error.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    CarsListComponent,
    CarsDetailsComponent,
    CarLikesComponent,
    AddCarComponent,
    AsyncSelectComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    NotFoundComponent,
    UserProfileComponent,
    FilterCarsComponent,
    CommentComponent,
    CarFeaturesComponent,
    EditCarBtnComponent,
    DeleteCarBtnComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    CommentPreviewComponent,
    PartsHistoryTableComponent,
    LikedCarsBtnComponent,
    NewCarsComponent,
  ],
  imports: [
    NgbModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
    }),
    TranslateModule.forRoot({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}