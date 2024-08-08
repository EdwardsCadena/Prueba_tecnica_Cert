// src/components/DataStorage.js
import React, { useState, useEffect } from 'react';

const DataStorage = ({ location }) => {
  const [randomNumber, setRandomNumber] = useState(null);

  useEffect(() => {
    if (location) {
      const number = Math.floor(Math.random() * 100) + 1;
      setRandomNumber(number);
      const data = {
        location,
        randomNumber: number,
      };
      localStorage.setItem('userData', JSON.stringify(data));
      console.log('Data stored in localStorage:', data);
    }
  }, [location]);

  return (
    <div>
      {randomNumber && (
        <p>
          Random Number: {randomNumber}, Location: Latitude {location.latitude}, Longitude {location.longitude}
        </p>
      )}
    </div>
  );
};

export default DataStorage;
