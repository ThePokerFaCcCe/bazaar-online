import * as React from "react";
import { Box, Grid, Button } from "@mui/material";
import LocationOnOutlinedIcon from "@mui/icons-material/LocationOnOutlined";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import ChatBubbleOutlineOutlinedIcon from "@mui/icons-material/ChatBubbleOutlineOutlined";
import styles from "../styles/NavBar.module.css";
import MyBazzarMenu from "./common/NavBar/myBazzarMenu";

const NavBar = (): JSX.Element => {
  return (
    <Box sx={{ padding: "1rem 2rem", borderBottom: "1px solid #EAEAEA" }}>
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
              <h6 style={{ color: "#A62626" }}>بازار آنلاین</h6>
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
              <Button className={styles.nav__items} variant="text">
                <LocationOnOutlinedIcon />
                <span className={styles.navbtn__text}>انتخاب شهر</span>
              </Button>
            </Grid>
          </Grid>
        </Grid>
        <Grid item>
          <Grid container direction="row" alignItems="center" spacing={2}>
            <Grid item className={styles.dropdown}>
              <Button className={styles.nav__items} variant="text">
                <div>
                  <span>
                    <PersonOutlineOutlinedIcon />
                  </span>
                  <span className={styles.navbtn__text}>بازاره من</span>
                </div>
              </Button>
              <div className={styles.dropdown__content}>
                <MyBazzarMenu />
              </div>
            </Grid>

            <Grid item>
              <Button className={styles.nav__items} variant="text">
                <span>
                  <ChatBubbleOutlineOutlinedIcon />
                </span>
                <span className={styles.navbtn__text}>چت</span>
              </Button>
            </Grid>
            <Grid item>
              <Button className={styles.nav__items}>پشتیبانی</Button>
            </Grid>
            <Grid item>
              <Button className={styles.navbar__btn} variant="contained">
                ثبت آگهی
              </Button>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Box>
  );
};

export default NavBar;
