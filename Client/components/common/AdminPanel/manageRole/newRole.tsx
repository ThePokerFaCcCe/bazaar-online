import { useState } from "react";
import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import {
  NewRoleProps,
  NewRoleData,
  InputOnChange,
} from "../../../../types/type";
import produce from "immer";
import styles from "../../../../styles/Dashboard.module.css";

const { Option, OptGroup } = Select;

const NewRole = ({ permissions }: NewRoleProps): JSX.Element => {
  // Local State
  const [role, setRole] = useState<NewRoleData>({
    title: "",
    permissions: [],
  });
  // Event Handlers
  const handleName = ({ target }: InputOnChange) => {
    setRole(
      produce(role, (draftState) => {
        draftState.title = target.value;
      })
    );
  };

  const handleRoleChange = (roleId: number[]) => {
    setRole(
      produce(role, (draftState) => {
        draftState.permissions = roleId;
      })
    );
  };
  // Render
  return (
    <>
      <Box sx={{ mt: 2 }}>
        <form>
          <Box className={styles.role__holder}>
            <Input onChange={handleName} placeholder="نام نقش جدید" />
            <Select
              mode="multiple"
              allowClear
              style={{ width: "100%" }}
              dropdownMatchSelectWidth={false}
              placeholder="یک یا چند دسترسی انتخاب کنید"
              onChange={handleRoleChange}
            >
              {permissions.length === 0 ? (
                <Option value="loading">درحال دریافت اطلاعات </Option>
              ) : (
                permissions.map((item, index) => (
                  <OptGroup key={index} label={item.groupTitle}>
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
