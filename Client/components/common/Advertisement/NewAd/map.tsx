// import { MapContainer, TileLayer, Marker, useMapEvents } from "react-leaflet";
// import { useState } from "react";
// import "leaflet/dist/leaflet.css";
// import "leaflet-defaulticon-compatibility/dist/leaflet-defaulticon-compatibility.webpack.css"; // Re-uses images from ~leaflet package
// import "leaflet-defaulticon-compatibility";

// const Map = () => {
//   const [position, setPosition] = useState<[number, number]>([51.505, 51.505]);
//   function Mark() {
//     const map = useMapEvents({
//       click: ({ latlng }) => {
//         setPosition([latlng.lat, latlng.lng]);
//       },
//     });
//     return <Marker position={position} />;
//   }

//   return (
//     <MapContainer
//       center={[35.7219, 51.3347]}
//       zoom={6}
//       scrollWheelZoom={false}
//       style={{ height: "100vh" }}
//     >
//       <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
//       <Mark />
//     </MapContainer>
//   );
// };

// export default Map;