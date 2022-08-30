import { Box } from "@mui/material";
import { Select, Popconfirm, Button } from "antd";
import { useState } from "react";
import { handleRemove as removeRole } from "../../../../services/httpService"; // Renaming Import Function
import { toast } from "react-toastify";
import { RolePagesProps } from "../../../../types/type";
import styles from "../../../../styles/Dashboard.module.css";

const { Option } = Select;

const RemoveRole = ({ roles }: RolePagesProps): JSX.Element => {
  // Local State
  const [selectedRole, setSelectedRole] = useState<number | null>(null);
  // Event Handlers
  const handleRoleChange = (value: number) => {
    setSelectedRole(value);
  };

  const handleSubmit = () => {
    if (selectedRole) {
      removeRole("roles", selectedRole);
    } else {
      toast.error("نقشی انتخاب نکردید");
    }
  };

  // Render
  return (
    <>
      <Box sx={{ mt: 2 }}>
        <Box className={styles.role__holder}>
          <Select
            onChange={handleRoleChange}
            allowClear
            style={{ width: "100%" }}
            placeholder="نقش خود را انتخاب کنید"
          >
            {roles.length === 0 ? (
              <Option key="loading">درحال بارگیری اطلاعات</Option>
            ) : (
              roles.map((role) => <Option key={role.id}>{role.title}</Option>)
            )}
          </Select>
          <Popconfirm
            title="از حذف این نقش مطمئن هستید؟"
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

export default RemoveRole;
