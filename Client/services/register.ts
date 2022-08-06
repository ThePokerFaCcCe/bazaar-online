import axios from "axios";
import { User } from "../types/type";
import config from "../config.json";

export const handleRegister = async (user: any): Promise<void> => {
  const result = await axios.post(`${config.apiEndPoint}/auth/register`, user);
  console.log(result);
};

export default handleRegister;
