import { useState } from "react";
import { MapContainer, TileLayer, Marker, useMapEvents } from "react-leaflet";
import { Map } from "../../../../types/type";
import "leaflet/dist/leaflet.css";
import "leaflet-defaulticon-compatibility/dist/leaflet-defaulticon-compatibility.css";
import "leaflet-defaulticon-compatibility";

const Map = ({ center, marker }: Map): JSX.Element => {
  const [position, setPosition] = useState<[number, number]>(
    marker || [51.505, 51.505]
  );
  // Add Marker on Map onClick
  function Mark() {
    const map = useMapEvents({
      click: ({ latlng }) => {
        setPosition([latlng.lat, latlng.lng]);
      },
    });
    return <Marker position={position} />;
  }

  return (
    <MapContainer
      center={center || marker || [35.7219, 51.3347]}
      zoom={marker ? 15 : 6}
      scrollWheelZoom={false}
      style={{ height: "50vh" }}
    >
      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
      {marker ? <Marker position={position} /> : <Mark />}
    </MapContainer>
  );
};

export default Map;
