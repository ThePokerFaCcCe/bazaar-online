import { Input, Checkbox } from "antd";
import { CheckboxChangeEvent } from "antd/lib/checkbox";
import { StepOneProps } from "../../../types/type";

const StepOne = ({ onFormikChange, onShowTerms, onSetTerms }: StepOneProps) => {
  return (
    <>
      <div className="row">
        <div className="col">
          <Input
            name="firstName"
            className="my-2"
            placeholder="نام *"
            onChange={onFormikChange}
          />
          <Input
            onChange={onFormikChange}
            name="email"
            className="my-2"
            placeholder="ایمیل *"
          />
        </div>
        <div className="col">
          <Input
            onChange={onFormikChange}
            className="my-2"
            name="lastName"
            placeholder="نام خانوادگی *"
          />
          <Input
            onChange={onFormikChange}
            name="phoneNumber"
            className="my-2"
            placeholder="شماره موبایل *"
          />
        </div>
      </div>
      <Input
        onChange={onFormikChange}
        name="password"
        className="my-2"
        placeholder="کلمه عبور *"
      />
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
