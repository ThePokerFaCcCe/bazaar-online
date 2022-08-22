import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import { useState } from "react";
import styles from "../../../../styles/Dashboard.module.css";
import { ManageCategoriesProps } from "../../../../types/type";
const { Option } = Select;

const ChangeCategory = ({ categories }: ManageCategoriesProps): JSX.Element => {
  const [selectedCategory, setSelectedCategory] = useState<string | null>(null);
  const [ctgNewName, setNewCtgName] = useState("");

  const handleChange = (value: string) => {
    setSelectedCategory(value);
  };

  const handleSubmit = (e: React.ChangeEvent<HTMLFormElement>) => {
    e.preventDefault();
    // Do the changes
  };

  return (
    <>
      <Box sx={{ mt: 2 }}>
        <form>
          <Box className={styles.role__holder}>
            <Select
              onChange={handleChange}
              allowClear
              style={{ width: "100%" }}
              placeholder="دسته بندی خود را انتخاب کنید"
            >
              {categories.length === 0 ? (
                <Option key="loading">در حال بارگیری اطلاعات</Option>
              ) : (
                categories.map((item) => (
                  <Option key={item.id}>{item.title}</Option>
                ))
              )}
            </Select>
            <Input
              onChange={(e) => setNewCtgName(e.target.value)}
              name="name"
              placeholder="تغییر نام دسته بندی"
            />
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

export default ChangeCategory;
