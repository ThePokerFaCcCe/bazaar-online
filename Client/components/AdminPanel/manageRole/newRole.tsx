import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import React, { useState } from "react";
import styles from "../../../styles/Dashboard.module.css";

const { Option } = Select;

const NewRole = (): JSX.Element => {
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
            <Input
              onChange={handleChange}
              name="name"
              placeholder="نام نقش جدید"
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
            <Button style={{ width: "30%", marginTop: "1rem" }} type="primary">
              ثبت نقش جدید
            </Button>
          </Box>
        </form>
      </Box>
    </>
  );
};

export default NewRole;
