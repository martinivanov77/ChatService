import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class HomeService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:52291/weatherforecast';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get() {
    // 
    return this.http.get(this.accessPointUrl, { headers: this.headers });
  }
}
