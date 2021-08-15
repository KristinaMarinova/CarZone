import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddCommentModel } from 'src/app/models/addComentModel';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(
    private http: HttpClient,
  ) { }

  getAll(id: number): Observable<any> {
    debugger;
    return this.http.get(`api/Cars/${id}/Comments`);
  }

  addComment(id: number, comment: AddCommentModel): Observable<any> {
    return this.http.post(`api/Cars/${id}/Comments`, { Content: comment.content });
  }

  deleteComment(carId: number, commentId: number): Observable<any> {
    return this.http.delete(`api/Cars/${carId}/Comments/${commentId}`);
  }

}