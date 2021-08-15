import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserLoginModel } from 'src/app/models/userLoginModel';
import { UsersResource } from 'src/app/services/users/users-resource.service';
import { UsersService } from 'src/app/services/users/users.service';

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
    private router: Router,
    private toastrService: ToastrService,
  ) {
  }

  ngOnInit(): void {
  }

  loginUser() {
    this.userResource.loginUser(this.userLoginModel)
      .subscribe(
        (data) => {
          this.userService.login(data.token, data.userId);
          this.toastrService.success("Login success");
          this.router.navigate(['cars']);
        }
      );
  }
}
