import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerDetailsComponent } from './customer/presentational/customer-details/customer-details.component';
import { CustomersComponent } from './customer/container/customers/customers.component';


const routes: Routes = [
    { path: 'home', component: CustomersComponent },
    { path: 'customer', loadChildren: './customer/customer.module#CustomerModule'},
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', redirectTo: '/home' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
