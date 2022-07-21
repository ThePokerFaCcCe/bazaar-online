import type { AppProps } from "next/app";
import NavBar from "../component/NavBar";
import "bootstrap/dist/css/bootstrap.min.css";
import "antd/dist/antd.css";
import "../styles/globals.css";
function MyApp({ Component, pageProps }: AppProps) {
  return (
    <>
      <NavBar />
      <Component {...pageProps} />;
    </>
  );
}

export default MyApp;
