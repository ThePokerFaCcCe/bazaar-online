import { lazy, Suspense } from "react";
import { Box, Typography } from "@mui/material";
import { Col, Row } from "antd";
import { CategoryStepTwoProps } from "../../../../types/type";
import styles from "../../../../styles/Advertisement.module.css";

const StepTwo = ({
  selectedCategory,
  onSelectCategory,
}: CategoryStepTwoProps): JSX.Element => {
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
      <Box marginRight={7}>
        {selectedCategory?.children?.map((item, index) => (
          <Typography
            key={index}
            onClick={() => onSelectCategory(item)}
            className={styles.subCategory__text}
          >
            {item.title}
          </Typography>
        ))}
      </Box>
    </Box>
  );
};

export default StepTwo;

// Import Dynamic Icons
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
