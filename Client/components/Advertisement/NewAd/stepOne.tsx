import { lazy, Suspense } from "react";
import { useSelector } from "react-redux";
import { Box, Grid, Typography } from "@mui/material";
import { ChevronLeft } from "@mui/icons-material";
import { StepsProp } from "../../../types/type";
import { selectStore } from "../../../store/state/ui";
import styles from "../../../styles/Advertisement.module.css";

const StepOne = ({ onNextStep }: StepsProp): JSX.Element => {
  // Redux Setup
  const { category } = useSelector(selectStore);
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
          <Box key={index}>{Category(item, onNextStep)}</Box>
        ))}
    </Box>
  );
};

export default StepOne;

const Category = (item: any, onNextStep: any) => {
  if (item.icon === null) return;

  const Icon = lazy(() =>
    import("@mui/icons-material").then((module: any) => ({
      default: module[item.icon],
    }))
  );

  return (
    <div>
      <Grid
        sx={{ m: "5px 0", cursor: "pointer" }}
        className="border-bottom"
        container
        direction="row"
        justifyContent="space-between"
        alignItems="center"
      >
        <Grid item onClick={() => onNextStep(item)}>
          <Grid spacing={2} container direction="row" alignItems="center">
            <Grid item>
              <Box>
                <Suspense fallback={<></>}>
                  <Icon className={styles.newAd_icon} />
                </Suspense>
              </Box>
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
    </div>
  );
};
