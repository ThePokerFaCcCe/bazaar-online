import type { AppProps } from "next/app";
import NavBar from "../components/navBar";
import { Provider } from "react-redux";
import  store  from '../store/configureStore';
import "bootstrap/dist/css/bootstrap.min.css";
import "antd/dist/antd.css";
import "../styles/globals.css";
function MyApp({ Component, pageProps }: AppProps) {
  return (
    <>
    <Provider store={store}>
      <NavBar />
      <Component {...pageProps} />
    </Provider>
    </>
  );
}

export default MyApp;
