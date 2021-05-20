import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarsListComponent } from './components/cars-list/cars-list.component';
import { CarsDetailsComponent } from './components/cars-details/cars-details.component';
import { AddCarComponent } from './components/add-car/add-car.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { UserProfileComponent } from './components/user/user-profile/user-profile.component';
import { AuthGuardService } from './services/auth-guard-service';
import { NewCarsComponent } from './components/new-cars/new-cars.component';
import { CarsResolver } from './services/resolvers/cars.resolver';
import { UserResolver } from './services/resolvers/user-resolver';
import { CarByIdResolver } from './services/resolvers/carById.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '/', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'cars', component: CarsListComponent, resolve: { cars: CarsResolver } },
  { path: 'newCars', component: NewCarsComponent },
  { path: 'cars/:id', component: CarsDetailsComponent, resolve: { car: CarByIdResolver }, canActivate: [AuthGuardService] },
  { path: 'add', component: AddCarComponent, canActivate: [AuthGuardService] },
  { path: 'profile', component: UserProfileComponent, resolve: { user: UserResolver }, canActivate: [AuthGuardService] },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }