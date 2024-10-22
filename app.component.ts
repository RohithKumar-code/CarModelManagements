import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CarFormComponent } from './car-management/car-form/car-form.component';
import { SalesmanCommissionComponent } from './salesman/salesman-commission/salesman-commission.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    CarFormComponent,
    SalesmanCommissionComponent,
    RouterLinkActive,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'CarModelManagement';
}
