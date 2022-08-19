import Link from "next/link";
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
import { useSelector, useDispatch } from "react-redux";
import {
  cityModalToggle,
  desktopMenuToggle,
  megaMenuToggle,
  signModalToggle,
} from "../../../store/state/ui";
import { Store } from "../../../types/type";
import MegaMenu from "./megaMenu";
import MyBazzarMenu from "./myBazzarMenu";
import styles from "../../../styles/NavBar.module.css";
const DesktopNavBar = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  //
  const { desktopMenuVisible, megaMenuVisible } = useSelector(
    (state: Store) => state.entities.ui.navbar
  );
  const { isLoggedIn } = useSelector((state: Store) => state.entities);

  // Render
  return (
    <>
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
                  onClick={() => dispatch(cityModalToggle())}
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
                    dispatch(megaMenuToggle());
                  }}
                >
                  <Box>
                    <Grid container spacing={0.5} alignItems="center">
                      <Grid item>دسته ها</Grid>
                      <Grid item>
                        {megaMenuVisible ? <ExpandLess /> : <ExpandMore />}
                      </Grid>
                    </Grid>
                  </Box>
                </Button>
                <Box
                  className={
                    megaMenuVisible
                      ? styles.megamenu__dropdown_content
                      : "d-none"
                  }
                >
                  <MegaMenu />
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
                  onClick={() => dispatch(desktopMenuToggle())}
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
                  className={
                    desktopMenuVisible ? styles.dropdown__content : "d-none"
                  }
                >
                  <MyBazzarMenu />
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
                {isLoggedIn ? (
                  <Link href="/ad/new">
                    <Button className={styles.navbar__btn} variant="contained">
                      ثبت آگهی
                    </Button>
                  </Link>
                ) : (
                  <Button
                    className={styles.navbar__btn}
                    onClick={() => dispatch(signModalToggle())}
                    variant="contained"
                  >
                    ثبت آگهی
                  </Button>
                )}
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Box>
    </>
  );
};

export default DesktopNavBar;
