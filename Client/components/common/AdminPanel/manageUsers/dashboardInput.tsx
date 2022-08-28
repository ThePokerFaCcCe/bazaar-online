import { Input } from "antd";
import { DashboardInputProps } from "../../../../types/type";

const DashboardInput = ({
  placeholder,
  ...otherProps
}: DashboardInputProps) => {
  return (
    <div style={{ width: "100%" }}>
      <label style={{ marginBottom: "5px" }} htmlFor="">
        {placeholder}
      </label>
      <Input {...otherProps} placeholder={placeholder} />
    </div>
  );
};

export default DashboardInput;
