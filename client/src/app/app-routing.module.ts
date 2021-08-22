import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { AuthGuardService } from './services/auth-guard-service';
import { CarsResolver } from './services/resolvers/cars.resolver';
import { UserResolver } from './services/resolvers/user-resolver';
import { CarByIdResolver } from './services/resolvers/carById.resolver';
import { HomeComponent } from './components/shared/home/home.component';
import { CarsListComponent } from './components/car/cars-list/cars-list.component';
import { NewCarsComponent } from './components/car/new-cars/new-cars.component';
import { CarsDetailsComponent } from './components/car/cars-details/cars-details.component';
import { AddCarComponent } from './components/car/add-car/add-car.component';
import { AdminComponent } from './components/admin/admin/admin.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '/', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'cars', component: CarsListComponent, resolve: { cars: CarsResolver } },
  { path: 'newCars', component: NewCarsComponent },
  { path: 'cars/:id', component: CarsDetailsComponent, resolve: { car: CarByIdResolver }, canActivate: [AuthGuardService] },
  { path: 'add', component: AddCarComponent, canActivate: [AuthGuardService] },
  { path: 'profile', component: UserProfileComponent, resolve: { user: UserResolver }, canActivate: [AuthGuardService] },
  { path: 'admin', component: AdminComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }