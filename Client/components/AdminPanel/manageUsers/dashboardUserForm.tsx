import { Box, Grid } from "@mui/material";
import { Button, Popconfirm } from "antd";
import { useRouter } from "next/router";
import { DashboardUserFormProps } from "../../../../types/type";
import DashboardInput from "./dashboardInput";
import DashboardCheckbox from "./dashboardCheckbox";

const DashboardUserForm = ({
  user,
  onHandleChange,
  onCheckboxChange,
  onModify,
  onDelete,
}: DashboardUserFormProps) => {
  const { back } = useRouter();

  return (
    <Box>
      <div style={{ position: "relative", marginTop: "2rem" }}>
        <div className="d-flex justify-content-center align-items-center">
          <h3>اطلاعات کاربر</h3>
          <Button
            onClick={() => back()}
            style={{
              position: "absolute",
              left: 0,
              top: 0,
              marginLeft: "3rem",
            }}
            type="primary"
          >
            بازگشت
          </Button>
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
        <DashboardInput
          value={user.firstName}
          name="firstName"
          onChange={onHandleChange}
          placeholder="نام"
        />
        <DashboardInput
          value={user.lastName}
          name="lastName"
          onChange={onHandleChange}
          placeholder="نام خانوادگی"
        />
        <DashboardInput
          name="email"
          value={user.email}
          onChange={onHandleChange}
          placeholder="ایمیل"
        />
        <DashboardInput
          name="phoneNumber"
          value={user.phoneNumber}
          onChange={onHandleChange}
          placeholder="شماره موبایل"
        />
        <DashboardInput
          name="password"
          value={user.password}
          onChange={onHandleChange}
          placeholder="کلمه عبور جدید"
        />
        <DashboardCheckbox
          title="وضعیت کاربر؟"
          name="isActive"
          defaultChecked={user.isActive}
          conditionAndTxt={user.isActive ? "فعال" : "غیرفعال"}
          onChange={onCheckboxChange}
        />
        <div style={{ width: "100%" }}>
          <span>تاریخ ثبت نام: </span>
          <span>{new Date(user.createDate).toLocaleDateString("fa-IR")}</span>
        </div>
        <Grid
          container
          justifyContent="center"
          alignItems="center"
          spacing={[10]}
          marginBottom="3rem"
        >
          <Grid item>
            <Popconfirm
              title="از ذخیره تغییرات مطمئن هستید؟"
              onConfirm={onModify}
              okText="بله"
              cancelText="خیر"
            >
              <Button type="primary">ثبت تغییرات</Button>
            </Popconfirm>
          </Grid>
          <Grid item>
            <Popconfirm
              title="از حذف این کاربر مطمئن هستید؟"
              onConfirm={onDelete}
              okText="بله"
              cancelText="خیر"
            >
              <Button danger type="primary">
                حذف کاربر
              </Button>
            </Popconfirm>
          </Grid>
        </Grid>
      </Box>
    </Box>
  );
};

export default DashboardUserForm;
