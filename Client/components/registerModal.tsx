import { ConfigProvider, Modal, Input, Checkbox, Button } from "antd";
import { Box, Typography, TextField } from "@mui/material";
import React, { useState, useMemo } from "react";
import { InputOnChange } from "../types/type";
import * as Yup from "yup";
import { Formik, Field, Form, FormikHelpers, useFormik } from "formik";
import handleRegister from "../services/register";
import StepOne from "./common/Register/stepOne";
import StepTwo from "./common/Register/stepTwo";
import StepThree from "./common/Register/stepThree";
import registerSchema from "../services/registerValidate";
import { CheckboxChangeEvent } from "antd/lib/checkbox";

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
      return terms && setStep(step + 1);
    }
    return setStep(step - 1);
  };

  // Which Step To Show
  const stepToShow = useMemo((): JSX.Element => {
    if (step === 2) {
      return <StepTwo />;
    }
    if (step === 3) {
      return <StepThree />;
    }
    return (
      <StepOne
        onShowTerms={terms}
        onSetTerms={setTerms}
        onFormikChange={formik.handleChange}
      />
    );
  }, [step]);
  console.log(terms);
  // Render
  return (
    <ConfigProvider direction="rtl">
      <Modal
        centered
        title="ثبت نام"
        visible={onShowRegister}
        onCancel={onCloseLogin}
        footer={[
          <Button type="primary" onClick={handleNextBtn}>
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
        <form onSubmit={formik.handleSubmit}>
          {stepToShow}
          <button type="submit" className="btn-sm btn-primary">
            Click
          </button>
        </form>
      </Modal>
    </ConfigProvider>
  );
};

export default RegisterModal;
