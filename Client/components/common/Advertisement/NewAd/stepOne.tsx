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
  WorkOutline,
} from "@mui/icons-material";
import { StepsProp } from "../../../../types/type";
import { useSelector } from "react-redux";
import styles from "../../../../styles/Advertisement.module.css";
import { selectStore } from "../../../../store/state/ui";
const StepOne = ({ onNextStep }: StepsProp): JSX.Element => {
  // Redux Setup
  const { category } = useSelector(selectStore);

  function Icons(title: string) {
    switch (title) {
      case "املاک":
        return <HouseOutlined className={styles.stepTwo_icon} />;
      case "وسایل نقلیه":
        return <DirectionsCarFilledOutlined className={styles.stepTwo_icon} />;
      case "کالای دیجیتال":
        return <PhoneIphoneOutlined className={styles.stepTwo_icon} />;
      case "خانه و آشپزخانه":
        return <BlenderOutlined className={styles.stepTwo_icon} />;
      case "خدمات":
        return <FormatPaintOutlined className={styles.stepTwo_icon} />;
      case "وسایل شخصی":
        return <WatchOutlined className={styles.stepTwo_icon} />;
      case "سرگرمی و فراغت":
        return <CasinoOutlined className={styles.stepTwo_icon} />;
      case "اجتماعی":
        return <PeopleOutlined className={styles.stepTwo_icon} />;
      case "تجهیزات و صنعتی":
        return <HomeRepairServiceOutlined className={styles.stepTwo_icon} />;
      case "استخدام و کاریابی":
        return <WorkOutline className={styles.stepTwo_icon} />;
    }
  }

  return (
    <Box className="NewAd">
      <Grid
        sx={{ mb: "0.3rem" }}
        container
        direction="column"
        alignItems="start"
      >
        <Typography sx={{ fontSize: "20px", fontWeight: "500", mb: "5px" }}>
          ثبت آگهی
        </Typography>
        <Typography className="text-muted" sx={{ fontSize: "12px" }}>
          انتخاب دسته‌بندی
        </Typography>
      </Grid>
      {category &&
        category?.map((item, index) => (
          <Grid
            sx={{ m: "5px 0", cursor: "pointer" }}
            className="border-bottom"
            key={index}
            container
            direction="row"
            justifyContent="space-between"
            alignItems="center"
          >
            <Grid item onClick={() => onNextStep(item)}>
              <Grid spacing={2} container direction="row" alignItems="center">
                <Grid item>
                  <Box>{Icons(item.title)}</Box>
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
};

export default StepOne;
