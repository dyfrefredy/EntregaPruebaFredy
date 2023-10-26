import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  headers = new HttpHeaders();

  constructor(
    private httpClient: HttpClient
  ) {
    this.headers = this.headers.append('Content-Type', 'application/json');
    this.headers = this.headers.append('Accept', 'application/json');
    this.headers = this.headers.append('Authorization', 'Bearer ' + localStorage.getItem("msal.idtoken"));
  }

  public getAll(apiUrl: string, urlService: string): Observable<any> {
    return this.httpClient
      .get<any>(`${apiUrl}` + `${urlService}`, { headers: this.headers })
      .pipe(map(res => {
        return res;
      }));
  }

  public save(apiUrl: string, urlService: string, data?: any): Observable<any> {
    return this.httpClient
      .post<any>(`${apiUrl}` + `${urlService}`, data, { headers: this.headers })
      .pipe(map(res => {
        return res;
      }));
  }
}
