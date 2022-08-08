import { ConfigProvider, Modal, Button } from "antd";
import React, { useState } from "react";
import { InputOnChange } from "../types/type";
import { useFormik } from "formik";
import handleRegister from "../services/register";
import StepOne from "./common/Register/stepOne";
import StepTwo from "./common/Register/stepTwo";
import StepThree from "./common/Register/stepThree";
import registerSchema from "../services/registerValidate";
// import { CheckboxChangeEvent } from "antd/lib/checkbox";

const RegisterModal = ({
  onShowRegister,
  onRegister,
  onCloseLogin,
}: any): JSX.Element => {
  // State
  const [step, setStep] = useState(1);
  const [terms, setTerms] = useState(false);
  const formik = useFormik({
    initialValues: {
      firstName: "",
      lastName: "",
      email: "",
      phoneNumber: "",
      password: "",
    },
    onSubmit: (value) => {
      console.log(value);
    },
    validationSchema: registerSchema,
  });

  // Event Handlers
  const handleNextBtn = () => {
    if (step === 1) {
      console.log(formik.errors);
      // console.log(formik.errors.length)
      console.log(Object.keys(formik.errors).length);
      if (terms) {
        console.log("Inside Terms Execute");
        handleRegister(formik.values);
        setStep(step + 1);
      }
      return;
    }
    console.log("Resid Be Akharesh");
    if (step !== 1) return setStep(step - 1);
  };

  // Which Step To Show
  const stepToShow = (): JSX.Element => {
    if (step === 2) {
      return <StepTwo />;
    }
    if (step === 3) {
      return <StepThree />;
    }
    return (
      <StepOne onShowTerms={terms} onSetTerms={setTerms} onFormik={formik} />
    );
  };
  console.log("step", step);
  // Check if There is no Error
  // console.log(Object.keys(formik.errors).length);
  // Render
  return (
    <ConfigProvider direction="rtl">
      <form onSubmit={formik.handleSubmit}>
        {stepToShow()}
        <button type="submit" className="btn-sm btn-primary">
          Click
        </button>
      </form>
    </ConfigProvider>
  );
};

export default RegisterModal;
