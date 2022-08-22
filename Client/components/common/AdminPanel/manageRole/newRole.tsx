import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import React, { useState } from "react";
import styles from "../../../../styles/Dashboard.module.css";
import { NewRolePropos } from "../../../../types/type";

const { Option, OptGroup } = Select;

const NewRole = ({ permissions }: NewRolePropos): JSX.Element => {
  const [data, setData] = useState({
    name: "",
    role: [""],
  });
  const [selectedPermissions, setSelectedPermissions] = useState<string[] | []>(
    []
  );

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
              {permissions.length === 0 ? (
                <Option value="loading">درحال دریافت اطلاعات </Option>
              ) : (
                permissions.map((item) => (
                  <OptGroup label={item.groupTitle}>
                    {item.permissions.map((subChild) => (
                      <Option value={subChild.id}>{subChild.title}</Option>
                    ))}
                  </OptGroup>
                ))
              )}
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
