import axios from "axios";
import nookies from "nookies";
import { toast } from "react-toastify";
import config from "../config.json";
import {
  StepTwoProps,
  User,
  UserActive,
  LoginUser,
  GetRolesProp,
  DashboardUserPage,
} from "../types/type";

const { token } = nookies.get();

const header = {
  headers: {
    "Content-Type": "application/json",
    Authorization: `bearer ${token}`,
  },
};

//
export const handleExpectedError = (response: any) => {
  if (response?.status >= 400 && response?.status < 500) {
    const errors = response?.data?.errors;
    const errPropertyName: string[] = Object?.keys?.(errors);
    toast.error?.(errors?.[errPropertyName?.[0]]?.[0]);
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
    nookies.set(null, "token", data.token, {
      expires: new Date(data.expireDate),
    });
    window.location.replace("/");
  } catch ({ response }) {
    handleExpectedError(response);
  }
};
// Logout
export const logout = () => {
  nookies.destroy(null, "token");
  window.location.replace("/");
};

// Set Store, User isLoggedIn to True

export const checkUserAuthExpire = (
  reduxDispatch: (actionCreator: any) => void,
  actionCreator: any
) => {
  token && reduxDispatch(actionCreator(true));
};

// Admin Dashboard

export const handleGetData = async (path: string, setState?: GetRolesProp) => {
  if (token) {
    const { data } = await axios.get(`${config.apiEndPoint}/${path}`, header);
    if (setState) {
      setState(data);
    }
    return data;
  }
};

export const handleRemove = async (urlPath: string, id: number) => {
  if (token) {
    await axios.delete(`${config.apiEndPoint}/${urlPath}/${id}`);
  }
};

export const getPermissionList = async (setState: GetRolesProp) => {
  if (token) {
    const { data } = await axios.get(`${config.apiEndPoint}/permissions`, {
      headers: {
        Authorization: `bearer ${token}`,
      },
    });
    setState(data);
    return data;
  }
};

export const getFeaturesList = async () => {
  if (token) {
    const { data } = await axios.get(`${config.apiEndPoint}/Features`, header);
  }
};

export const getRolePermissions = async (
  selectedRole: number | null,
  setState: (object: any) => void
) => {
  if (selectedRole) {
    const { data } = await axios.get(
      `${config.apiEndPoint}/Roles/${selectedRole}`,
      header
    );
    setState(data);
  }
};

// Dashboard User

export const changeUserInfo = async (id: number, data: DashboardUserPage) => {
  await axios.put(`${config.apiEndPoint}/Users/${id}`, data, header);
};
export const deleteUser = async (id: number) => {
  await axios.delete(`${config.apiEndPoint}/Users/${id}`, header);
};

// Dashboard Ad

export const confirmAd = async (id: number) => {
  await axios.post(
    `${config.apiEndPoint}/Advertiesements/${id}/Management/Accept`,
    header
  );
};

export const rejectAd = async (id: number, reason: string) => {
  await axios.post(
    `${config.apiEndPoint}/Advertiesements/${id}/Management/Deny`,
    { reason },
    header
  );
};

export const deleteAd = async (id: number, reason: string) => {
  await axios.post(
    `${config.apiEndPoint}/Advertiesements/${id}/Management/Delete`,
    { reason },
    header
  );
};

// City Modal

export const getCities = async (
  stateId: number,
  setState: (object: any) => void
) => {
  const { data } = await axios.get(
    `${config.apiEndPoint}/Locations/Cities/${stateId}`
  );
  return setState(data);
};

// Forbidden

export const handleForbidden = (): void => {
  setTimeout(() => {
    window.location.replace("/");
  }, 2000);
};
