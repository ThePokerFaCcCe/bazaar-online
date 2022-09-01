import type { AppProps } from "next/app";
import { Container } from "@mui/material";
import { ToastContainer } from "react-toastify";
import { isUserLoggedIn } from "../services/httpService";
import { useEffect } from "react";
import { SET_USER_STATUS } from "../store/state/user";
import { wrapper } from "../store/configureStore";
import { useDispatch } from "react-redux";
import RTL from "../services/rtl";
import NavBar from "../components/navBar";
import "bootstrap/dist/css/bootstrap.min.css";
import "antd/dist/antd.css";
import "primereact/resources/themes/lara-light-indigo/theme.css"; //theme
import "primereact/resources/primereact.min.css"; //core css
import "primeicons/primeicons.css";
import "react-toastify/dist/ReactToastify.css";
import "../styles/globals.css";
function MyApp({ Component, pageProps }: AppProps) {
  // CDM
  const dispatch = useDispatch();

  useEffect(() => {
    isUserLoggedIn(dispatch, SET_USER_STATUS);
  }, []);

  return (
    <>
      <RTL>
        <>
          <Container className="mui__container" maxWidth="xl">
            <ToastContainer rtl />
            <NavBar />
            <Component {...pageProps} />
          </Container>
        </>
      </RTL>
    </>
  );
}

export default wrapper.withRedux(MyApp);
