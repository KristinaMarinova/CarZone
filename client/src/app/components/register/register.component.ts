import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/userModel';
import { UsersResource } from 'src/app/services/users-resource.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  userModel = new UserModel();

  constructor(
    private userResource: UsersResource,
    private userService: UsersService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
  }

  createUser() {
    this.userResource.createUser(this.userModel)
      .subscribe((data) => {
        this.userService.login(data.token, data.userId);
        this.router.navigate(['cars']);
        this.userModel = new UserModel();
      });
  }
}
