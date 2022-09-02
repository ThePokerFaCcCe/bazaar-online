import {
  HouseOutlined,
  DirectionsCarFilledOutlined,
  PhoneIphoneOutlined,
  BlenderOutlined,
  FormatPaintOutlined,
  WatchOutlined,
  PeopleOutlined,
  CasinoOutlined,
  HomeRepairServiceOutlined,
  ChevronLeft,
  ChevronRight,
  WorkOutline,
} from "@mui/icons-material";
import {
  MEGA_MENU_OPEN,
  MEGA_MENU_CLOSED,
  selectStore,
  selectNavBar,
} from "../../store/state/ui";
import { useDispatch, useSelector } from "react-redux";
import { useEffect, useState } from "react";
import { Box, Grid, Typography } from "@mui/material";
import { megaMenu2Show } from "../../types/type";
import styles from "../../styles/NavBar.module.css";

const MegaMenu = () => {
  // Redux Setup
  const dispatch = useDispatch();
  const { category } = useSelector(selectStore);
  const { megaMenuVisible } = useSelector(selectNavBar);
  // Local State
  const [megaMenu2Show, setMegaMenu2Show] = useState<megaMenu2Show>(null);
  // ComponentDidUpdate
  useEffect(() => {
    if (!megaMenu2Show) {
      setMegaMenu2Show(category && category[0]);
    }
  }, [category]);
  // Render
  return (
    <Box className={styles.megamenu__content}>
      <Box className={styles.navbar__category}>
        <Grid container>
          <Grid item xs={2.3} sx={{ borderLeft: "1px solid #ccc" }}>
            <Grid
              container
              onClick={() =>
                megaMenuVisible
                  ? dispatch(MEGA_MENU_CLOSED())
                  : dispatch(MEGA_MENU_OPEN())
              }
              direction="row"
              alignItems="center"
            >
              <Grid item>
                <ChevronRight className={styles.icons} />
              </Grid>
              <Grid item>
                <Typography className={styles.category__item}>
                  بازگشت به همه آگهی ها
                </Typography>
              </Grid>
            </Grid>
            {category &&
              category.map((item: any, index: number) => (
                <Grid
                  key={index}
                  container
                  onMouseEnter={() => setMegaMenu2Show(item)}
                  direction="row"
                  justifyContent="space-between"
                  alignItems="center"
                >
                  <Grid item>
                    <Grid container direction="row" alignItems="center">
                      <Grid item>
                        <Box>{icons[index]}</Box>
                      </Grid>
                      <Grid item>
                        <Typography className={styles.category__item}>
                          {item.title}
                        </Typography>
                      </Grid>
                    </Grid>
                  </Grid>
                  <Grid item>
                    <ChevronLeft className={styles.icons} />
                  </Grid>
                </Grid>
              ))}
          </Grid>
          <Grid item>
            {megaMenu2Show?.children?.map((item: any, index: number) => {
              return (
                <Box className={styles.category__menu_holder} key={index}>
                  <a className={styles.category__menu_title}>{item.title}</a>
                  {item?.children?.map((items: any, index: number) => {
                    return (
                      <a
                        key={index.toString()}
                        className={styles.category__menu_item}
                      >
                        {items.title}
                      </a>
                    );
                  })}
                </Box>
              );
            })}
          </Grid>
        </Grid>
      </Box>
    </Box>
  );
};

export default MegaMenu;

var icons: JSX.Element[] = [
  <HouseOutlined className={styles.icons} />,
  <DirectionsCarFilledOutlined className={styles.icons} />,
  <PhoneIphoneOutlined className={styles.icons} />,
  <BlenderOutlined className={styles.icons} />,
  <FormatPaintOutlined className={styles.icons} />,
  <WatchOutlined className={styles.icons} />,
  <CasinoOutlined className={styles.icons} />,
  <PeopleOutlined className={styles.icons} />,
  <HomeRepairServiceOutlined className={styles.icons} />,
  <WorkOutline className={styles.icons} />,
];
