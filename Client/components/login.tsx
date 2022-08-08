import { Input, Checkbox, Divider } from "antd";
import { Button, Box } from "@mui/material";
const Login = (): JSX.Element => {
  return (
    <>
      <Input className="my-2" placeholder="ایمیل" />
      <Input className="my-2" placeholder="کلمه عبور" />
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
  );
};

export default Login;
