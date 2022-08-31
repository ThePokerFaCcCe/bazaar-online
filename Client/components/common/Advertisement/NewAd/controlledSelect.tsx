import { Controller } from "react-hook-form";
import { Select } from "antd";
import { ControlledSelectProps } from "../../../../types/type";

const ControlledSelect = ({
  name,
  control,
  ...otherProps
}: ControlledSelectProps) => (
  <Controller
    name={name}
    control={control}
    render={({ field }: any) => (
      <Select {...field} style={{ width: "100%" }} {...otherProps} />
    )}
  />
);

export default ControlledSelect;
