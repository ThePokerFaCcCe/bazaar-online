import { Typography, Box, Link } from "@mui/material";
import { InputNumber } from "antd";

const StepTwo = ({ code, onSetCode }: any): JSX.Element => {
  // Event Handler
  const handleInput = (value: number, index: number) => {
    if (value) {
      const clone = [...code];
      clone[index] = value.toString();
      onSetCode(clone.join().replaceAll(",", ""));
    }
  };
  // Render
  return (
    <>
      <Box className="d-flex flex-column">
        <Typography sx={{ fontSize: "1.3rem", mb: 1 }}>
          کد فعال سازی به ایمیل شما ارسال شد ..!
        </Typography>
        <Typography sx={{ fontSize: "0.9rem" }} className="text-muted">
          لطفا پوشه اسپم خود را نیز چک کنید
        </Typography>
      </Box>
      <Typography
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          m: "1rem",
        }}
      >
        کد فعالسازی
      </Typography>
      <Box
        sx={{
          display: "flex",
          flexDirection: "row-reverse",
          justifyContent: "center",
          alignItems: "center",
          gap: "0.5rem",
        }}
        className="salam"
      >
        <InputNumber
          autoFocus={true}
          min={0}
          max={9}
          controls={false}
          style={{ width: "40px" }}
          onChange={(value) => handleInput(value, 0)}
        />
        <InputNumber
          min={0}
          max={9}
          controls={false}
          style={{ width: "40px" }}
          onChange={(value) => handleInput(value, 1)}
        />
        <InputNumber
          min={0}
          max={9}
          controls={false}
          style={{ width: "40px" }}
          onChange={(value) => handleInput(value, 2)}
        />
        <InputNumber
          min={0}
          max={9}
          controls={false}
          style={{ width: "40px" }}
          onChange={(value) => handleInput(value, 3)}
        />
        <InputNumber
          min={0}
          max={9}
          controls={false}
          style={{ width: "40px" }}
          onChange={(value) => handleInput(value, 4)}
        />
        <InputNumber
          min={0}
          max={9}
          controls={false}
          style={{ width: "40px" }}
          onChange={(value) => handleInput(value, 5)}
        />
      </Box>
      <Box
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          m: "1rem",
          gap: "0.5rem",
        }}
      >
        <span> کدی دریافت نکردید؟</span>
        <Link sx={{ textDecoration: "none" }}>درخواست دوباره کد</Link>
      </Box>
    </>
  );
};

export default StepTwo;
