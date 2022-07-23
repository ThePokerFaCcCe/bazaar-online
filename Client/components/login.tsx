import {useState} from 'react';
import { ConfigProvider,Modal,Input,Checkbox,Button } from 'antd';
const Login = (): JSX.Element => { 
    const [visible, setVisible] = useState(false);
    const [confirmLoading, setConfirmLoading] = useState(false)

    const handleOk = (): void => {
      setConfirmLoading(true);
      setTimeout(() => {
        setVisible(false);
        setConfirmLoading(false);
      }, 2000);
    };
  
    const showModal = ():void => {
      setVisible(true);
    };

     return  <>
      <ConfigProvider direction="rtl">
        <Modal
          title="ورود به حساب کاربری"
          visible={visible}
          onOk={handleOk}
          footer={[<Button type="primary" key="submit" loading={confirmLoading} onClick={handleOk}>ورود</Button>]}
          centered
        >
          <Input placeholder="ایمیل" />
          <br/>
          <br/>
          <Input placeholder="کلمه عبور" />
          <br/>
          <br/>
          <Checkbox>مرا به خاطر بسپار</Checkbox>
        </Modal>
    </ConfigProvider>
     </> 
}

export default Login;