import { Box } from "@mui/material";
import { Input, Button } from "antd";

function User() {
  return (
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
      <h3>اطلاعات کاربر</h3>
      <div style={{ width: "100%" }}>
        <label style={{ marginBottom: "5px" }} htmlFor="">
          نام
        </label>
        <Input placeholder="نام" />
      </div>
      <div style={{ width: "100%" }}>
        <label style={{ marginBottom: "5px" }} htmlFor="">
          نام خانوادگی
        </label>
        <Input placeholder="نام خانوادگی" />
      </div>
      <div style={{ width: "100%" }}>
        <label style={{ marginBottom: "5px" }} htmlFor="">
          ایمیل
        </label>
        <Input placeholder="ایمیل" />
      </div>
      <div style={{ width: "100%" }}>
        <label style={{ marginBottom: "5px" }} htmlFor="">
          شماره موبایل
        </label>
        <Input placeholder="شماره موبایل" />
      </div>
      <div style={{ width: "100%" }}>
        <label style={{ marginBottom: "5px" }} htmlFor="">
          کلمه عبور
        </label>
        <Input placeholder="کلمه عبور" />
      </div>
      <Button style={{ width: "10%", padding: "1rem" }} type="primary">
        ثبت تغییرات
      </Button>
    </Box>
  );
}

export default User;
