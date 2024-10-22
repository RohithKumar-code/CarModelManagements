import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarListComponent } from './car-management/car-list/car-list.component';
import { CarFormComponent } from './car-management/car-form/car-form.component';
import { SalesmanCommissionComponent } from './salesman/salesman-commission/salesman-commission.component';

export const routes: Routes = [
  { path: 'car-list', component: CarListComponent, title: 'Car List' },
  { path: 'add-car', component: CarFormComponent, title: 'Add Car' },
  {
    path: 'salesman-commission',
    component: SalesmanCommissionComponent,
    title: 'Salesman',
  },
  { path: '', redirectTo: '/car-list', pathMatch: 'full' },
];
