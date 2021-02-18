import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  loggedIn: boolean = false;

  constructor(
    private userService: UsersService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.loggedIn = this.userService.isLogged();

    this.userService.loginChanged
      .subscribe((isLogged: boolean) => this.loggedIn = isLogged);

  }

  logoutUser() {
    this.userService.logout();
    this.router.navigate(['home']);
  }

  isLogged() {
    this.loggedIn = this.userService.isLogged();
  }
}