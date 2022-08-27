import { Box } from "@mui/material";
import { Input, Button } from "antd";
import axios from "axios";
import { useEffect, useState } from "react";
import { useRouter } from "next/router";
import { DashboardUserPage } from "../../../../types/type";

const User = (): JSX.Element => {
  // Local State
  const [user, setUser] = useState<DashboardUserPage | null>(null);
  //
  const { asPath, back } = useRouter();
  const index = asPath.lastIndexOf("/");
  const userId = asPath.slice(index + 1);

  useEffect(() => {
    async function getUser() {
      const { data } = await axios.get(
        `http://localhost:5066/api/Users/${userId}`
      );
      setUser(data);
    }
    getUser();
  }, []);

  return user ? (
    <Box>
      <div style={{ position: "relative", marginTop: "2rem" }}>
        <div className="d-flex justify-content-center align-items-center">
          <h3>اطلاعات کاربر</h3>
          <button
            onClick={() => back()}
            style={{
              position: "absolute",
              left: 0,
              top: 0,
              marginLeft: "3rem",
            }}
            className="btn-sm btn btn-primary"
          >
            بازگشت
          </button>
        </div>
      </div>
      <Box
        sx={{
          mt: "2rem",
          padding: "0 20%",
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
          gap: "1rem",
        }}
      >
        <div style={{ width: "100%" }}>
          <label style={{ marginBottom: "5px" }} htmlFor="">
            نام
          </label>
          <Input defaultValue={user.fullName} placeholder="نام" />
        </div>
        <div style={{ width: "100%" }}>
          <label style={{ marginBottom: "5px" }} htmlFor="">
            ایمیل
          </label>
          <Input defaultValue={user.email} placeholder="ایمیل" />
        </div>
        <div style={{ width: "100%" }}>
          <label style={{ marginBottom: "5px" }} htmlFor="">
            شماره موبایل
          </label>
          <Input defaultValue={user.phoneNumber} placeholder="شماره موبایل" />
        </div>
        <div style={{ width: "100%" }}>
          <label style={{ marginBottom: "5px" }} htmlFor="">
            کلمه عبور جدید
          </label>
          <Input placeholder="کلمه عبور جدید" />
        </div>
        <Button style={{ width: "20%" }} type="primary">
          ثبت تغییرات
        </Button>
      </Box>
    </Box>
  ) : (
    <Box
      sx={{ display: "flex", justifyContent: "center", alignItems: "center" }}
    >
      <h3>در حال دریافت اطلاعات</h3>
    </Box>
  );
};

export default User;
