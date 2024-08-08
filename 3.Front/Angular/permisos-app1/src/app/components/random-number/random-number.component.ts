import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-random-number',
  templateUrl: './random-number.component.html',
  styleUrls: ['./random-number.component.css'],
  standalone: true,
  imports: [CommonModule]  // Importa CommonModule aquí
})
export class RandomNumberComponent implements OnInit {
  randomNumber: number = 0;

  ngOnInit() {
    if (typeof window !== 'undefined' && 'localStorage' in window) {
      this.randomNumber = Math.floor(Math.random() * 1000);
      this.saveData();
    }
  }

  saveData() {
    if (typeof window !== 'undefined' && 'localStorage' in window) {
      const data = {
        randomNumber: this.randomNumber
      };
      localStorage.setItem('randomData', JSON.stringify(data));

      // Verificar los datos en la consola
      console.log('Datos guardados en localStorage:', localStorage.getItem('randomData'));
    }
  }
}
