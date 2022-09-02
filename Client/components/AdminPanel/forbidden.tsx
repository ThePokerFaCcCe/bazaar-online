import React, { useEffect } from "react";
import { Typography } from "@mui/material";
import { handleForbidden } from "../../../services/httpService";

const Forbidden = () => {
  // CDM
  useEffect(() => {
    handleForbidden();
  }, []);
  // Render
  return (
    <div className="d-flex flex-column justify-content-center align-items-center mt-5">
      <Typography>خطای 403</Typography>
      <Typography>دسترسی ندارید. به صفحه اصلی منتقل میشوید</Typography>
    </div>
  );
};

export default Forbidden;
