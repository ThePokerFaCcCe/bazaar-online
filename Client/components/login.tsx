import { Input, Checkbox, Divider, ConfigProvider } from "antd";
import { Button, Box } from "@mui/material";
import { useFormik, getIn } from "formik";
import { handleLogin } from "../services/httpService";
import loginSchema from "../services/loginSchema";

const Login = (): JSX.Element => {
  // Formik Validation
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    onSubmit: (value) => {
      handleLogin(value);
    },
    validationSchema: loginSchema,
  });
  // Event Handler
  const handleStatus = (propertyName: "email" | "password"): "error" | any => {
    return (
      formik.touched?.[propertyName] && formik.errors?.[propertyName] && "error"
    );
  };

  const handleErrorMsg = (
    propertyName: "email" | "password"
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
            name="email"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            status={handleStatus("email")}
            className="my-2 ltr"
            placeholder="ایمیل"
          />
          {handleErrorMsg("email")}
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
