import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from '../infrastructure/interceptors/token-interceptor.service';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ErrorInterceptor } from 'src/infrastructure/interceptors/error.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';
import { DeleteCarBtnComponent } from './components/buttons/delete-car-btn/delete-car-btn.component';
import { EditCarBtnComponent } from './components/buttons/edit-car-btn/edit-car-btn.component';
import { LikedCarsBtnComponent } from './components/buttons/liked-cars-btn/liked-cars-btn.component';
import { CarsListComponent } from './components/car/cars-list/cars-list.component';
import { CarsDetailsComponent } from './components/car/cars-details/cars-details.component';
import { CarLikesComponent } from './components/car/car-likes/car-likes.component';
import { AddCarComponent } from './components/car/add-car/add-car.component';
import { HomeComponent } from './components/shared/home/home.component';
import { FilterCarsComponent } from './components/car/filter-cars/filter-cars.component';
import { CommentComponent } from './components/comments/comment/comment.component';
import { CarFeaturesComponent } from './components/car/car-features/car-features.component';
import { LoginComponent } from './components/initial/login/login.component';
import { RegisterComponent } from './components/initial/register/register.component';
import { LogoutComponent } from './components/initial/login/logout/logout.component';
import { CommentPreviewComponent } from './components/comments/comment-preview/comment-preview.component';
import { PartsHistoryTableComponent } from './components/car/parts-history-table/parts-history-table.component';
import { NewCarsComponent } from './components/car/new-cars/new-cars.component';
import { AsyncSelectComponent } from './components/shared/async-select/async-select.component';
import { AdminComponent } from './components/admin/admin/admin.component';
import { UserResolver } from './services/resolvers/user-resolver';
import { CarPicturesCreateTableComponent } from './components/car/car-pictures-create-table/car-pictures-create-table.component';
import { PicturesGalleryComponent } from './components/car/pictures-gallery/pictures-gallery.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

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
    AdminComponent,
    CarPicturesCreateTableComponent,
    PicturesGalleryComponent,
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
    MDBBootstrapModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 5000,
    }),
    TranslateModule.forRoot({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem("access_token");
        }
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    [UserResolver],
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}