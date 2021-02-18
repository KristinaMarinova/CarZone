import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommentModel } from 'src/app/models/comentModel';

@Component({
  selector: 'comment-preview',
  templateUrl: './comment-preview.component.html',
  styleUrls: ['./comment-preview.component.css']
})
export class CommentPreviewComponent implements OnInit {
  @Input() comment: CommentModel;
  @Output() deleteRequest = new EventEmitter<number>();

  userId: number = +localStorage.getItem('userId');

  constructor() {
  }

  ngOnInit(): void {
  }

  deleteComment(value: number) {
    this.deleteRequest.emit(value);
  }
}
