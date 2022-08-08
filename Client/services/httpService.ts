import axios from "axios";
import { toast } from "react-toastify";
import config from "../config.json";
import { StepTwoProps, User } from "../types/type";

const header = {
  headers: {
    "Content-Type": "application/json",
  },
};

//
export const handleExpectedError = (response: any) => {
  if (response?.status >= 400 && response?.status < 500) {
    const errors = response?.data?.errors;
    const errPropertyName: string[] = Object.keys(errors);
    toast.error(errors?.[errPropertyName?.[0]]?.[0]);
  }
};

// Login & Register

export const handleRegister = async (user: User): Promise<void> => {
  await axios.post(`${config.apiEndPoint}/auth/register`, user, header);
  // try {

  // } catch ({ response }) {
  //   handleExpectedError(response);
  // }
};

export const handleLogin = async (user: any): Promise<void> => {
  try {
    await axios.post(
      `${config.apiEndPoint}/auth/jwt/createtoken`,
      user,
      header
    );
  } catch ({ response }) {
    handleExpectedError(response);
  }
};

export const handeGetActivateCode = async (
  email: StepTwoProps
): Promise<void> => {
  try {
    const { data } = await axios.post(
      `${config.apiEndPoint}/Auth/EmailActiveCode`,
      email,
      header
    );
    console.log(data.message);
    toast.success(data.message);
  } catch ({ response }) {
    console.log("Http Service active cdoe block");
    handleExpectedError(response);
  }
};
