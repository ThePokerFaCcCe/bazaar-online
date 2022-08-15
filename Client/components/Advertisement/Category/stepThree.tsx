import { Box, Typography } from "@mui/material";
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
  WorkOutline,
} from "@mui/icons-material";
import styles from "../../../../styles/Advertisement.module.css";
import { Col, Row } from "antd";
import { CategoryStepThreeProps } from "../../../../types/type";

const StepThree = ({
  selectedChildren,
  selectedCategory,
}: CategoryStepThreeProps): JSX.Element => {
  // Icons
  function Icons() {
    switch (selectedCategory.title) {
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

  // Render
  return (
    <Box className="d-flex flex-column">
      <Row gutter={[5, 0]} align="middle">
        <Col>{Icons()}</Col>
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
