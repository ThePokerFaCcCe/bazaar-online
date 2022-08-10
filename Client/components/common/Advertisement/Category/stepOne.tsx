import {
  Box,
  Typography,
  Grid,
  Switch,
  Accordion,
  AccordionSummary,
  AccordionDetails,
} from "@mui/material";
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
  ExpandMore,
} from "@mui/icons-material";
import { Input } from "antd";
import { useEffect, useState } from "react";
import styles from "../../../../styles/Advertisement.module.css";
const StepOne = () => {
  <>
    <Box sx={{ margin: "1rem 1rem 2rem" }}>
      <Typography sx={{ fontSize: "1rem", fontWeight: "500", margin: "1rem" }}>
        دسته‌ها
      </Typography>
      <Grid container direction="column" alignItems="flex-start">
        {/* {category.map((item, index) => (
          <Grid item key={index}>
            <Grid container direction="row" alignItems="center">
              <Grid item>{item.icon}</Grid>
              <Grid item>
                <Typography
                  className={styles.category__item}
                  sx={{
                    fontSize: "1rem",
                    margin: "10px 0",
                    color: "rgba(0,0,0,.56)",
                    cursor: "pointer",
                  }}
                >
                  {item.title}
                </Typography>
              </Grid>
            </Grid>
          </Grid>
        ))} */}

        <Accordion sx={{ margin: "10px 0", width: "100%" }}>
          <AccordionSummary expandIcon={<ExpandMore />}>
            <Typography>قیمت</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Box>
              <Grid
                container
                direction="row"
                sx={{ margin: "20px 0" }}
                alignItems="center"
              >
                <Grid item>
                  <span>حداقل قیمت</span>
                </Grid>
                <Grid item sx={{ margin: "0 15px" }}>
                  <Input
                    style={{ width: "100%" }}
                    placeholder="قیمت را وارد کنید"
                  />
                </Grid>
              </Grid>
              <Grid
                container
                direction="row"
                sx={{ margin: "20px 0" }}
                alignItems="center"
              >
                <Grid item>
                  <span>حداکثر قیمت</span>
                </Grid>
                <Grid item sx={{ margin: "0 15px" }}>
                  <Input
                    style={{ width: "100%" }}
                    placeholder="قیمت را وارد کنید"
                  />
                </Grid>
              </Grid>
            </Box>
          </AccordionDetails>
        </Accordion>
        <Accordion sx={{ width: "100%" }}>
          <AccordionSummary expandIcon={<ExpandMore />}>
            <Typography>وضعیت آگهی</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Box>
              <Grid
                container
                direction="row"
                justifyContent="space-between"
                alignItems="center"
              >
                <Grid item>
                  <Typography>فقط عکس دار</Typography>
                </Grid>
                <Grid item>
                  <Switch />
                </Grid>
              </Grid>
              <Grid
                container
                direction="row"
                justifyContent="space-between"
                alignItems="center"
              >
                <Grid item>
                  <Typography>فقط فوری ها</Typography>
                </Grid>
                <Grid item>
                  <Switch />
                </Grid>
              </Grid>
            </Box>
          </AccordionDetails>
        </Accordion>
      </Grid>
    </Box>
  </>;
};

export default StepOne;
