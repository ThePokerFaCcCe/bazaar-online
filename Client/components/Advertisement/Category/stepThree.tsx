import { lazy, Suspense } from "react";
import { Box, Typography } from "@mui/material";
import { Col, Row } from "antd";
import { CategoryStepThreeProps } from "../../../../types/type";
import styles from "../../../../styles/Advertisement.module.css";

const StepThree = ({
  selectedChildren,
  selectedCategory,
}: CategoryStepThreeProps): JSX.Element => {
  // Render
  return (
    <Box className="d-flex flex-column">
      <Row gutter={[5, 0]} align="middle">
        <Col>{Icons(selectedCategory.icon)}</Col>
        <Col>
          <Typography className={styles.subCategory__header}>
            {selectedCategory.title}
          </Typography>
        </Col>
      </Row>
      <Typography
        className={styles.subCategory__header}
        sx={{ mr: 3, fontSize: "14px" }}
      >
        {selectedChildren.title}
      </Typography>
      <Box
        sx={{
          m: "0.5rem 2.5rem 0.5rem 0 ",
          borderRight: "1px solid #ccc",
          pr: "5px",
        }}
      >
        {selectedChildren?.children?.map((item) => (
          <Typography className={styles.subCategory__text}>
            {item.title}
          </Typography>
        ))}
      </Box>
    </Box>
  );
};

export default StepThree;

function Icons(icon: string | null) {
  if (icon) {
    const MuiIcon = lazy(() =>
      import("@mui/icons-material").then((module: any) => ({
        default: module[icon],
      }))
    );

    return (
      <Suspense fallback={<></>}>
        <MuiIcon className={styles.newAd_icon} />
      </Suspense>
    );
  }
}
