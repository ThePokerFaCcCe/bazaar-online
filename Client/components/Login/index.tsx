import { Checkbox, Divider } from "antd";
import { Button, Box } from "@mui/material";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { LoginUser } from "../../types/type";
import { handleLogin } from "../../services/httpService";
import loginSchema from "../../services/loginSchema";
import ControlledInput from "../controlledInput";

const Login = (): JSX.Element => {
  // React-Hook-Form
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    mode: "onBlur",
    defaultValues: {
      phoneNumber: "",
      password: "",
    },
    resolver: yupResolver(loginSchema),
  });

  // onSubmit
  const onSubmit = (data: LoginUser) => handleLogin(data);

  const handleStatus = (
    propertyName: "phoneNumber" | "password"
  ): "error" | "" => (errors?.[propertyName]?.message ? "error" : "");

  const handleErrorMsg = (
    propertyName: "phoneNumber" | "password"
  ): JSX.Element | void =>
    errors?.[propertyName] && <p>{errors?.[propertyName]?.message}</p>;

  // Render
  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <>
          <ControlledInput
            name="phoneNumber"
            control={control}
            className="my-2 ltr"
            placeholder="شماره موبایل"
            status={handleStatus("phoneNumber")}
          />
          {handleErrorMsg("phoneNumber")}
          <ControlledInput
            name="password"
            mode="password"
            control={control}
            className="my-2 ltr"
            placeholder="کلمه عبور"
            autoComplete="on"
            status={handleStatus("password")}
          />
          {handleErrorMsg("password")}
          <Checkbox className="my-2">مرا به خاطر بسپار</Checkbox>
          <Divider />
          <Box sx={{ display: "flex", justifyContent: "end" }}>
            <Button
              type="submit"
              variant="contained"
              size="medium"
              className="mx-2"
            >
              ورود
            </Button>
          </Box>
        </>
      </form>
    </>
  );
};

export default Login;
