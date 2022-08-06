import { ConfigProvider, Modal, Input, Checkbox, Button } from "antd";
import { LoginModalProps } from "../types/type";

const LoginModal = ({
  onShowLogin,
  onLogin,
  onCloseLogin,
}: LoginModalProps): JSX.Element => {
  return (
    <>
      <ConfigProvider direction="rtl">
        <Modal
          centered
          title="ورود به حساب کاربری"
          visible={onShowLogin}
          onOk={onLogin}
          onCancel={onCloseLogin}
          footer={[
            <Button type="primary" key="submit" onClick={onLogin}>
              ورود
            </Button>,
          ]}
        >
          <Input placeholder="ایمیل" />
          <br />
          <br />
          <Input placeholder="کلمه عبور" />
          <br />
          <br />
          <Checkbox>مرا به خاطر بسپار</Checkbox>
        </Modal>
      </ConfigProvider>
    </>
  );
};

export default LoginModal;
