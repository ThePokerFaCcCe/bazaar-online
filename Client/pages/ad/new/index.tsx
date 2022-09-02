import { useState } from "react";
import { CategoryObject } from "../../../types/type";
import StepOne from "../../../components/Advertisement/NewAd/stepOne";
import StepTwo from "../../../components/Advertisement/NewAd/stepTwo";
import StepThree from "../../../components/Advertisement/NewAd/stepThree";
import StepFour from "../../../components/Advertisement/NewAd/stepFour";

const NewAd = (): JSX.Element => {
  // Local States
  const [step, setStep] = useState(1);
  const [selectedCtg, setSelectedCtg] = useState<any>(null);
  const [selectedSubCtg, setSelectedSubCtg] = useState<any>(null);
  const [selectedSubChildCtg, setSelectedSubChildCtg] = useState<any>(null);
  // Event Handlers
  const backToCategories = () => {
    setStep(1);
  };

  const handleNextStep = (item: CategoryObject) => {
    switch (step) {
      case 1:
        setSelectedCtg(item);
        item.children ? setStep(step + 1) : setStep(4);
        break;
      case 2:
        setSelectedSubCtg(item);
        item.children ? setStep(step + 1) : setStep(4);
        break;
      case 3:
        setSelectedSubChildCtg(item);
        setStep(step + 1);
        break;
    }
  };

  // Render
  const StepToShow = (): JSX.Element => {
    switch (step) {
      case 2:
        return (
          <StepTwo
            onBackToCategories={backToCategories}
            selectedCtg={selectedCtg}
            onNextStep={handleNextStep}
          />
        );
      case 3:
        return (
          <StepThree
            onBackToCategories={backToCategories}
            selectedSubChildCtg={selectedSubCtg}
            onNextStep={handleNextStep}
          />
        );
      case 4:
        return (
          <StepFour
            onBackToCategories={backToCategories}
            selectedCtg={selectedCtg}
            selectedSubCtg={selectedSubCtg}
            selectedSubChildCtg={selectedSubChildCtg}
            onNextStep={handleNextStep}
          />
        );
      default:
        return <StepOne onNextStep={handleNextStep} />;
    }
  };

  return StepToShow();
};

export default NewAd;
