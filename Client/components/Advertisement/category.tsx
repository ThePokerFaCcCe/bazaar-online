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
  ArrowForward,
  ExpandMore,
  WorkOutline,
} from "@mui/icons-material";
import { Input } from "antd";
import { Store } from "../../../types/type";
import { useState } from "react";
import { useSelector } from "react-redux";
import styles from "../../../styles/Advertisement.module.css";
import StepOne from "./Category/stepOne";
import StepTwo from "./Category/stepTwo";
import StepThree from "./Category/stepThree";
const Category = (): JSX.Element => {
  // Redux Setup
  const { category: categories } = useSelector(
    (state: Store) => state.entities
  );
  // Local Setup
  const [step, setStep] = useState(1);
  const [selectedCategory, setSelectedGenre] = useState<any>(null);
  const [selectedChildren, setSelectChildren] = useState<any>(null);
  // Event Handler

  const handleSelectCategory = (category: any): void => {
    if (step === 1) {
      setSelectedGenre(category);
    }
    if (step === 2) {
      setSelectChildren(category);
    }
    setStep(step + 1);
  };
  console.log(selectedCategory, selectedChildren);

  // Handle Step
  const StepToShow = (): JSX.Element => {
    switch (step) {
      case 2:
        return (
          <StepTwo
            onSelectCategory={handleSelectCategory}
            selectedCategory={selectedCategory}
          />
        );
      case 3:
        return (
          <StepThree
            selectedCategory={selectedCategory}
            selectedChildren={selectedChildren}
            onSelectCategory={handleSelectCategory}
          />
        );
      default:
        return (
          <StepOne onSelectCategory={handleSelectCategory} icons={icons} />
        );
    }
  };

  // Render
  return (
    <>
      <Box sx={{ margin: "1rem 1rem 2rem" }}>
        <Typography
          sx={{ fontSize: "1rem", fontWeight: "500", margin: "1rem" }}
        >
          دسته‌ها
        </Typography>
        {step !== 1 && (
          <Grid
            container
            onClick={() => setStep(1)}
            sx={{ cursor: "pointer" }}
            direction="row"
            alignItems="center"
          >
            <Grid item>
              <ArrowForward className={styles.icons} />
            </Grid>
            <Grid item>
              <Typography
                sx={{
                  fontSize: "12px",
                  fontWeight: "500",
                  p: "10px 0",
                  color: "rgba(0, 0, 0, 0.56)",
                }}
              >
                همه آگهی ها
              </Typography>
            </Grid>
          </Grid>
        )}
        <Grid container direction="column" alignItems="flex-start">
          {StepToShow()}
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
    </>
  );
};

export default Category;

var icons: JSX.Element[] = [
  <HouseOutlined className={styles.ad_icons} />,
  <DirectionsCarFilledOutlined className={styles.ad_icons} />,
  <PhoneIphoneOutlined className={styles.ad_icons} />,
  <BlenderOutlined className={styles.ad_icons} />,
  <FormatPaintOutlined className={styles.ad_icons} />,
  <WatchOutlined className={styles.ad_icons} />,
  <CasinoOutlined className={styles.ad_icons} />,
  <PeopleOutlined className={styles.ad_icons} />,
  <HomeRepairServiceOutlined className={styles.ad_icons} />,
  <WorkOutline className={styles.ad_icons} />,
];
