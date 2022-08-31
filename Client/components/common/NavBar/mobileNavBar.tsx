import Link from "next/link";
import { IconButton, Box, Grid, Button } from "@mui/material";
import {
  Menu,
  Home,
  MarkunreadMailboxOutlined,
  Close,
  Search,
  Login,
  Logout,
  PeopleOutlined,
} from "@mui/icons-material";
import { Input } from "antd";
import { Sidebar } from "primereact/sidebar";
import { NavItems, Store } from "../../../types/type";
import { useSelector, useDispatch } from "react-redux";
import {
  MOBILE_MENU_CLOSED,
  MOBILE_MENU_OPEN,
  SIGN_MODAL_OPEN,
} from "../../../store/state/ui";
import styles from "../../../styles/NavBar.module.css";
import Logo from "./logo";
import { logout } from "../../../services/httpService";

const navItems: NavItems = [
  { title: "خانه", icon: <Home className={styles.navbar__icon} /> },
  {
    title: "ورود | ثبت نام",
    icon: <Login className={styles.navbar__icon} />,
  },
  {
    title: "آگهی ها",
    icon: <MarkunreadMailboxOutlined className={styles.navbar__icon} />,
  },
  {
    title: "درباره ما",
    icon: <PeopleOutlined className={styles.navbar__icon} />,
  },
];

const navItemsLoggedIn: NavItems = [
  { title: "خانه", icon: <Home className={styles.navbar__icon} /> },
  { title: "خروج", icon: <Logout className={styles.navbar__icon} /> },
  {
    title: "آگهی ها",
    icon: <MarkunreadMailboxOutlined className={styles.navbar__icon} />,
  },
  {
    title: "درباره ما",
    icon: <PeopleOutlined className={styles.navbar__icon} />,
  },
];

const MobileNavBar = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  //
  const { mobileMenuVisible } = useSelector(
    (state: Store) => state.entities.ui.navbar
  );
  const { isLoggedIn } = useSelector((state: Store) => state.entities);

  //
  const navItemToShow = isLoggedIn ? navItemsLoggedIn : navItems;
  // Event Handler

  const modalToOpen = (title: string) => {
    switch (title) {
      case "ورود | ثبت نام":
        dispatch(MOBILE_MENU_CLOSED());
        dispatch(SIGN_MODAL_OPEN());
        return;
      case "خروج":
        logout();
      default:
        null;
    }
  };

  // Render
  return (
    <>
      <Box className={styles.mobile__nav}>
        <IconButton onClick={() => dispatch(MOBILE_MENU_OPEN())}>
          <Menu />
        </IconButton>
        <Link href="/">
          <div style={{ cursor: "pointer" }}>
            <Logo />
          </div>
        </Link>
        {isLoggedIn ? (
          <Link href="/ad/new">
            <Button className={styles.navbar__btn} variant="contained">
              ثبت آگهی
            </Button>
          </Link>
        ) : (
          <Button
            className={styles.navbar__btn}
            onClick={() => dispatch(SIGN_MODAL_OPEN())}
            variant="contained"
          >
            ثبت آگهی
          </Button>
        )}
      </Box>
      <Sidebar
        icons={() => (
          <Close
            sx={{ cursor: "pointer" }}
            onClick={() => dispatch(MOBILE_MENU_CLOSED())}
          />
        )}
        showCloseIcon={false}
        position="right"
        visible={mobileMenuVisible}
        onHide={() => dispatch(MOBILE_MENU_CLOSED())}
      >
        <Box className={styles.navbar__drawer}>
          {navItemToShow.map((item, index) => {
            return (
              <Box
                sx={{ fontWeight: "500" }}
                key={index}
                onClick={() => modalToOpen(item.title)}
                className="w-100 border-bottom p-3"
              >
                <Grid container spacing={2} direction="row" alignItems="center">
                  <Grid item>{item.icon}</Grid>
                  <Grid item>
                    <a className={styles.navbar__title}>{item.title}</a>
                  </Grid>
                </Grid>
              </Box>
            );
          })}
          <Box sx={{ fontWeight: "500" }} className="w-100 border-bottom p-3">
            <label className="pb-2">جستجو</label>
            <Input
              className={styles.search__input}
              size="large"
              placeholder="جستجو در همه آگهی ها"
              prefix={<Search sx={{ color: "#BCBCBC" }} />}
            />
          </Box>
        </Box>
      </Sidebar>
    </>
  );
};

export default MobileNavBar;
