// src/components/Location.js
import React, { useState, useEffect } from 'react';

const Location = ({ onLocationChange }) => {
  const [location, setLocation] = useState(null);

  useEffect(() => {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        const { latitude, longitude } = position.coords;
        setLocation({ latitude, longitude });
        onLocationChange({ latitude, longitude });
      }, (error) => {
        console.error(error);
      });
    } else {
      console.error('Geolocation not available');
    }
  }, [onLocationChange]);

  return (
    <div>
      {location ? (
        <p>Latitude: {location.latitude}, Longitude: {location.longitude}</p>
      ) : (
        <p>Loading location...</p>
      )}
    </div>
  );
};

export default Location;
