import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(
    private userService: UsersService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
  }

  logoutUser() {
    this.userService.logout();
    this.router.navigate(['home']);
  }


}
