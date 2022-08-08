import { Button, Box } from "@mui/material";
import { Divider } from "antd";
import { useEffect, useState } from "react";
import { useFormik } from "formik";
import { handleRegister, handeGetActivateCode } from "../services/httpService";
import StepOne from "./common/Register/stepOne";
import StepTwo from "./common/Register/stepTwo";
import StepThree from "./common/Register/stepThree";
import registerSchema from "../services/registerSchema";
import { values } from "lodash";

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
      if (terms) {
        handleNextStep(value);
      }
    },
    validationSchema: registerSchema,
  });

  useEffect(() => {
    console.log("Register Page Renderred");
    setTerms(false);
  }, []);
  // Event Handlers
  const handleNextStep = async (value: any) => {
    if (step === 1) {
      try {
        await handleRegister(value);
        setStep(step + 1);
        await handeGetActivateCode({ email: value.email });
      } catch (error) {
        setStep(1);
      }
    }
    if (step !== 1) return setStep(step - 1);
  };

  const stepToShow = (): JSX.Element => {
    if (step === 2) {
      return <StepTwo email={formik.values.email} />;
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
        {step === 2 && (
          <Button
            onClick={handleNextStep}
            variant="contained"
            size="medium"
            color="error"
          >
            بازگشت
          </Button>
        )}
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
