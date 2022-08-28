import { Box, Grid } from "@mui/material";
import { Input, Button, Popconfirm, Checkbox } from "antd";
import axios from "axios";
import { useState } from "react";
import { useRouter } from "next/router";
import { DashboardUserPage, DashboardUserProps } from "../../../../types/type";
import produce from "immer";
import { GetServerSideProps } from "next";
import nookies from "nookies";
import {
  changeUserInfo,
  deleteUser,
  handleExpectedError,
} from "../../../../services/httpService";
import { CheckboxChangeEvent } from "antd/lib/checkbox";
import DashboardCheckbox from "../../../../components/common/AdminPanel/manageUsers/dashboardCheckbox";
import DashboardInput from "../../../../components/common/AdminPanel/manageUsers/DashboardInput";

const User = ({ user: userObj }: DashboardUserProps): JSX.Element => {
  // Local State
  const [user, setUser] = useState<DashboardUserPage>(userObj);
  //
  const { back } = useRouter();
  console.log("USER", user);
  // EventHander
  const handleChange = ({ target }: React.ChangeEvent<HTMLInputElement>) => {
    const { name: n, value } = target;
    if (n === "email" || n === "fullName" || n === "phoneNumber") {
      user &&
        setUser(
          produce(user, (draftState) => {
            draftState[n] = value;
          })
        );
    }
  };

  const handleCheckbox = ({ target }: CheckboxChangeEvent) => {
    const { name: n, checked } = target;
    if (n === "isActive" || n === "isDeleted" || n === "isEmailActive") {
      user &&
        setUser(
          produce(user, (draftState) => {
            draftState[n] = checked;
          })
        );
    }
  };

  const handleModify = async () => {
    try {
      await changeUserInfo(user.id, user);
    } catch ({ response }) {
      console.log(response);
      handleExpectedError(response);
    }
  };

  const handleDelete = async () => {
    try {
      await deleteUser(user.id);
    } catch ({ response }) {
      handleExpectedError(response);
    }
  };

  // Render

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
        <DashboardInput
          value={user.fullName}
          name="fullName"
          onChange={handleChange}
          placeholder="نام"
        />
        <DashboardInput
          name="email"
          value={user.email}
          onChange={handleChange}
          placeholder="ایمیل"
        />
        <DashboardInput
          name="phoneNumber"
          value={user.phoneNumber}
          onChange={handleChange}
          placeholder="شماره موبایل"
        />
        <DashboardInput
          name="phoneNumber"
          value={user.phoneNumber}
          onChange={handleChange}
          placeholder="کلمه عبور جدید"
        />
        <DashboardCheckbox
          title="وضعیت کاربر؟"
          name="isActive"
          defaultChecked={user.isActive}
          conditionAndTxt={user.isActive ? "فعال" : "غیرفعال"}
          onChange={handleCheckbox}
        />
        <DashboardCheckbox
          title="ایمیل کاربر تایید شده است؟"
          name="isEmailActive"
          defaultChecked={user.isEmailActive}
          conditionAndTxt={user.isEmailActive ? "تایید شده" : "تایید نشده"}
          onChange={handleCheckbox}
        />
        <DashboardCheckbox
          title="کاربر حذف شده است؟"
          name="isDeleted"
          defaultChecked={user.isDeleted}
          conditionAndTxt={user.isDeleted ? "حذف شده" : "حذف نشده"}
          onChange={handleCheckbox}
        />
        <Grid
          container
          justifyContent="center"
          alignItems="center"
          spacing={[10]}
        >
          <Grid item>
            <Popconfirm
              title="از ذخیره تغییرات مطمئن هستید؟"
              onConfirm={handleModify}
              okText="بله"
              cancelText="خیر"
            >
              <Button type="primary">ثبت تغییرات</Button>
            </Popconfirm>
          </Grid>
          <Grid item>
            <Popconfirm
              title="از حذف این کاربر مطمئن هستید؟"
              onConfirm={handleDelete}
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
  ) : (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        mt: 5,
      }}
    >
      <h3>در حال دریافت اطلاعات</h3>
    </Box>
  );
};

export default User;

export const getServerSideProps: GetServerSideProps = async (context) => {
  const { token } = nookies.get(context);
  const header = {
    headers: {
      "Content-Type": "application/json",
      Authorization: `bearer ${token}`,
    },
  };
  // api call
  const { data: user } = await axios.get(
    `http://localhost:5066/api/Users/${context?.params?.id}`,
    header
  );

  return {
    props: {
      user,
    },
  };
};
