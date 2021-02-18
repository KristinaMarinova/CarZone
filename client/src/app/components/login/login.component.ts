import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserLoginModel } from 'src/app/models/userLoginModel';
import { UsersResource } from 'src/app/services/users-resource.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userLoginModel = new UserLoginModel();

  constructor(
    private userService: UsersService,
    private userResource: UsersResource,
    private router: Router
  ) {
  }

  ngOnInit(): void {
  }

  loginUser() {
    this.userResource.loginUser(this.userLoginModel)
      .subscribe((data) => {
        this.userService.login(data.token, data.userId);
        this.router.navigate(['cars']);
      });
  }
}
