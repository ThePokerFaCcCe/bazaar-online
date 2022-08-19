import { Button, Box } from "@mui/material";
import { Divider } from "antd";
import { useState } from "react";
import { useFormik } from "formik";
import { stepOnePost, stepTwoPost } from "../services/httpService";
import { User } from "../types/type";
import StepOne from "./common/Register/stepOne";
import StepTwo from "./common/Register/stepTwo";
import StepThree from "./common/Register/stepThree";
import registerSchema from "../services/registerSchema";

const Register = (): JSX.Element => {
  // State
  const [step, setStep] = useState(1);
  const [code, setCode] = useState("000000");
  const [terms, setTerms] = useState(false);
  const formik = useFormik({
    validationSchema: registerSchema,
    initialValues: {
      firstName: "",
      lastName: "",
      email: "",
      phoneNumber: "",
      password: "",
    },
    onSubmit: (value) => {
      if (terms) {
        handleNextStep(value);
      }
    },
  });

  // Event Handlers
  const stepToShow = (): JSX.Element => {
    switch (step) {
      case 2:
        return <StepTwo code={code} onSetCode={setCode} />;
      case 3:
        return <StepThree />;
      default:
        return (
          <StepOne
            onShowTerms={terms}
            onSetTerms={setTerms}
            onFormik={formik}
          />
        );
    }
  };

  const handleNextStep = (value: User) => {
    switch (step) {
      case 1:
        stepOnePost(value, step, setStep);
        break;
      case 2:
        stepTwoPost(value, code, setStep);
        break;
    }
  };

  const handleBackStep = () => {
    if (step !== 1) return setStep(step - 1);
  };

  // Render
  return (
    <form onSubmit={formik.handleSubmit}>
      {stepToShow()}
      <Divider />
      <Box sx={{ display: "flex", justifyContent: "end" }}>
        {step === 2 && (
          <Button
            onClick={handleBackStep}
            variant="contained"
            size="medium"
            color="error"
          >
            بازگشت
          </Button>
        )}
        {step !== 3 && (
          <Button
            type="submit"
            variant="contained"
            size="medium"
            className="mx-2"
          >
            ثبت نام
          </Button>
        )}
      </Box>
    </form>
  );
};

export default Register;
