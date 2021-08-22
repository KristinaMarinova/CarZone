import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserProfileModel } from 'src/app/models/UserProfileModel';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  profilePic: File | null = null;

  user = new UserProfileModel();
  hideDiv: boolean = false;
  userId = +localStorage.getItem('userId');

  constructor(
    private route: ActivatedRoute,
    private userService: UsersService,
    private toastrService: ToastrService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => this.user = data.user);
  }

  editInfo(): void {
    this.userService.editInfo(this.userId, this.user)
      .subscribe();
    this.hideDiv = true;
  }
}
