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
import MegaMenu from "./common/NavBar/megaMenu";
import MyBazzarMenu from "./common/NavBar/myBazzarMenu";
import styles from "../styles/NavBar.module.css";
const NavBar = (): JSX.Element => {
  const [showMenu, setShowMenu] = useState(false);
  const [showMegaMenu, setShowMegaMenu] = useState(false);
  const [megaMenu2Display, setMegaMenu2Display] = useState("");

  return (
    <Box sx={{ padding: "1rem 0", borderBottom: "1px solid #EAEAEA" }}>
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
                <LocationOnOutlined />
                <span className={styles.navbtn__text}>انتخاب شهر</span>
              </Button>
            </Grid>
            <Grid item>
              <Button className={styles.nav__items}>
                <a
                  onClick={(e) => {
                    setShowMegaMenu(!showMegaMenu);
                    e.preventDefault();
                  }}
                >
                  <Box>
                    <Grid container spacing={0.5} alignItems="center">
                      <Grid item>دسته ها</Grid>
                      <Grid item>
                        {showMegaMenu ? <ExpandLess /> : <ExpandMore />}
                      </Grid>
                    </Grid>
                  </Box>
                </a>
              </Button>
              <Box
                className={
                  showMegaMenu ? styles.megamenu__dropdown_content : "d-none"
                }
              >
                <MegaMenu
                  onSetShowMegaMenu={setShowMegaMenu}
                  onSetMegaMenu2Display={setMegaMenu2Display}
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
                onClick={() => setShowMenu(!showMenu)}
                variant="text"
              >
                <div>
                  <span>
                    <PersonOutlineOutlined />
                  </span>
                  <span className={styles.navbtn__text}>بازاره من</span>
                </div>
              </Button>
              <div className={showMenu ? styles.dropdown__content : "d-none"}>
                <MyBazzarMenu />
              </div>
            </Grid>
            <Grid item>
              <Button className={styles.nav__items} variant="text">
                <span>
                  <ChatBubbleOutlineOutlined />
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
