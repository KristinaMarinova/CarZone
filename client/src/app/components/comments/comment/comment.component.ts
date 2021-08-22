import { Component, Input, OnInit } from '@angular/core';
import { AddCommentModel } from 'src/app/models/addComentModel';
import { CommentModel } from 'src/app/models/comentModel';
import { CommentService } from 'src/app/services/cars/comment.service';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html'
})
export class CommentComponent implements OnInit {
  @Input() currentCar: any;
  comments: CommentModel[];
  commentToAdd: AddCommentModel;
  commentId: number;
  hideBtn: boolean = false;

  ngOnInit(): void {
    this.retriveCommens();
    this.commentToAdd = new AddCommentModel();
    this.commentToAdd.content = '';
  }

  constructor(
    private commentService: CommentService,
  ) { }

  retriveCommens(): void {
    this.commentService.getAll(this.currentCar.id)
      .subscribe((data: any) => this.comments = data);
  }

  addComment() {
    this.hideBtn = true;

    this.commentService.addComment(this.currentCar.id, this.commentToAdd.content)
      .subscribe(data => {
        this.comments.push(data);
        this.hideBtn = false;
        this.commentToAdd.content = '';
      });
  }

  deleteComment(commentId: number) {
    this.commentService.deleteComment(this.currentCar.id, commentId)
      .subscribe();

    this.comments = this.comments.filter(item => item.id !== commentId);
  }
}
