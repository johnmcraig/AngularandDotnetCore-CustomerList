import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { allPresentationalComponents } from './presentational/index';
import { allContainerComponents } from './container/index';
import { CustomerFormComponent } from './presentational/customer-form/customer-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomerDetailsComponent } from './presentational/customer-details/customer-details.component';
import { RouterModule } from '@angular/router';
import { CustomerListComponent } from './presentational/customer-list/customer-list.component';
import { CustomerUpdateComponent } from './presentational/customer-update/customer-update.component';
import { CustomerDeleteComponent } from './presentational/customer-delete/customer-delete.component';

@NgModule({
  declarations: [
  ...allPresentationalComponents,
  ...allContainerComponents,
  CustomerFormComponent,
  CustomerDetailsComponent,
  CustomerDeleteComponent,
  CustomerUpdateComponent,
  CustomerListComponent
],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
    { path: 'list', component: CustomerListComponent},
    { path: 'details/:id', component: CustomerDetailsComponent },
    { path: 'create', component: CustomerFormComponent},
    { path: 'update/:id', component: CustomerUpdateComponent },
    { path: 'delete/:id', component: CustomerDeleteComponent},
    ])
  ],
  exports: [...allContainerComponents]
})
export class CustomerModule { }
