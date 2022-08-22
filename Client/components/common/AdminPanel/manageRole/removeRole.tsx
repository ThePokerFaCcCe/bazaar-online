import { Box, Button } from "@mui/material";
import { Select } from "antd";
import { useState } from "react";
import { handleRemove as removeRole } from "../../../../services/httpService"; // Renaming Import Function
import styles from "../../../../styles/Dashboard.module.css";
import { RolePagesProps } from "../../../../types/type";
const { Option } = Select;

const RemoveRole = ({ roles }: RolePagesProps): JSX.Element => {
  // Local State
  const [selectedRole, setSelectedRole] = useState<number | null>(null);
  // Event Handlers
  const handleChange = (value: number) => {
    setSelectedRole(value);
  };

  const handleSubmit = (e: React.ChangeEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (selectedRole) {
      removeRole("roles", selectedRole);
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
              placeholder="نقش خود را انتخاب کنید"
            >
              {roles.length === 0 ? (
                <Option key="loading">درحال بارگیری اطلاعات</Option>
              ) : (
                roles.map((role) => <Option key={role.id}>{role.title}</Option>)
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

export default RemoveRole;
