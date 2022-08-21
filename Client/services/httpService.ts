import axios from "axios";
import { toast } from "react-toastify";
import config from "../config.json";
import {
  StepTwoProps,
  User,
  UserActive,
  LoginUser,
  GetUsersProp,
  GetRolesProp,
} from "../types/type";

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

// Register
const handleRegister = async (user: User): Promise<void> => {
  await axios.post(`${config.apiEndPoint}/auth/register`, user, header);
};

const handeGetActivateCode = async (email: StepTwoProps): Promise<void> => {
  try {
    const { data } = await axios.post(
      `${config.apiEndPoint}/Auth/EmailActiveCode`,
      email,
      header
    );
    toast.success(data.message);
  } catch ({ response }) {
    handleExpectedError(response);
  }
};

const handlePostActiveCode = async (user: UserActive): Promise<void> => {
  await axios.post(`${config.apiEndPoint}/Auth/Activate`, user, header);
};

// Register Steps
export const stepOnePost = async (
  value: User,
  step: number,
  setStep: (paramter: number) => void
) => {
  try {
    await handleRegister(value);
    setStep(step + 1);
    await handeGetActivateCode({ email: value.email });
  } catch ({ response }) {
    handleExpectedError(response);
    setStep(1);
  }
};
export const stepTwoPost = async (
  email: string,
  code: string,
  setStep: (paramter: number) => void
) => {
  try {
    await handlePostActiveCode({ code, email });
    setStep(3);
  } catch ({ response }) {
    handleExpectedError(response);
  }
};

// Login
export const handleLogin = async (user: LoginUser) => {
  try {
    const { data } = await axios.post(
      `${config.apiEndPoint}/auth/jwt/createtoken`,
      user,
      header
    );
    localStorage.setItem("sessionExpire", data.expireDate);
    localStorage.setItem("token", data.token);
    window.location.replace("/");
  } catch ({ response }) {
    handleExpectedError(response);
  }
};
// Logout
export const logout = () => {
  localStorage?.removeItem("sessionExpire");
  localStorage?.removeItem("token");
  window.location.replace("/");
};

// Admin Dashboard

export const handleGetData = async (path: string, setState: GetRolesProp) => {
  if (window !== undefined) {
    const token = localStorage.getItem("token");
    if (token) {
      const { data } = await axios.get(`${config.apiEndPoint}/${path}`, {
        headers: {
          Authorization: `bearer ${token}`,
        },
      });
      setState(data);
      return data;
    }
  }
};

export const handleRemove = async (path: string, id: number) => {
  if (window !== undefined) {
    const token = localStorage.getItem("token");
    if (token) {
      await axios.delete(`${config.apiEndPoint}/Roles/${id}`, {
        headers: {
          Authorization: `bearer ${token}`,
        },
      });
    }
  }
};
