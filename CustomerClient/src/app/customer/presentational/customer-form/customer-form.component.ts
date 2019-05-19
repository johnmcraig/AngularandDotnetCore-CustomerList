import { Component, OnInit, Output } from '@angular/core';
import { EventEmitter } from 'events';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  @Output() customerAdded = new EventEmitter();
  form: FormGroup;

  constructor() { }

  ngOnInit() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      postion: new FormControl('', Validators.required),
      age: new FormControl('', Validators.required)
    });
  }

  addCustomer() {
    const customerToAdd = this.form.value;
    this.customerAdded.emit(customerToAdd);
  }

}
