import axios from "axios";
import { toast } from "react-toastify";
import config from "../config.json";

export const handleRegister = async (user: any): Promise<void> => {
  try {
    await axios.post(`${config.apiEndPoint}/auth/register`, user, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  } catch ({ response }) {
    if (response?.status >= 400 && response?.status < 500) {
      const errors = response?.data?.errors;
      const errPropertyName: string[] = Object.keys(errors);
      toast.error(errors?.[errPropertyName?.[0]]?.[0]);
    }
  }
};

export const handleLogin = async (user: any): Promise<void> => {
  try {
    await axios.post(`${config.apiEndPoint}/auth/jwt/createtoken`, user, {
      headers: {
        "Content-Type": "application/json",
      },
    });
  } catch ({ response }) {
    console.log(response);
    if (response?.status >= 400 && response?.status < 500) {
      const errors = response?.data?.errors;
      const errPropertyName: string[] = Object.keys(errors);
      toast.error(errors?.[errPropertyName?.[0]]?.[0]);
    }
  }
};
