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
              value
              style={{ width: "100%" }}
              placeholder="نقش زیر مجموعه را انتخاب کنید"
            >
              {roles.length === 0 ? (
                <Option key="loading">درحال بارگیری اطلاعات</Option>
              ) : (
                roles.map?.((role) => (
                  <Option key={role.id}>{role.title}</Option>
                ))
              )}
            </Select>
            <Input
              onChange={handleChange}
              name="name"
              placeholder="تغییر نام نقش"
            />
            {/* {selectedRolePerm && (
              <Select
                mode="multiple"
                allowClear
                style={{ width: "100%" }}
                placeholder="تغییر دسترسی"
              >
                {selectedRolePerm?.length === null ? (
                  <Option value="loading">درحال دریافت اطلاعات </Option>
                ) : (
                  allPermissions?.permissions?.map?.((item, index) => (
                    <Option key={item.id}>{item.title}</Option>
                  ))
                )}
              </Select>
            )} */}
            {selectedRolePerm && (
              <Select
                mode="multiple"
                allowClear
                style={{ width: "100%" }}
                placeholder="یک یا چند دسترسی انتخاب کنید"
              >
                {allPermissions.length === 0 ? (
                  <Option value="loading">درحال دریافت اطلاعات </Option>
                ) : (
                  allPermissions.map((item) => (
                    <OptGroup label={item.groupTitle}>
                      {item.permissions.map((subChild) => (
                        <Option value={subChild.id}>{subChild.title}</Option>
                      ))}
                    </OptGroup>
                  ))
                )}
              </Select>
            )}
            {selectedRolePerm && (
              <>
                <p>لیست دسترسی هایی که این نقش دارد: </p>
                <ul>
                  {selectedRolePerm?.permissions?.map?.((item) => (
                    <li>{item.title}</li>
                  ))}
                </ul>
              </>
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
