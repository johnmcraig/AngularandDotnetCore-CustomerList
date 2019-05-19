import { Component, OnInit, Input } from '@angular/core';
import { Customer } from 'src/app/shared/models/customer.model';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  @Input() allCustomers: Customer[] = [];

  constructor() { }

  ngOnInit() {
  }

}
