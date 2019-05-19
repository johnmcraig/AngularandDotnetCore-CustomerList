import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from 'src/app/shared/models/customer.model';
import { CustomerDataService } from 'src/app/core/customer/customer-data.service';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  allCustomers$: Observable<Customer[]>;

  constructor(private readonly customerDataService: CustomerDataService) { }

  ngOnInit() {
    this.allCustomers$ = this.customerDataService.getAll();
  }

  customerAdded(customerToAdd: Customer) {
    this.allCustomers$ = this.customerDataService.add(customerToAdd)
    .pipe(switchMap(() => this.customerDataService.getAll()));
  }
}
