import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  RadioGroup,
  Radio,
} from "@mui/material";
import { useMemo, useState } from "react";
import { useSelector } from "react-redux";
import { selectDashboard } from "../../../store/state/dashboard";
import NewCategory from "./newCategory";
import ChangeCategory from "./changeCategory";
import RemoveCategory from "./removeCategory";

const ManageCategories = (): JSX.Element => {
  // Redux Setup
  const { categories } = useSelector(selectDashboard);

  // Local Store
  const [purpose, setPurpose] = useState("newCategory");

  //
  const formToShow: JSX.Element = useMemo(() => {
    switch (purpose) {
      case "changeCategory":
        return <ChangeCategory categories={categories} />;
      case "removeCategory":
        return <RemoveCategory categories={categories} />;
      default:
        return <NewCategory categories={categories} />;
    }
  }, [purpose, categories]);

  // Render
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
              label="ساخت دسته بندی جدید"
            />
            <FormControlLabel
              value="changeCategory"
              control={<Radio />}
              label="تغییر دسته بندی"
            />
            <FormControlLabel
              value="removeCategory"
              control={<Radio />}
              label="حذف دسته بندی"
            />
          </RadioGroup>
        </FormControl>
        <Box>{formToShow}</Box>
      </Box>
    </>
  );
};

export default ManageCategories;
