import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import React, { useState } from "react";
import styles from "../../../styles/Dashboard.module.css";
const { Option } = Select;

const RemoveCategory = (): JSX.Element => {
  const [data, setData] = useState({
    name: "",
    role: [""],
  });

  const handleChange = ({ target }: React.ChangeEvent<HTMLInputElement>) => {
    return setData((data) => ({
      ...data,
      name: target.value,
    }));
  };

  return (
    <>
      <Box sx={{ mt: 2 }}>
        <form>
          <Box className={styles.role__holder}>
            <Select
              allowClear
              style={{ width: "100%" }}
              placeholder="دسته بندی خود را انتخاب کنید"
            >
              <Option key={"salam1"}>Salam</Option>
              <Option key={"salam2"}>Salam</Option>
              <Option key={"salam3"}>Salam</Option>
            </Select>
            <Button
              style={{
                width: "30%",
                marginTop: "1rem",
              }}
              danger
              type="primary"
            >
              حذف
            </Button>
          </Box>
        </form>
      </Box>
    </>
  );
};

export default RemoveCategory;
