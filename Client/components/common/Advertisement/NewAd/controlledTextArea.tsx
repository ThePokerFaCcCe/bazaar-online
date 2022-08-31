import { Controller } from "react-hook-form";
import { Input } from "antd";
import { ControlledTextAreaProps } from "../../../../types/type";

const { TextArea } = Input;

const ControlledTextArea = ({
  name,
  control,
  ...otherProps
}: ControlledTextAreaProps) => (
  <Controller
    name={name}
    control={control}
    render={({ field }) => <TextArea {...field} {...otherProps} />}
  />
);

export default ControlledTextArea;
