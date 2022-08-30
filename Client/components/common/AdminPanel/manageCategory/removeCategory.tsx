import { Box } from "@mui/material";
import { Select, Popconfirm, Button } from "antd";
import { useState } from "react";
import { handleRemove as removeCategory } from "../../../../services/httpService"; // Renaming Import Function
import { ManageCategoriesProps } from "../../../../types/type";
import { toast } from "react-toastify";
import styles from "../../../../styles/Dashboard.module.css";

const { Option } = Select;

const RemoveCategory = ({ categories }: ManageCategoriesProps): JSX.Element => {
  // Local State
  const [selectedCategory, setSelectedCategory] = useState<number | null>(null);

  // Event Handlers
  const handleChange = (value: number) => {
    setSelectedCategory(value);
  };

  const handleSubmit = () => {
    if (selectedCategory) {
      return removeCategory("category", selectedCategory);
    }
    return toast.error("هیچ دسته بندی انتخاب نکردید");
  };

  // Render
  return (
    <>
      <Box sx={{ mt: 2 }}>
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
          <Popconfirm
            title="از حذف این دسته بندی مطمئن هستید؟"
            onConfirm={handleSubmit}
            okText="بله"
            cancelText="خیر"
          >
            <Button danger type="primary" className={styles.deleteButton}>
              حذف
            </Button>
          </Popconfirm>
        </Box>
      </Box>
    </>
  );
};

export default RemoveCategory;
