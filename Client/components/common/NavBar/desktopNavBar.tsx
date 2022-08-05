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

const DesktopNavBar = ({
  onShowMenu,
  onSetShowMenu,
  onShowMegaMenu,
  onSetShowMegaMenu,
  onMegaMenu2Display,
  onSetMegaMenuToDisplay,
}: DesktopNavBarProps): JSX.Element => {
  const [visible, setVisible] = useState(false);
  const [showCity, setShowCity] = useState(false);
  const [showLogin, setShowLogin] = useState(false);


  // Login Modal
  const handleLogin = (): void => {
    setShowLogin(false);
  };

  const showLoginModal = (): void => {
    setShowLogin(true);
  };
  // Select City Modal
  const handleOk = (): void => {
    setVisible(false);
  };

  const showModal = (): void => {
    setVisible(true);
  };

  const closeModal = (): void => {
    setVisible(false);
  };

  return (
    <>
      <LoginModal onShowLogin={showLogin} onLogin={handleLogin} />
      <CityModal onOk={handleOk}
        onCloseModal={closeModal}
        onSetShowCity={setShowCity}
        modalVisible={visible}
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
                <Button className={styles.nav__items} onClick={showModal} variant="text">
                  <LocationOnOutlined />
                  <span className={styles.navbtn__text}>انتخاب شهر</span>
                </Button>
              </Grid>
              <Grid item>
                <Button className={styles.nav__items}>
                  <a
                    onClick={(e) => {
                      onSetShowMegaMenu(!onShowMegaMenu);
                      e.preventDefault();
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
                  </a>
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
                  <MyBazzarMenu onSetShowLogin={showLoginModal} />
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
