import { Component } from '@angular/core';
import { CameraPermissionComponent } from './components/camera-permission/camera-permission.component';
import { LocationDisplayComponent } from './components/location-display/location-display.component';
import { RandomNumberComponent } from './components/random-number/random-number.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [CameraPermissionComponent, LocationDisplayComponent, RandomNumberComponent]
})
export class AppComponent { }
