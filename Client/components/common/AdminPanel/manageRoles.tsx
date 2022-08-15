import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  RadioGroup,
  Radio,
} from "@mui/material";
import { Checkbox, Input } from "antd";
import { useState } from "react";

const ManageRoles = (): JSX.Element => {
  const [purpose, setPurpose] = useState("");

  function formToShow() {
    switch (purpose) {
      case "newRole":
        return (
          <Box>
            <form>
              <Input addonBefore="نام نقش جدید" placeholder="Basic usage" />
            </form>
          </Box>
        );
    }
  }

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
              value="deleteRole"
              control={<Radio />}
              label="حذف نقش"
            />
          </RadioGroup>
        </FormControl>
      </Box>
    </>
  );
};

export default ManageRoles;
