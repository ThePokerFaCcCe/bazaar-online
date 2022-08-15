import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  RadioGroup,
  Radio,
} from "@mui/material";
import { Input } from "antd";
import { useMemo, useState } from "react";
import ChangeRole from "./manageRole/changeRole";
import NewRole from "./manageRole/newRole";
import RemoveRole from "./manageRole/removeRole";

const ManageRoles = (): JSX.Element => {
  const [purpose, setPurpose] = useState("newRole");

  const formToShow: JSX.Element | undefined = useMemo(() => {
    switch (purpose) {
      case "changeRole":
        return <ChangeRole />;
      case "removeRole":
        return <RemoveRole />;
      default:
        return <NewRole />;
    }
  }, [purpose]);

  return (
    <>
      <Box>
        <FormControl>
          <FormLabel>هدف</FormLabel>
          <RadioGroup
            row
            value={purpose}
            defaultValue="newRole"
            onChange={(e, value) => setPurpose(value)}
          >
            <FormControlLabel
              value="newRole"
              control={<Radio />}
              label="ساخت نقش جدید"
            />
            <FormControlLabel
              value="changeRole"
              control={<Radio />}
              label="تغییر نقش"
            />
            <FormControlLabel
              value="removeRole"
              control={<Radio />}
              label="حذف نقش"
            />
          </RadioGroup>
        </FormControl>
        <Box>{formToShow}</Box>
      </Box>
    </>
  );
};

export default ManageRoles;
