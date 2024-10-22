import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Car {
  brand: string;
  class: string;
  modelName: string;
  modelCode: string;
  description: string;
  features: string;
  price: number;
  dateOfManufacturing: Date;
  active: boolean;
  sortOrder: number;
  images: string[];
}

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private apiUrl = 'http://localhost:5026/api/Car'; // Adjust the backend URL

  constructor(private http: HttpClient) {}

  getCars(): Observable<Car[]> {
    return this.http.get<Car[]>(this.apiUrl);
  }

  addCar(car: Car): Observable<Car> {
    return this.http.post<Car>(this.apiUrl, car);
  }

  deleteCar(modelCode: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/cars/${modelCode}`);
  }
}
