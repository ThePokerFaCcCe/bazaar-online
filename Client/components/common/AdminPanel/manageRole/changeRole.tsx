import { Box } from "@mui/material";
import { Input, Select, Button } from "antd";
import axios from "axios";
import React, { useState, useEffect } from "react";
import {
  getFeaturesList,
  getRolePermissions,
} from "../../../../services/httpService";
import styles from "../../../../styles/Dashboard.module.css";
import { ChangeRoleProps } from "../../../../types/type";
const { Option, OptGroup } = Select;

type RolePerm = {
  id: number;
  permissions: { id: string; title: string }[];
  roleTitle: string;
}[];

const ChangeRole = ({
  roles,
  permissions: allPermissions,
}: ChangeRoleProps): JSX.Element => {
  // Local State
  const [data, setData] = useState({
    name: "",
    role: [""],
  });
  const [selectedRole, setSelectedRole] = useState<number | null>(null);
  const [selectedRolePerm, setSelectedRolePerm] = useState<RolePerm | null>(
    null
  );

  // Event Handler
  const handleChange = ({ target }: React.ChangeEvent<HTMLInputElement>) => {
    return setData((data) => ({
      ...data,
      name: target.value,
    }));
  };

  // CDM
  // TODO List Dastrsi Hayi ke dare ro beriz to araye
  useEffect(() => {
    getRolePermissions(selectedRole, setSelectedRolePerm);
    getFeaturesList();
  }, [selectedRole]);

  // Render
  return (
    <>
      <Box sx={{ mt: 2 }}>
        <form>
          <Box className={styles.role__holder}>
            <Select
              onChange={(value) => setSelectedRole(value)}
              allowClear
              style={{ width: "100%" }}
              placeholder="نقش زیر مجموعه را انتخاب کنید"
            >
              {roles.length === 0 ? (
                <Option key="loading">درحال بارگیری اطلاعات</Option>
              ) : (
                roles.map?.((role) => (
                  <Option key={role.id.toString()}>{role.title}</Option>
                ))
              )}
            </Select>
            <Input
              onChange={handleChange}
              name="name"
              placeholder="تغییر نام نقش"
            />
            {selectedRolePerm && (
              <Select
                mode="multiple"
                allowClear
                defaultValue={["1", "2", "3"]}
                style={{ maxWidth: "100%" }}
                placeholder="یک یا چند دسترسی انتخاب کنید"
              >
                {allPermissions.length === 0 ? (
                  <Option value="loading">درحال دریافت اطلاعات </Option>
                ) : (
                  allPermissions.map((item) => (
                    <OptGroup label={item.groupTitle}>
                      {item.permissions.map((subChild) => (
                        <Option value={subChild.id.toString()}>
                          {subChild.title}
                        </Option>
                      ))}
                    </OptGroup>
                  ))
                )}
              </Select>
            )}

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

export default ChangeRole;
