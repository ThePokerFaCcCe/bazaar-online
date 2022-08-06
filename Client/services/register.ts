import axios from "axios";
import config from "../config.json";

export const handleRegister = async (user: any): Promise<void> => {
  const result = await axios.post(`${config.apiEndPoint}/auth/register`, user, {
    headers: {
      "Content-Type": "application/json",
    },
  });
  console.log(result);
};

export default handleRegister;
