import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StaffService {

  private staffApiUrl: string = 'https://localhost:5001/api/Staff';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getStaff(type:string):Observable<any> {
    return this.http.get<any>(this.staffApiUrl + "?type=" + type)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    // if (error.error instanceof ErrorEvent) {
    //   // A client-side or network error occurred. Handle it accordingly.
    //   console.error('An error occurred:', error.error.message);
    // } else {
    //   // The backend returned an unsuccessful response code.
    //   // The response body may contain clues as to what went wrong.
    //   console.error(
    //     `Backend returned code ${error.status}, ` +
    //     `body was: ${error.error}`);
    // }
    // Return an observable with a user-facing error message.
    return throwError(error);
  }

  addStaff(staffObj:object):Observable<any>{
    return this.http.post<any>(this.staffApiUrl,staffObj,this.httpOptions)
    .pipe(
      catchError(this.handleError)
    );
  }

  updateStaff(staffObj:object):Observable<any>{
    const modifiedUrl:string = this.staffApiUrl + '/' + staffObj['empcode'];
    return this.http.put<any>(modifiedUrl, staffObj, this.httpOptions)
    .pipe(
      catchError(this.handleError)
    );
  }

  deleteStaff(staffObj:object):Observable<any>{
    const modifiedUrl:string = this.staffApiUrl + '/' + staffObj['empCode'];
    return this.http.delete<any>(modifiedUrl, this.httpOptions)
    .pipe(
      catchError(this.handleError)
    );
  }
}
