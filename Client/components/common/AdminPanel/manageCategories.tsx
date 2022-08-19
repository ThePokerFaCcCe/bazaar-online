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
import NewCategory from "./manageCategory/newCategory";
import ChangeCategory from "./manageCategory/changeCategory";
import RemoveCategory from "./manageCategory/removeCategory";

const ManageCategories = (): JSX.Element => {
  const [purpose, setPurpose] = useState("newCategory");

  const formToShow: JSX.Element | undefined = useMemo(() => {
    switch (purpose) {
      case "changeCategory":
        return <ChangeCategory />;
      case "removeCategory":
        return <RemoveCategory />;
      default:
        return <NewCategory />;
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
            defaultValue="newCategory"
            onChange={(e, value) => setPurpose(value)}
          >
            <FormControlLabel
              value="newCategory"
              control={<Radio />}
              label="ساخت نقش جدید"
            />
            <FormControlLabel
              value="changeCategory"
              control={<Radio />}
              label="تغییر نقش"
            />
            <FormControlLabel
              value="removeCategory"
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

export default ManageCategories;
