import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Salesman {
  name: string;
  lastYearSales: number;
  salesRecords: {
    brand: string;
    carClass: string;
    numberOfCarsSold: number;
  }[];
}

@Injectable({
  providedIn: 'root',
})
export class SalesmanService {
  private apiUrl = 'https://localhost:5001/api/salesman'; // Adjust the backend URL

  constructor(private http: HttpClient) {}

  calculateCommission(data: any): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}/calculate-commission`, data, {
      responseType: 'json',
    });
  }
}
