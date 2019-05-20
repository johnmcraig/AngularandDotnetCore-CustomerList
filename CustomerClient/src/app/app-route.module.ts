import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerDetailComponent } from './customer/presentational/customer-detail/customer-detail.component';
import { CustomersComponent } from './customer/container/customers/customers.component';

const routes: Routes = [
    { path: 'detail/:id', component: CustomerDetailComponent },
    { path: 'home', component: CustomersComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', redirectTo: '/home' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
