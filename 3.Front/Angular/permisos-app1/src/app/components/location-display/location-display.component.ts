import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-location-display',
  templateUrl: './location-display.component.html',
  styleUrls: ['./location-display.component.css'],
  standalone: true
})
export class LocationDisplayComponent implements OnInit {
  location: string = '';

  ngOnInit() {
    // Verificar que estamos en un entorno de navegador
    if (typeof window !== 'undefined' && 'navigator' in window) {
      this.getLocation();
    }
  }

  getLocation() {
    if (navigator && navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.location = `Lat: ${position.coords.latitude}, Lon: ${position.coords.longitude}`;
        },
        (error) => console.error('Error al obtener la ubicación', error)
      );
    }
  }
}
