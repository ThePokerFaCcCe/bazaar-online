import { ConfigProvider, Modal, Input, Checkbox, Button } from 'antd';
import { LoginModalProps } from '../types/type';

const LoginModal = ({ onShowLogin, onLogin }: LoginModalProps): JSX.Element => {
  return <>
    <ConfigProvider direction="rtl">
      <Modal
        title="ورود به حساب کاربری"
        visible={onShowLogin}
        onOk={onLogin}
        footer={[<Button type="primary" key="submit" onClick={onLogin}>ورود</Button>]}
        centered
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
}

export default LoginModal;