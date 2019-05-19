import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from 'src/app/shared/models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerDataService {
  private controllerEndpoint = `customers`;

  constructor(private readonly http: HttpClient) { }

  getAll() {
    return this.http.get<Customer[]>(`${environment.endpoint}${this.controllerEndpoint}`);
  }

  add(toAdd: Customer) {
    return this.http.post<Customer>(`${environment.endpoint}${this.controllerEndpoint}`, toAdd);
  }
}
