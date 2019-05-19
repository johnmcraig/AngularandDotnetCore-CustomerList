import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { allPresentationalComponents } from './presentational';
import { allContainerComponents } from './container';
import { CustomerFormComponent } from './presentational/customer-form/customer-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [...allPresentationalComponents, ...allContainerComponents, CustomerFormComponent],
  imports: [
    CommonModule, ReactiveFormsModule
  ],
  exports: [...allContainerComponents]
})
export class CustomerModule { }
