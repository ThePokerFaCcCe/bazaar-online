import { Button, Box } from "@mui/material";
import { Divider } from "antd";
import { useState } from "react";
import { useFormik } from "formik";
import { handleRegister } from "../services/httpService";
import StepOne from "./common/Register/stepOne";
import StepTwo from "./common/Register/stepTwo";
import StepThree from "./common/Register/stepThree";
import registerSchema from "../services/registerSchema";

const Register = (): JSX.Element => {
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
      handleRegister(value);
    },
    validationSchema: registerSchema,
  });

  // Event Handlers
  const handleNextBtn = () => {
    if (step === 1) {
      // TODO There Is Bug Here
      if (terms) {
        handleRegister(formik.values);
        setStep(step + 1);
      }
      return;
    }
    if (step !== 1) return setStep(step - 1);
  };

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

  // Render
  return (
    <form onSubmit={formik.handleSubmit}>
      {stepToShow()}
      <Divider />
      <Box sx={{ display: "flex", justifyContent: "end" }}>
        <Button type="submit" variant="contained" size="medium" color="error">
          بازگشت
        </Button>
        <Button
          type="submit"
          variant="contained"
          size="medium"
          className="mx-2"
        >
          ثبت نام
        </Button>
      </Box>
    </form>
  );
};

export default Register;
