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
import { Category, MegaMenuProps, Store } from "../../../types/type";
import { megaMenuToggle } from "../../../store/state/ui";
import { useDispatch, useSelector } from "react-redux";

const MegaMenu = ({ onSetMegaMenu2Display }: MegaMenuProps) => {
  const category: Category = useSelector(
    (state: Store) => state.entities.category
  );

  const dispatch = useDispatch();
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
              category.map((item, index) => (
                <Grid
                  onMouseEnter={(e) =>
                    onSetMegaMenu2Display((e.target as HTMLElement).innerText)
                  }
                  key={index}
                  container
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
            <Box className={styles.category__menu_holder}>
              <a className={styles.category__menu_title}>فروش مسکونی</a>
              <a className={styles.category__menu_item}>آپارتمان</a>
              <a className={styles.category__menu_item}>خانه و ویلا</a>
              <a className={styles.category__menu_item}>زمین و کلنگی</a>
            </Box>
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
