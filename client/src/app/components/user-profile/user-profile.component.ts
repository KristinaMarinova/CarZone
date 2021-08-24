import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserProfileModel } from 'src/app/models/UserProfileModel';
import { UsersResource } from 'src/app/services/users/users-resource.service';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  profilePic: File | null = null;
  user: UserProfileModel = new UserProfileModel();
  hideDiv: boolean = false;
  userId = +localStorage.getItem('userId');

  constructor(
    private route: ActivatedRoute,
    private resource: UsersResource,
  ) { }

  ngOnInit(): void {

    this.route.data
      .subscribe((result: any) => this.user = result.user);
  }

  editInfo(): void {
    this.resource.editInfo(this.userId, this.user)
      .subscribe();
    this.hideDiv = true;
  }
}
