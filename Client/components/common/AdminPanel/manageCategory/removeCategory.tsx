import { Box, Button } from "@mui/material";
import { Select } from "antd";
import { useState } from "react";
import styles from "../../../../styles/Dashboard.module.css";
import { handleRemove as removeCategory } from "../../../../services/httpService"; // Renaming Import Function
import { ManageCategoriesProps } from "../../../../types/type";
const { Option } = Select;

const RemoveCategory = ({ categories }: ManageCategoriesProps): JSX.Element => {
  // Local State
  const [selectedCategory, setSelectedCategory] = useState<number | null>(null);

  // Event Handlers
  const handleChange = (value: number) => {
    setSelectedCategory(value);
  };

  const handleSubmit = (e: React.ChangeEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (selectedCategory) {
      removeCategory("category", selectedCategory);
    }
  };

  // Render
  return (
    <>
      <Box sx={{ mt: 2 }}>
        <form onSubmit={handleSubmit}>
          <Box className={styles.role__holder}>
            <Select
              onChange={handleChange}
              allowClear
              style={{ width: "100%" }}
              placeholder="دسته بندی خود را انتخاب کنید"
            >
              {categories.length === 0 ? (
                <Option key="loading">درحال بارگیری اطلاعات</Option>
              ) : (
                categories.map?.((ctg) => (
                  <Option key={ctg.id}>{ctg.title}</Option>
                ))
              )}
            </Select>
            <Button
              sx={{ width: "25%", marginTop: "1rem" }}
              type="submit"
              color="error"
              variant="contained"
              size="medium"
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
