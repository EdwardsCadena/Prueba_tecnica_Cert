// src/components/Camera.js
import React, { useRef, useEffect } from 'react';

const Camera = () => {
  const videoRef = useRef(null);

  useEffect(() => {
    async function getCameraStream() {
      try {
        const stream = await navigator.mediaDevices.getUserMedia({ video: true });
        videoRef.current.srcObject = stream;
      } catch (err) {
        console.error('Error accessing camera: ', err);
      }
    }

    getCameraStream();
  }, []);

  return (
    <div>
      <video ref={videoRef} autoPlay />
    </div>
  );
};

export default Camera;
