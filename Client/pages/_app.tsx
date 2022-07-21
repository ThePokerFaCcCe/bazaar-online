import type { AppProps } from "next/app";
import "bootstrap/dist/css/bootstrap.min.css";
import "antd/dist/antd.css";
import "../styles/globals.css";
function MyApp({ Component, pageProps }: AppProps) {
  return <Component {...pageProps} />;
}

export default MyApp;
