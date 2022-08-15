import { Box, Grid, Typography } from "@mui/material";
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
import styles from "../../../styles/NavBar.module.css";
import { CategoryObject, Category, Store } from "../../../types/type";
import { megaMenuToggle } from "../../../store/state/ui";
import { useDispatch, useSelector } from "react-redux";
import { useState } from "react";

const MegaMenu = () => {
  // Redux Setup
  const dispatch = useDispatch();
  const category: Category = useSelector(
    (state: Store) => state.entities.category
  );
  // Local State
  const [megaMenu2Display, setMegaMenu2Display] = useState<
    CategoryObject | any
  >(category?.[0]);
  console.log("store ", megaMenu2Display);
  console.log("megaMenu", megaMenu2Display);
  return (
    <Box className={styles.megamenu__content}>
      <Box className={styles.navbar__category}>
        <Grid container>
          <Grid item xs={2.3} sx={{ borderLeft: "1px solid #ccc" }}>
            <Grid
              container
              onClick={() => dispatch(megaMenuToggle())}
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
                  onMouseEnter={() => setMegaMenu2Display(item)}
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
            {megaMenu2Display?.children?.map((item: any, index: number) => {
              return (
                <Box className={styles.category__menu_holder} key={index}>
                  <a className={styles.category__menu_title}>{item.title}</a>
                  {item?.children?.map((items: any) => {
                    return (
                      <a className={styles.category__menu_item}>
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
