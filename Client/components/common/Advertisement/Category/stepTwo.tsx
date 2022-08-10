import { Box, Grid, Typography } from "@mui/material";
import styles from "../../../../styles/Advertisement.module.css";

const StepTwo = (): JSX.Element => {
  return (
    <Box sx={{ m: "5px", display: "flex", flexDirection: "column" }}>
      <Typography>املاک</Typography>
      <Box className="subchild" sx={{ mr: 3 }}>
        <Typography className={styles.subcategory__item}>
          فروش مسکونی
        </Typography>
        <Typography className={styles.subcategory__item}>
          فروش اداری و تجاری
        </Typography>
        <Typography className={styles.subcategory__item}>
          فروش اداری و تجاری
        </Typography>
      </Box>
    </Box>
  );
};

export default StepTwo;
