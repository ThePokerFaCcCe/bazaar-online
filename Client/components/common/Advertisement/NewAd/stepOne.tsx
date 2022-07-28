import { useState } from "react";
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
  ArrowForward,
} from "@mui/icons-material";
import styles from "../../../../styles/NavBar.module.css";
import { Category, StepsProp } from "../../../../type/allTypes";

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

const StepOne = ({ onSetStep }: StepsProp): JSX.Element => (
  <Box className="NewAd">
    <Grid sx={{ mb: "0.3rem" }} container direction="column" alignItems="start">
      <Typography sx={{ fontSize: "20px", fontWeight: "500", mb: "5px" }}>
        ثبت آگهی
      </Typography>
      <Typography className="text-muted" sx={{ fontSize: "12px" }}>
        انتخاب دسته‌بندی
      </Typography>
    </Grid>
    {category.map((item, index) => (
      <Grid
        sx={{ m: "5px 0", cursor: "pointer" }}
        onClick={() => onSetStep(2)}
        className="border-bottom"
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
              <Typography
                sx={{
                  color: "rgba(0, 0, 0, 0.87) !important",
                  fontSize: "15px !important",
                }}
                className={styles.category__item}
              >
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
  </Box>
);

export default StepOne;
