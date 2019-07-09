import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from 'src/app/shared/models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerDataService {
  private controllerEndpoint = `customer`;

  constructor(private readonly http: HttpClient) { }

  getAll() {
    return this.http.get<Customer[]>(`${environment.endpoint}${this.controllerEndpoint}`);
  }

  getSingle(id: number) {
    return this.http.get<Customer>(
      `${environment.endpoint}${this.controllerEndpoint}/${id}`
    );
  }

  add(toAdd: Customer) {
    return this.http.post<Customer>(`${environment.endpoint}${this.controllerEndpoint}`, toAdd);
  }

  update(id: number, toUpdate: Customer) {
    return this.http.put<Customer>(`${environment.endpoint}${this.controllerEndpoint}/${id}`, toUpdate);
  }

  delete(id: number) {
    return this.http.delete<Customer>(`${environment.endpoint}${this.controllerEndpoint}/${id}`);
  }
}
