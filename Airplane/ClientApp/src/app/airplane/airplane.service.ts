import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAirplane } from '../models/airplane.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {

  constructor(private httpClient: HttpClient) { }

  getAirplanes(): Observable<IAirplane[]> { 
    let url = `/api/airplane`;
    return this.httpClient.get<IAirplane[]>(url);
  }

  getAirplane(id: number): Observable<IAirplane> {
    let url = `/api/airplane/` + id;
    return this.httpClient.get<IAirplane>(url);
  }

  updateAirplane(id: number, customer: IAirplane): Observable<IAirplane> {
    let url = `/api/airplane/` + id;
    return this.httpClient.put<IAirplane>(url, customer, httpOptions);
  }

  createAirplane(airplane: IAirplane): Observable<IAirplane> {
    let url = `/api/airplane`;
    return this.httpClient.post<IAirplane>(url, airplane, httpOptions);
  }

  deleteAirplane(id: number): Observable<IAirplane> {
    let url = `/api/airplane/` + id;
    return this.httpClient.delete<IAirplane>(url);
  }
}
