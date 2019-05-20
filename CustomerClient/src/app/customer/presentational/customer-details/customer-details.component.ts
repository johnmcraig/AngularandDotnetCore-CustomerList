import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CustomerDataService } from 'src/app/core/customer/customer-data.service';
import { Customer } from 'src/app/shared/models/customer.model';
import { switchMap, map } from 'rxjs/operators';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {
  customerDetails$: Observable<Customer>;

  constructor(private readonly route: ActivatedRoute,
              private readonly dataService: CustomerDataService) { }

  ngOnInit() {
    this.customerDetails$ = this.route.paramMap.pipe(map((params: ParamMap) => params.get('id')),
    switchMap((id: string) => this.dataService.getSignle(+id))
    );
  }

}
