import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { CameraPermissionComponent } from './components/camera-permission/camera-permission.component';
import { LocationDisplayComponent } from './components/location-display/location-display.component';
import { RandomNumberComponent } from './components/random-number/random-number.component';

@NgModule({
  declarations: [
    AppComponent,
    CameraPermissionComponent,
    LocationDisplayComponent,
    RandomNumberComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
