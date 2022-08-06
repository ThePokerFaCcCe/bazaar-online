import { useState } from "react";
import { Box, Grid, Button } from "@mui/material";
import {
  LocationOnOutlined,
  PersonOutlineOutlined,
  ChatBubbleOutlineOutlined,
  ExpandMore,
  ExpandLess,
  Search,
} from "@mui/icons-material";
import { Input } from "antd";
import { DesktopNavBarProps } from "../../../types/type";
import MyBazzarMenu from "./myBazzarMenu";
import MegaMenu from "./megaMenu";
import CityModal from "../../cityModal";
import styles from "../../../styles/NavBar.module.css";
import Link from "next/link";
import LoginModal from "../../loginModal";
import RegisterModal from "../../registerModal";

const DesktopNavBar = ({
  onShowMenu,
  onSetShowMenu,
  onShowMegaMenu,
  onSetShowMegaMenu,
  onMegaMenu2Display,
  onSetMegaMenuToDisplay,
}: DesktopNavBarProps): JSX.Element => {
  const [cityModalVisible, setCityModalVisible] = useState(false);
  const [showCity, setShowCity] = useState(false);
  const [showLogin, setShowLogin] = useState(false);
  const [showRegister, setShowRegister] = useState(false);

  // Register Modal
  const handleRegister = (): void => {
    setShowRegister(false);
  };

  const showRegisterModal = (): void => {
    onSetShowMenu(false);
    setShowRegister(true);
  };

  const handleCloseRegister = (): void => {
    setShowRegister(false);
  };

  // Login Modal
  const handleLogin = (): void => {
    setShowLogin(false);
  };

  const showLoginModal = (): void => {
    onSetShowMenu(false);
    setShowLogin(true);
  };

  const handleCloseLogin = (): void => {
    setShowLogin(false);
  };

  // Select City Modal
  const handleOk = (): void => {
    setCityModalVisible(false);
  };

  const showModal = (): void => {
    onSetShowMenu(false);
    setCityModalVisible(true);
  };

  const closeModal = (): void => {
    setCityModalVisible(false);
  };

  return (
    <>
      <RegisterModal
        onShowRegister={showRegister}
        onRegister={handleRegister}
        onCloseLogin={handleCloseRegister}
      />
      <LoginModal
        onShowLogin={showLogin}
        onLogin={handleLogin}
        onCloseLogin={handleCloseLogin}
      />
      <CityModal
        onOk={handleOk}
        onCloseModal={closeModal}
        onSetShowCity={setShowCity}
        modalVisible={cityModalVisible}
        showCity={showCity}
      />
      <Box className={styles.desktop__navBar}>
        <Grid
          container
          direction="row"
          justifyContent="space-between"
          alignItems="center"
        >
          <Grid item>
            <Grid
              container
              spacing={1}
              direction="row"
              justifyContent="center"
              alignItems="center"
            >
              <Grid item>
                <Link href="/">
                  <h6 className={styles.bazaar__online}>بازار آنلاین</h6>
                </Link>
              </Grid>
              <Grid
                item
                sx={{
                  color: "#fff",
                  borderLeft: "1px solid #E0E0E0",
                  position: "relative",
                  top: "5px",
                  paddingLeft: "5px",
                }}
              >
                |
              </Grid>
              <Grid item sx={{ marginRight: "5px" }}>
                <Button
                  className={styles.nav__items}
                  onClick={showModal}
                  variant="text"
                >
                  <LocationOnOutlined />
                  <span className={styles.navbtn__text}>انتخاب شهر</span>
                </Button>
              </Grid>
              <Grid item>
                <Button
                  className={styles.nav__items}
                  onClick={() => {
                    onSetShowMegaMenu(!onShowMegaMenu);
                  }}
                >
                  <Box>
                    <Grid container spacing={0.5} alignItems="center">
                      <Grid item>دسته ها</Grid>
                      <Grid item>
                        {onShowMegaMenu ? <ExpandLess /> : <ExpandMore />}
                      </Grid>
                    </Grid>
                  </Box>
                </Button>
                <Box
                  className={
                    onShowMegaMenu
                      ? styles.megamenu__dropdown_content
                      : "d-none"
                  }
                >
                  <MegaMenu
                    onSetShowMegaMenu={onSetShowMegaMenu}
                    onSetMegaMenu2Display={onSetMegaMenuToDisplay}
                  />
                </Box>
              </Grid>
              <Grid item>
                <Input
                  className={styles.search__input}
                  size="large"
                  placeholder="جستجو در همه آگهی ها"
                  style={{ width: "25vw" }}
                  prefix={<Search sx={{ color: "#BCBCBC" }} />}
                />
              </Grid>
            </Grid>
          </Grid>
          <Grid item>
            <Grid container direction="row" alignItems="center" spacing={1}>
              <Grid item className={styles.dropdown}>
                <Button
                  className={styles.nav__items}
                  onClick={() => onSetShowMenu(!onShowMenu)}
                  variant="text"
                >
                  <div>
                    <span>
                      <PersonOutlineOutlined />
                    </span>
                    <span className={styles.navbtn__text}>بازاره من</span>
                  </div>
                </Button>
                <div
                  className={onShowMenu ? styles.dropdown__content : "d-none"}
                >
                  <MyBazzarMenu
                    onSetShowLogin={showLoginModal}
                    onSetShowRegister={showRegisterModal}
                  />
                </div>
              </Grid>
              <Grid item>
                <Link href="/chat">
                  <Button className={styles.nav__items} variant="text">
                    <span>
                      <ChatBubbleOutlineOutlined />
                    </span>
                    <span className={styles.navbtn__text}>چت</span>
                  </Button>
                </Link>
              </Grid>
              <Grid item>
                <Button className={styles.nav__items}>پشتیبانی</Button>
              </Grid>
              <Grid item>
                <Link href="/ad/new">
                  <Button className={styles.navbar__btn} variant="contained">
                    ثبت آگهی
                  </Button>
                </Link>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Box>
    </>
  );
};

export default DesktopNavBar;
