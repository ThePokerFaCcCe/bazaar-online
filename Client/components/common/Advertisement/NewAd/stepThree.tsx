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
import { Category, StepsProp } from "../../../../types/type";

const StepThree = ({
  selectedSubChildCtg: category,
  onBackToCategories,
  onNextStep,
}: StepsProp): JSX.Element => {
  console.log("category", category);
  return (
    <>
      <Box className="NewAd">
        <Grid
          container
          sx={{ cursor: "pointer" }}
          direction="row"
          className="border-bottom"
          alignItems="center"
        >
          <Grid item>
            <ArrowForward className={styles.icons} />
          </Grid>
          <Grid item>
            <Typography
              onClick={onBackToCategories}
              sx={{ fontSize: "14px", fontWeight: "500", p: "10px 0" }}
            >
              بازگشت به همه دسته ها
            </Typography>
          </Grid>
        </Grid>
        {category &&
          category?.children?.map((item, index) => (
            <Grid
              sx={{ m: "5px 0", cursor: "pointer" }}
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
                      onClick={() => onNextStep(item)}
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
    </>
  );
};

export default StepThree;
