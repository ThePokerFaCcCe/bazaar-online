import { Input, Checkbox } from "antd";
import { InputOnChange } from "../../../types/type";

interface StepOneProps {
  onChange: (e: InputOnChange) => void;
}

const StepOne = ({ onChange }: StepOneProps) => {
  return (
    <>
      <div className="row">
        <div className="col">
          <Input
            onChange={onChange}
            id="firstName"
            className="my-2"
            placeholder="نام *"
          />
          <Input
            onChange={onChange}
            id="email"
            className="my-2"
            placeholder="ایمیل *"
          />
        </div>
        <div className="col">
          <Input
            onChange={onChange}
            className="my-2"
            id="lastName"
            placeholder="نام خانوادگی *"
          />
          <Input
            onChange={onChange}
            id="phoneNumber"
            className="my-2"
            placeholder="شماره موبایل *"
          />
        </div>
      </div>
      <Input
        onChange={onChange}
        id="password"
        className="my-2"
        placeholder="کلمه عبور *"
      />
      <Checkbox className="my-2">
        <span>با قوانین سایت موافقم</span>
        <span className="text-danger">*</span>
      </Checkbox>
    </>
  );
};

export default StepOne;
