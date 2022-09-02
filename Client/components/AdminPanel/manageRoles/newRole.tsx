import { useState } from "react";
import { Box } from "@mui/material";
import { Input, Select, Button, Popconfirm } from "antd";
import { handleCreate as handleNewRole } from "../../../services/httpService";
import { NewRoleProps, NewRoleData, InputOnChange } from "../../../types/type";
import { toast } from "react-toastify";
import styles from "../../../styles/Dashboard.module.css";
import produce from "immer";

const { Option, OptGroup } = Select;

const NewRole = ({ permissions }: NewRoleProps): JSX.Element => {
  // Local State
  const [newRole, setNewRole] = useState<NewRoleData>({
    title: "",
    permissions: [],
  });
  // Event Handlers
  const handleName = ({ target }: InputOnChange) => {
    setNewRole(
      produce(newRole, (draftState) => {
        draftState.title = target.value;
      })
    );
  };

  const handleRoleChange = (roleId: number[]) => {
    setNewRole(
      produce(newRole, (draftState) => {
        draftState.permissions = roleId;
      })
    );
  };

  const handleSubmit = async () => {
    console.log("Handle Submit");
    if (newRole.title && newRole.permissions) {
      return await handleNewRole(
        "Roles",
        newRole,
        "نقش جدید با موفقیت ایجاد شد",
        "مشکلی در ایجاد نقش به وجود آمد"
      );
    }
    toast.error("لطفا اطلاعات مورد نیاز را پر کنید");
  };

  // Render
  return (
    <>
      <Box sx={{ mt: 2 }}>
        <form onSubmit={handleSubmit}>
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
                      <Option key={subChild.id} value={subChild.id}>
                        {subChild.title}
                      </Option>
                    ))}
                  </OptGroup>
                ))
              )}
            </Select>
            <Popconfirm
              title="از ایجاد این نقش مطمئن هستید؟"
              onConfirm={handleSubmit}
              okText="بله"
              cancelText="خیر"
            >
              <Button
                style={{ width: "30%", marginTop: "1rem" }}
                type="primary"
              >
                ثبت نقش جدید
              </Button>
            </Popconfirm>
          </Box>
        </form>
      </Box>
    </>
  );
};

export default NewRole;
