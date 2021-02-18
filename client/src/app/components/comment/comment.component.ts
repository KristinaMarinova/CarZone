import { Component, Input, OnInit } from '@angular/core';
import { AddCommentModel } from 'src/app/models/addComentModel';
import { CommentModel } from 'src/app/models/comentModel';
import { CommentService } from 'src/app/services/comment.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  @Input() currentCar: any;

  comments: CommentModel[];
  comentToAdd = new AddCommentModel();
  commentId: number;


  ngOnInit(): void {
    this.retriveCommens();
  }

  constructor(
    private commentService: CommentService,
  ) { }

  retriveCommens(): void {
    this.commentService.getAll(this.currentCar.id).subscribe((data: any) => this.comments = data);
  }

  addComment() {
    this.commentService.addComment(this.currentCar.id, this.comentToAdd).subscribe();
    this.retriveCommens();
    this.comentToAdd.content = '';
  }

  deleteComment(commentId: number) {
    this.commentService.deleteComment(this.currentCar.id, commentId).subscribe();
    this.comments = this.comments.filter(item => item.id !== commentId);
  }

}
