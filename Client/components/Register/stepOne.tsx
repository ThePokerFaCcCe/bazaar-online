import { Checkbox } from "antd";
import { CheckboxChangeEvent } from "antd/lib/checkbox";
import { ToastContainer } from "react-toastify";
import { StepOneProps } from "../../types/type";
import ControlledInput from "../controlledInput";

const StepOne = ({
  control,
  errors,
  onShowTerms,
  onSetTerms,
}: StepOneProps) => {
  // Event Handlers

  const handleStatus = (propertyName: string): "error" | "" =>
    errors?.[propertyName]?.message ? "error" : "";

  const handleErrorMsg = (propertyName: string): JSX.Element | void =>
    errors?.[propertyName] && <p>{errors?.[propertyName]?.message}</p>;

  // Render
  return (
    <>
      <ToastContainer />
      <div className="row">
        <div className="col">
          <>
            {/* First Name */}
            <ControlledInput
              name="firstName"
              control={control}
              className="my-2 ltr"
              placeholder="نام *"
              status={handleStatus("firstName")}
            />
            {handleErrorMsg("firstName")}
            {/* Email */}
            <ControlledInput
              name="email"
              control={control}
              className="my-2 ltr"
              placeholder="ایمیل *"
              status={handleStatus("email")}
            />
            {handleErrorMsg("email")}
          </>
        </div>
        <div className="col">
          <>
            {/* Last Name */}
            <ControlledInput
              name="lastName"
              control={control}
              className="my-2 ltr"
              placeholder="نام خانوادگی *"
              status={handleStatus("lastName")}
            />
            {handleErrorMsg("lastName")}
            {/* Phone Number */}
            <ControlledInput
              name="phoneNumber"
              mode="password"
              control={control}
              className="my-2 ltr"
              placeholder="شماره موبایل *"
              autoComplete="on"
              status={handleStatus("phoneNumber")}
            />
            {handleErrorMsg("phoneNumber")}
          </>
        </div>
      </div>
      {/* Password */}
      <ControlledInput
        name="password"
        mode="password"
        control={control}
        className="my-2 ltr"
        placeholder="کلمه عبور *"
        autoComplete="on"
        status={handleStatus("password")}
      />
      {handleErrorMsg("password")}
      <Checkbox
        className="my-2"
        checked={onShowTerms}
        onChange={({ target }: CheckboxChangeEvent) =>
          onSetTerms(target.checked)
        }
      >
        <span>با قوانین سایت موافقم</span>
        <span className="text-danger">*</span>
      </Checkbox>
    </>
  );
};

export default StepOne;
