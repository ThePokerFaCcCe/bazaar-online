import { ConfigProvider, Input, Checkbox, Button } from "antd";

const LoginModal = (): JSX.Element => {
  return (
    <>
      <ConfigProvider direction="rtl">
        <Input placeholder="ایمیل" />
        <br />
        <br />
        <Input placeholder="کلمه عبور" />
        <br />
        <br />
        <Checkbox>مرا به خاطر بسپار</Checkbox>
      </ConfigProvider>
    </>
  );
};

export default LoginModal;
