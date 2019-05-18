import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerDataService {
  private controllerEndpoint = `customers`;

  constructor(private readonly http: HttpClient) { }

  getAll() {
    return this.http.get(`${environment.endpoint}${this.controllerEndpoint}`);
  }
}
