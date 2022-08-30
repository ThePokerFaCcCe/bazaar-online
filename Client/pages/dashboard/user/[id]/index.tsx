import { useState } from "react";
import { DashboardUserPage, DashboardUserProps } from "../../../../types/type";
import { GetServerSideProps } from "next";
import {
  changeUserInfo,
  deleteUser,
  handleExpectedError,
} from "../../../../services/httpService";
import { InputOnChange } from "../../../../types/type";
import { CheckboxChangeEvent } from "antd/lib/checkbox";
import Forbidden from "../../../../components/common/AdminPanel/forbidden";
import DashboardUserForm from "../../../../components/common/AdminPanel/manageUsers/dashboardUserForm";
import produce from "immer";
import axios from "axios";
import nookies from "nookies";
import config from "../../../../config.json";

const User = ({ user: userObj, error }: DashboardUserProps): JSX.Element => {
  //
  // Local State
  const [user, setUser] = useState<DashboardUserPage>(userObj);

  // EventHander
  const handleChange = ({ target }: InputOnChange) => {
    const { name: n, value } = target;
    if (
      n === "email" ||
      n === "firstName" ||
      n === "lastName" ||
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
        <DashboardUserForm
          user={user}
          onDelete={handleDelete}
          onModify={handleModify}
          onHandleChange={handleChange}
          onCheckboxChange={handleCheckbox}
        />
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
      `${config.apiEndPoint}/Users/${context?.params?.id}`,
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
