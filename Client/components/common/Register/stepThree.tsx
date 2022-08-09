import { Box, Typography } from "@mui/material";
import React from "react";
import TaskAltOutlinedIcon from "@mui/icons-material/TaskAltOutlined";
const StepThree = (): JSX.Element => {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Typography sx={{ fontSize: "1.3rem", mt: 2 }}>
        اکانت شما با موفقیت فعال شد
      </Typography>
      <TaskAltOutlinedIcon sx={{ m: 2, fontSize: "4rem", color: "green" }} />
      <Typography sx={{ fontSize: "1.1rem" }} className="text-muted">
        میتوانید وارد اکانت شوید
      </Typography>
    </Box>
  );
};

export default StepThree;
