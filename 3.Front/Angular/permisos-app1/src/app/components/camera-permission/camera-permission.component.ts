import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-camera-permission',
  templateUrl: './camera-permission.component.html',
  styleUrls: ['./camera-permission.component.css'],
  standalone: true,
  imports: [CommonModule]  // Importa CommonModule aquí
})
export class CameraPermissionComponent implements OnInit {
  videoElement: HTMLVideoElement | undefined;
  latitude: number | undefined;
  longitude: number | undefined;
  randomNumber: number = 0;

  ngOnInit() {
    if (typeof window !== 'undefined' && 'navigator' in window) {
      this.requestCameraPermission();
      this.getGeolocation();
    }
  }

  requestCameraPermission() {
    if (navigator && navigator.mediaDevices) {
      navigator.mediaDevices.getUserMedia({ video: true })
        .then(stream => {
          this.videoElement = document.querySelector('video') as HTMLVideoElement;
          if (this.videoElement) {
            this.videoElement.srcObject = stream;
            this.videoElement.play();
          }
        })
        .catch(error => console.error('Permiso de cámara denegado', error));
    }
  }

  getGeolocation() {
    if (navigator && navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.latitude = position.coords.latitude;
          this.longitude = position.coords.longitude;
          this.randomNumber = Math.floor(Math.random() * 1000);
          this.saveData();
        },
        (error) => console.error('Error al obtener geolocalización', error)
      );
    } else {
      console.error('Geolocalización no soportada en este navegador.');
    }
  }

  saveData() {
    if (typeof window !== 'undefined' && 'localStorage' in window) {
      const data = {
        latitude: this.latitude,
        longitude: this.longitude,
        randomNumber: this.randomNumber
      };
      localStorage.setItem('geoData', JSON.stringify(data));

      // Verificar los datos en la consola
      console.log('Datos guardados en localStorage:', localStorage.getItem('geoData'));
    }
  }
}
