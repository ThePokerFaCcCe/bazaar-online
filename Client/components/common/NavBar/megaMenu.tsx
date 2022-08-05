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
} from "@mui/icons-material";
import styles from "../../../styles/NavBar.module.css";
import { Category, MegaMenuProps } from "../../types/type";

const category: Category = [
  {
    title: "املاک",
    link: "/",
    icon: <HouseOutlined className={styles.icons} />,
  },
  {
    title: "وسایل نقلیه",
    link: "/",
    icon: <DirectionsCarFilledOutlined className={styles.icons} />,
  },
  {
    title: "کالای دیجیتال",
    link: "/",
    icon: <PhoneIphoneOutlined className={styles.icons} />,
  },
  {
    title: "خانه و آشپزخانه",
    link: "/",
    icon: <BlenderOutlined className={styles.icons} />,
  },
  {
    title: "خدمات",
    link: "/",
    icon: <FormatPaintOutlined className={styles.icons} />,
  },
  {
    title: "وسایل شخصی",
    link: "/",
    icon: <WatchOutlined className={styles.icons} />,
  },
  {
    title: "سرگرمی و فراغت",
    link: "/",
    icon: <CasinoOutlined className={styles.icons} />,
  },
  {
    title: "اجتماعی",
    link: "/",
    icon: <PeopleOutlined className={styles.icons} />,
  },
  {
    title: "تجهیزات و صنعتی",
    link: "/",
    icon: <HomeRepairServiceOutlined className={styles.icons} />,
  },
];

const MegaMenu = ({
  onSetShowMegaMenu,
  onSetMegaMenu2Display,
}: MegaMenuProps) => (
  <Box
    sx={{
      height: "420px",
      width: "1024px",
      position: "relative",
      overflow: "auto",
      margin: "1rem 0",
      padding: "1rem 0",
      left: "7vw",
      zIndex: "999",
      backgroundColor: "#fff",
      boxShadow: "0 0 3px 1px #ccc",
      borderRadius: "15px",
    }}
  >
    <Box className={styles.navbar__category}>
      <Grid container>
        <Grid item xs={2.3} sx={{ borderLeft: "1px solid #ccc" }}>
          <Grid
            container
            onClick={() => onSetShowMegaMenu(false)}
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
          {category.map((item, index) => (
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
                    <Box>{item.icon}</Box>
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

export default MegaMenu;
