import { Component } from '@angular/core';
import { Car, CarService } from '../car.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-car-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './car-list.component.html',
  styleUrl: './car-list.component.css',
  providers: [CarService],
})
export class CarListComponent {
  cars: Car[] = [];

  constructor(private carService: CarService) {}

  ngOnInit(): void {
    this.carService.getCars().subscribe((data) => (this.cars = data));
  }

  deleteCar(modelCode: string) {
    this.carService.deleteCar(modelCode).subscribe(() => {
      this.cars = this.cars.filter((car) => car.modelCode !== modelCode);
    });
  }
}
