import { Component } from '@angular/core';
import { from } from 'rxjs';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CarService } from '../car.service';
import { CommonModule } from '@angular/common';
import { CarListComponent } from '../car-list/car-list.component';

@Component({
  selector: 'app-car-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, CarListComponent],
  templateUrl: './car-form.component.html',
  styleUrl: './car-form.component.css',
  providers: [CarService],
})
export class CarFormComponent {
  fb: FormBuilder;
  carForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private carService: CarService
  ) {
    this.fb = formBuilder;
    this.carForm = this.fb.group({
      brand: ['', Validators.required],
      class: ['', Validators.required],
      modelName: ['', Validators.required],
      modelCode: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z0-9]{10}$/)],
      ],
      description: ['', Validators.required],
      features: ['', Validators.required],
      price: ['', [Validators.required, Validators.min(1)]],
      dateOfManufacturing: ['', Validators.required],
      active: [false],
      sortOrder: ['', Validators.required],
      images: [null, Validators.required],
    });
  }
  brands = ['Audi', 'Jaguar', 'Land Rover', 'Renault'];
  classes = ['A-Class', 'B-Class', 'C-Class'];

  onSubmit() {
    if (this.carForm.valid) {
      this.carService.addCar(this.carForm.value).subscribe();
    }
  }
}
