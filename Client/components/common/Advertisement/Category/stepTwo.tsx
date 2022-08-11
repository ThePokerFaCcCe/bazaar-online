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
import { CategoryStepTwoProps } from "../../../../types/type";

const StepTwo = ({ selectedCategory }: CategoryStepTwoProps): JSX.Element => {
  // Icons
  function Icons() {
    switch (selectedCategory.title) {
      case "املاک":
        return <HouseOutlined className={styles.ad_icons} />;
      case "وسایل نقلیه":
        return <DirectionsCarFilledOutlined className={styles.ad_icons} />;
      case "کالای دیجیتال":
        return <PhoneIphoneOutlined className={styles.ad_icons} />;
      case "خانه و آشپزخانه":
        return <BlenderOutlined className={styles.ad_icons} />;
      case "خدمات":
        return <FormatPaintOutlined className={styles.ad_icons} />;
      case "وسایل شخصی":
        return <WatchOutlined className={styles.ad_icons} />;
      case "سرگرمی و فراغت":
        return <CasinoOutlined className={styles.ad_icons} />;
      case "اجتماعی":
        return <PeopleOutlined className={styles.ad_icons} />;
      case "تجهیزات و صنعتی":
        return <HomeRepairServiceOutlined className={styles.ad_icons} />;
      case "استخدام و کاریابی":
        return <WorkOutline className={styles.ad_icons} />;
    }
  }

  // Render
  return (
    <Box className="d-flex flex-column">
      <Row gutter={[5, 0]} align="middle">
        <Col>{Icons()}</Col>
        <Col>
          <Typography
            className={styles.category__item}
            style={{ margin: "0 !important", fontWeight: "bold" }}
          >
            {selectedCategory.title}
          </Typography>
        </Col>
      </Row>
      <Box marginRight={3}>
        {selectedCategory?.children?.map((item) => (
          <Typography className={styles.subcategory__item}>
            {item.title}
          </Typography>
        ))}
      </Box>
    </Box>
  );
};

export default StepTwo;
