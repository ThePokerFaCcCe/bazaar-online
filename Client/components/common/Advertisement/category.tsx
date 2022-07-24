import {
  Box,
  Typography,
  Grid,
  Switch,
  Accordion,
  AccordionSummary,
  AccordionDetails,
} from "@mui/material";
import styles from "../../../styles/Advertisement.module.css";
import HouseOutlinedIcon from "@mui/icons-material/HouseOutlined";
import DirectionsCarFilledOutlinedIcon from "@mui/icons-material/DirectionsCarFilledOutlined";
import PhoneIphoneOutlinedIcon from "@mui/icons-material/PhoneIphoneOutlined";
import BlenderOutlinedIcon from "@mui/icons-material/BlenderOutlined";
import FormatPaintOutlinedIcon from "@mui/icons-material/FormatPaintOutlined";
import WatchOutlinedIcon from "@mui/icons-material/WatchOutlined";
import PeopleOutlinedIcon from "@mui/icons-material/PeopleOutlined";
import CasinoOutlinedIcon from "@mui/icons-material/CasinoOutlined";
import HomeRepairServiceOutlinedIcon from "@mui/icons-material/HomeRepairServiceOutlined";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { Input } from "antd";
import { Category } from "../../../typealias/allTypes";

const category: Category = [
  {
    title: "املاک",
    link: "/",
    icon: <HouseOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "وسایل نقلیه",
    link: "/",
    icon: <DirectionsCarFilledOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "کالای دیجیتال",
    link: "/",
    icon: <PhoneIphoneOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "خانه و آشپزخانه",
    link: "/",
    icon: <BlenderOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "خدمات",
    link: "/",
    icon: <FormatPaintOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "وسایل شخصی",
    link: "/",
    icon: <WatchOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "سرگرمی و فراغت",
    link: "/",
    icon: <CasinoOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "اجتماعی",
    link: "/",
    icon: <PeopleOutlinedIcon className={styles.ad_icons} />,
  },
  {
    title: "تجهیزات و صنعتی",
    link: "/",
    icon: <HomeRepairServiceOutlinedIcon className={styles.ad_icons} />,
  },
];

const Category = (): JSX.Element => {
  return (
    <>
      <Box sx={{ margin: "1rem 0 2rem" }}>
        <Typography
          sx={{ fontSize: "1rem", fontWeight: "500", margin: "1rem" }}
        >
          دسته‌ها
        </Typography>
        <Grid container direction="column" alignItems="flex-start">
          {category.map((item, index) => (
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
          ))}
        </Grid>
        <Accordion sx={{ margin: "10px 0" }}>
          <AccordionSummary expandIcon={<ExpandMoreIcon />}>
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
        <Accordion>
          <AccordionSummary expandIcon={<ExpandMoreIcon />}>
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
      </Box>
    </>
  );
};

export default Category;
