import { Input, Checkbox } from "antd";
import { CheckboxChangeEvent } from "antd/lib/checkbox";
import { ToastContainer } from "react-toastify";
import { StepOneProps } from "../../../types/type";

const StepOne = ({ onFormik, onShowTerms, onSetTerms }: StepOneProps) => {
  const handleStatus = (propertyName: string): "error" => {
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
        onChange={onFormik.handleChange}
        status={handleStatus("password")}
        name="password"
        className="my-2"
        onBlur={onFormik.handleBlur}
        placeholder="کلمه عبور *"
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
