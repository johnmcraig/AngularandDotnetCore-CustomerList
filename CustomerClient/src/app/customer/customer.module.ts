import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { allPresentationalComponents } from './presentational/index';
import { allContainerComponents } from './container/index';
import { CustomerFormComponent } from './presentational/customer-form/customer-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomerDetailsComponent } from './presentational/customer-details/customer-details.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [...allPresentationalComponents, ...allContainerComponents, CustomerFormComponent, CustomerDetailsComponent],
  imports: [
    CommonModule, ReactiveFormsModule, RouterModule
  ],
  exports: [...allContainerComponents]
})
export class CustomerModule { }
