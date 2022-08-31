import dynamic from "next/dynamic";
import { Map } from "../../../../types/type";

const MapNoSSR = dynamic(() => import("../../Advertisement/NewAd/map"), {
  ssr: false,
});

function MapWithNoSSR({ center, marker }: Map) {
  return <MapNoSSR center={center} marker={marker} />;
}

export default MapWithNoSSR;
