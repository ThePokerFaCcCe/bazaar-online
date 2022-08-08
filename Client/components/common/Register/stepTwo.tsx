import { Typography, Box } from "@mui/material";
import { useEffect } from "react";
import { handeGetActivateCode } from "../../../services/httpService";
import { StepTwoProps } from "../../../types/type";

const StepTwo = ({ email }: StepTwoProps): JSX.Element => {
  return (
    <>
      <Box className="d-flex mb-2 ">
        <Typography>کد فعال سازی به ایمیل</Typography>
        <Typography className="mx-1">({email})</Typography>
        <Typography>ارسال شد..!</Typography>
      </Box>
      <Typography>لطفا پوشه SPAM خود را چک کنید</Typography>
    </>
  );
};

export default StepTwo;
