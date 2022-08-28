import { Input, Checkbox, Divider } from "antd";
import { Button, Box } from "@mui/material";
import { useFormik } from "formik";
import { handleLogin } from "../services/httpService";
import loginSchema from "../services/loginSchema";

const Login = (): JSX.Element => {
  // Formik Validation
  const formik = useFormik({
    initialValues: {
      phoneNumber: "",
      password: "",
    },
    onSubmit: (value) => {
      handleLogin(value);
    },
    validationSchema: loginSchema,
  });
  // Event Handler
  const handleStatus = (
    propertyName: "phoneNumber" | "password"
  ): "error" | any => {
    return (
      formik.touched?.[propertyName] && formik.errors?.[propertyName] && "error"
    );
  };

  const handleErrorMsg = (
    propertyName: "phoneNumber" | "password"
  ): JSX.Element | any => {
    return (
      formik.touched?.[propertyName] &&
      formik.errors?.[propertyName] && <p>{formik.errors?.[propertyName]}</p>
    );
  };

  // Render
  return (
    <>
      <form onSubmit={formik.handleSubmit}>
        <>
          <Input
            name="phoneNumber"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            status={handleStatus("phoneNumber")}
            className="my-2 ltr"
            placeholder="شماره موبایل"
          />
          {handleErrorMsg("phoneNumber")}
          <Input.Password
            name="password"
            onChange={formik.handleChange}
            status={handleStatus("password")}
            onBlur={formik.handleBlur}
            className="my-2 ltr"
            placeholder="کلمه عبور"
            autoComplete="on"
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
