import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from 'src/app/shared/models/customer';
import { CustomerDataService } from 'src/app/core/customer/customer-data.service';

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

}