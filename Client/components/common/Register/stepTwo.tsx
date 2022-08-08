import { Typography, Box } from "@mui/material";
import { StepTwoProps } from "../../../types/type";
import { Input } from "antd";

const StepTwo = (): JSX.Element => {
  return (
    <>
      <Box className="d-flex flex-column mb-2 ">
        <Typography sx={{ fontSize: "1.3rem", mb: 1 }}>
          کد فعال سازی به ایمیل شما ارسال شد ..!
        </Typography>
        <Typography sx={{ fontSize: "0.9rem" }} className="text-muted">
          لطفا پوشه اسپم خود را نیز چک کنید
        </Typography>
      </Box>
      <div className="d-flex justify-content-center align-items-center">
        <Input
          style={{ width: "50%" }}
          className="my-2"
          placeholder="کد فعالسازی"
        />
      </div>
    </>
  );
};

export default StepTwo;
