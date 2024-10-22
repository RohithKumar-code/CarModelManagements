import { Component } from '@angular/core';
import { Salesman, SalesmanService } from '../salesman.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-salesman-commission',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './salesman-commission.component.html',
  styleUrl: './salesman-commission.component.css',
})
export class SalesmanCommissionComponent {
  salesman: Salesman = {
    name: '',
    lastYearSales: 0,
    salesRecords: [],
  };

  commission: number | null = null;

  constructor(private salesmanService: SalesmanService) {}

  calculateCommission() {
    this.salesmanService
      .calculateCommission(this.salesman)
      .subscribe((commission) => {
        this.commission = commission;
      });
  }
}
