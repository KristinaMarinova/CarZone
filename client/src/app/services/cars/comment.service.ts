import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentModel } from 'src/app/models/comentModel';

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

  addComment(id: number, content: string, username: string): Observable<any> {
    return this.http.post(`api/Cars/${id}/Comments`, { content: content, username: username });
  }

  deleteComment(carId: number, commentId: number): Observable<any> {
    return this.http.delete(`api/Cars/${carId}/Comments/${commentId}`);
  }

}