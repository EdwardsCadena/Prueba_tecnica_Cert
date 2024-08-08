// src/App.js
import React, { useState } from 'react';
import Location from './components/Location';
import Camera from './components/Camera';
import DataStorage from './components/DataStorage';
import './App.css';

function App() {
  const [location, setLocation] = useState(null);

  return (
    <div className="App">
      <h1>Permisos de Cámara y Ubicación</h1>
      <Camera />
      <Location onLocationChange={setLocation} />
      {location && <DataStorage location={location} />}
    </div>
  );
}

export default App;
