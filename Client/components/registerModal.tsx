import { ConfigProvider, Modal, Input, Checkbox, Button } from "antd";
import { Box, Typography, TextField } from "@mui/material";
import { useState, useMemo } from "react";
import { InputOnChange } from "../types/type";
import * as Yup from "yup";
import handleRegister from "../services/register";
import StepOne from "./common/Register/stepOne";
import StepTwo from "./common/Register/stepTwo";
import StepThree from "./common/Register/stepThree";
const schema = Yup.object({
  email: Yup.string()
    .required("فیلد ایمیل نمیتواند خالی باشد")
    .min(3, "ایمیل باید حداقل 3 کاراکتر باشد")
    .max(30, "ایمیل نمیتواند بیشتر از 30 کاراکتر باشد")
    .email("یک ایمیل معتبر وارد کنید"),
  password: Yup.string()
    .min(6, "رمز باید حداقل 6 رقم باشد")
    .max(15, "رمز نمیتواند بیشتر از 15 رقم باشد")
    .required("فیلد کلمه عبور نمیتواند خالی باشد"),
});

const RegisterModal = ({
  onShowRegister,
  onRegister,
  onCloseLogin,
}: any): JSX.Element => {
  // State
  const [user, setUser] = useState({
    firstName: "",
    lastName: "",
    email: "",
    phoneNumber: "",
    password: "",
  });
  const [step, setStep] = useState(1);

  // Event Handlers
  const handleNextBtn = () => {
    if (step === 1) return setStep(step + 1);
    return setStep(step - 1);
  };

  const handleChange = (e: InputOnChange) => {
    setUser((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };
  // Which Step To Show
  const stepToShow = useMemo((): JSX.Element => {
    if (step === 2) {
      return <StepTwo />;
    }
    if (step === 3) {
      return <StepThree />;
    }
    return <StepOne onChange={handleChange} />;
  }, [step]);

  // Render
  return (
    <ConfigProvider direction="rtl">
      <Modal
        centered
        title="ثبت نام"
        visible={onShowRegister}
        onCancel={onCloseLogin}
        footer={[
          <Button type="primary" onClick={() => handleRegister(user)}>
            {step === 1 ? "ثبت نام" : "بازگشت"}
          </Button>,
          <Button
            className={step === 1 ? "d-none" : "bye"}
            type="primary"
            danger
            // onClick={() => console.log("Bye")}
          >
            ثبت نام
          </Button>,
        ]}
      >
        {stepToShow}
      </Modal>
    </ConfigProvider>
  );
};

export default RegisterModal;
