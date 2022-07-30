import { useState } from "react";
import StepOne from "../../../components/common/Advertisement/NewAd/stepOne";
import StepTwo from "../../../components/common/Advertisement/NewAd/stepTwo";
import StepThree from "../../../components/common/Advertisement/NewAd/stepThree";

const NewAd = (): JSX.Element => {
  const [step, setStep] = useState(1);
  const StepToShow = (): JSX.Element => {
    switch (step) {
      case 2:
        return <StepTwo onSetStep={setStep} />;
      case 3:
        return <StepThree onSetStep={setStep} />;
      default:
        return <StepOne onSetStep={setStep} />;
    }
  };

  return <>{StepToShow()}</>;
};

export default NewAd;
