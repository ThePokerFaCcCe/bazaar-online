import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import React, { useState } from "react";
import styles from "../../../../styles/Dashboard.module.css";
import { InputOnChange, ManageCategoriesProps } from "../../../../types/type";

const { Option } = Select;

// Event Handler
const NewCategory = ({ categories }: ManageCategoriesProps): JSX.Element => {
  const [newCategory, setNewCategory] = useState({
    name: "",
    role: [""],
  });

  const handleChange = ({ target }: InputOnChange) => {
    return setNewCategory((data) => ({
      ...data,
      name: target.value,
    }));
  };
  // Todo
  // New Category SCHEMA
  // {
  //   "title": "string",
  //   "icon": "string",
  //   "parentId": 0,
  //   "children": [
  //     {
  //       "title": "string",
  //       "icon": "string"
  //     }
  //   ]
  // }

  // const handleSubmit = () => {
  //   if (newCategory.name && newCategory.role) {
  //     return await handleNewRole(
  //       "Roles",
  //       newRole,
  //       "نقش جدید با موفقیت ایجاد شد",
  //       "مشکلی در ایجاد نقش به وجود آمد"
  //     );
  //   }
  //   toast.error("لطفا اطلاعات مورد نیاز را پر کنید");
  // };

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
              {categories.map((ctg) => (
                <Option key={ctg.id}>{ctg.title}</Option>
              ))}
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
