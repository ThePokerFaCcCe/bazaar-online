import { Box, Grid } from "@mui/material";
import { Button, Popconfirm } from "antd";
import { useState } from "react";
import { useRouter } from "next/router";
import { DashboardUserPage, DashboardUserProps } from "../../../../types/type";
import { GetServerSideProps } from "next";
import {
  changeUserInfo,
  deleteUser,
  handleExpectedError,
} from "../../../../services/httpService";
import { CheckboxChangeEvent } from "antd/lib/checkbox";
import DashboardCheckbox from "../../../../components/common/AdminPanel/manageUsers/dashboardCheckbox";
import DashboardInput from "../../../../components/common/AdminPanel/manageUsers/DashboardInput";
import Forbidden from "../../../../components/common/AdminPanel/forbidden";
import produce from "immer";
import axios from "axios";
import nookies from "nookies";

const User = ({ user: userObj, error }: DashboardUserProps): JSX.Element => {
  // Local State
  const [user, setUser] = useState<DashboardUserPage>(userObj);
  const { back } = useRouter();

  // EventHander
  const handleChange = ({ target }: React.ChangeEvent<HTMLInputElement>) => {
    const { name: n, value } = target;
    if (
      n === "email" ||
      n === "fullName" ||
      n === "phoneNumber" ||
      n === "password"
    ) {
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
  return (
    <>
      {error ? (
        <Forbidden />
      ) : (
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
              name="password"
              value={user.password}
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
            <div style={{ width: "100%" }}>
              <span>تاریخ ثبت نام: </span>
              <span>
                {new Date(user.createDate).toLocaleDateString("fa-IR")}
              </span>
            </div>
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
      )}
    </>
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
  try {
    const { data: user } = await axios.get(
      `http://localhost:5066/api/Users/${context?.params?.id}`,
      header
    );

    return {
      props: {
        user,
      },
    };
  } catch (ex) {
    return {
      props: {
        error: "error",
      },
    };
  }
};
