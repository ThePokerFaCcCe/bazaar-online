import React from "react";
import { Controller } from "react-hook-form";
import { Input } from "antd";
import { ControlledInputProps } from "../../types/type";

const ControlledInput = ({
  name,
  mode,
  control,
  ...otherProps
}: ControlledInputProps) =>
  mode === "password" ? (
    <Controller
      name={name}
      control={control}
      render={({ field }) => <Input.Password {...field} {...otherProps} />}
    />
  ) : (
    <Controller
      name={name}
      control={control}
      render={({ field }) => <Input {...field} {...otherProps} />}
    />
  );

export default ControlledInput;
