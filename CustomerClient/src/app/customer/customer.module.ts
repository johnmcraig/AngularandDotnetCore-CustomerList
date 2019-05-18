import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { allPresentationalComponents } from './presentational';
import { allContainerComponents } from './container';

@NgModule({
  declarations: [...allPresentationalComponents, ...allContainerComponents],
  imports: [
    CommonModule
  ],
  exports: [...allContainerComponents]
})
export class CustomerModule { }
