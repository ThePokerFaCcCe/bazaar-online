import type { AppProps } from "next/app";
import { Container } from "@mui/material";
import { Provider } from "react-redux";
import { ToastContainer } from "react-toastify";
import store from "../store/configureStore";
import NavBar from "../components/navBar";
import "bootstrap/dist/css/bootstrap.min.css";
import "antd/dist/antd.css";
import "primereact/resources/themes/lara-light-indigo/theme.css"; //theme
import "primereact/resources/primereact.min.css"; //core css
import "primeicons/primeicons.css";
import "react-toastify/dist/ReactToastify.css";
import "../styles/globals.css";

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <>
      <Provider store={store}>
        <Container className="mui__container" maxWidth="xl">
          <ToastContainer rtl />
          <NavBar />
          <Component {...pageProps} />
        </Container>
      </Provider>
    </>
  );
}

export default MyApp;
