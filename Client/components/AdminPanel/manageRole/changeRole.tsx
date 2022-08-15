import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import React, { useState } from "react";
import styles from "../../../styles/Dashboard.module.css";
const { Option } = Select;

const ChangeRole = (): JSX.Element => {
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
              placeholder="نقش خود را انتخاب کنید"
            >
              <Option key={"salam1"}>Salam</Option>
              <Option key={"salam2"}>Salam</Option>
              <Option key={"salam3"}>Salam</Option>
            </Select>
            <Input
              onChange={handleChange}
              name="name"
              placeholder="تغییر نام نقش"
            />
            <Select
              mode="multiple"
              allowClear
              style={{ width: "100%" }}
              placeholder="یک یا چند دسترسی انتخاب کنید"
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
              type="primary"
            >
              ثبت تغییرات
            </Button>
          </Box>
        </form>
      </Box>
    </>
  );
};

export default ChangeRole;
