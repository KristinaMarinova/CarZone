import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommentModel } from 'src/app/models/comentModel';

@Component({
  selector: 'comment-preview',
  templateUrl: './comment-preview.component.html'
})
export class CommentPreviewComponent {
  @Input() comment: CommentModel;
  @Output() deleteRequest = new EventEmitter<number>();
  userId: number = +localStorage.getItem('userId');

  deleteComment(value: number) {
    this.deleteRequest.emit(value);
  }

}
