import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserProfileModel } from 'src/app/models/UserProfileModel';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  user = new UserProfileModel();
  hideDiv: boolean = false;
  userId = +localStorage.getItem('userId');



  constructor(
    private route: ActivatedRoute,
    private userService: UsersService
  ) { }

  ngOnInit(): void {
    this.getUserInfo();
  }

  getUserInfo(): void {
    this.userService.getById(this.userId)
      .subscribe((data: any) => this.user = data);
  }

  editInfo(): void {
    this.userService.editInfo(this.userId, this.user)
      .subscribe();
    this.hideDiv = true;
  }
}
