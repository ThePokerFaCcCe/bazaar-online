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
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";

const Register = (): JSX.Element => {
  // State
  const [step, setStep] = useState(1);
  const [code, setCode] = useState("000000");
  const [terms, setTerms] = useState(false);
  // React-Hook-Form
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    mode: "onBlur",
    defaultValues: {
      firstName: "",
      lastName: "",
      email: "",
      phoneNumber: "",
      password: "",
    },
    resolver: yupResolver(registerSchema),
  });

  // onSubmit
  const onSubmit = (data: any) => terms && handleNextStep(data);

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
            control={control}
            errors={errors}
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
        stepTwoPost(value.email, code, setStep);
        break;
    }
  };

  const handleBackStep = () => {
    step !== 1 && setStep(step - 1);
  };

  // Render
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
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
