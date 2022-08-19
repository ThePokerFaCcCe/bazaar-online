import axios from "axios";
import { toast } from "react-toastify";
import config from "../config.json";
import { StepTwoProps, User, UserActive, LoginUser } from "../types/type";

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
  value: User,
  code: string,
  setStep: (paramter: number) => void
) => {
  try {
    await handlePostActiveCode({ Code: code, email: value.email });
    setStep(3);
  } catch ({ response }) {
    handleExpectedError(response);
  }
};

// Login
export const handleLogin = async (user: LoginUser): Promise<void> => {
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
