import { Input, Checkbox } from "antd";
import { CheckboxChangeEvent } from "antd/lib/checkbox";
import { ToastContainer } from "react-toastify";
import { StepOneProps } from "../../../types/type";

const StepOne = ({ onFormik, onShowTerms, onSetTerms }: StepOneProps) => {
  // Event Handlers

  const handleStatus = (propertyName: string): "error" | undefined => {
    return (
      onFormik.touched?.[propertyName] &&
      onFormik.errors?.[propertyName] &&
      "error"
    );
  };

  const handleErrorMsg = (propertyName: string): JSX.Element | void => {
    return (
      onFormik.touched?.[propertyName] &&
      onFormik.errors?.[propertyName] && (
        <p>{onFormik.errors?.[propertyName]}</p>
      )
    );
  };
  // Render
  return (
    <>
      <ToastContainer />
      <div className="row">
        <div className="col">
          <>
            {/* First Name */}
            <Input
              name="firstName"
              placeholder="نام *"
              className="my-2"
              status={handleStatus("firstName")}
              onBlur={onFormik.handleBlur}
              onChange={onFormik.handleChange}
            />
            {handleErrorMsg("firstName")}
            {/* Email */}
            <Input
              name="email"
              placeholder="ایمیل *"
              className="my-2"
              status={handleStatus("email")}
              onChange={onFormik.handleChange}
              onBlur={onFormik.handleBlur}
            />
            {handleErrorMsg("email")}
          </>
        </div>
        <div className="col">
          <>
            {/* Last Name */}
            <Input
              name="lastName"
              placeholder="نام خانوادگی *"
              className="my-2"
              status={handleStatus("lastName")}
              onBlur={onFormik.handleBlur}
              onChange={onFormik.handleChange}
            />
            {handleErrorMsg("lastName")}
            {/* Phone Number */}
            <Input
              name="phoneNumber"
              placeholder="شماره موبایل *"
              className="my-2"
              status={handleStatus("phoneNumber")}
              onChange={onFormik.handleChange}
              onBlur={onFormik.handleBlur}
            />
            {handleErrorMsg("phoneNumber")}
          </>
        </div>
      </div>
      {/* Password */}
      <Input.Password
        name="password"
        placeholder="کلمه عبور *"
        className="my-2"
        status={handleStatus("password")}
        onChange={onFormik.handleChange}
        onBlur={onFormik.handleBlur}
        autoComplete="on"
      />
      {handleErrorMsg("password")}
      <Checkbox
        className="my-2"
        value={onShowTerms}
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
