import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import React, { useState } from "react";
import styles from "../../../../styles/Dashboard.module.css";
import { InputOnChange, ManageCategoriesProps } from "../../../../types/type";

const { Option } = Select;

const NewCategory = ({ categories }: ManageCategoriesProps): JSX.Element => {
  const [category, setCategory] = useState({
    name: "",
    role: [""],
  });

  const handleChange = ({ target }: InputOnChange) => {
    return setCategory((data) => ({
      ...data,
      name: target.value,
    }));
  };

  // Render
  return (
    <>
      <Box sx={{ mt: 2 }}>
        <form>
          <Box className={styles.role__holder}>
            <Input
              onChange={handleChange}
              name="name"
              placeholder="نام دسته بندی جدید"
            />
            <Select
              mode="multiple"
              allowClear
              style={{ width: "100%" }}
              placeholder="زیر مجموعه های خود را وارد کنید"
            >
              <Option key={"salam1"}>Salam</Option>
              <Option key={"salam2"}>Salam</Option>
              <Option key={"salam3"}>Salam</Option>
            </Select>
            <Button style={{ width: "40%", marginTop: "1rem" }} type="primary">
              ثبت دسته بندی جدید
            </Button>
          </Box>
        </form>
      </Box>
    </>
  );
};

export default NewCategory;
