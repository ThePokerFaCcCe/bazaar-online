import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  RadioGroup,
  Radio,
} from "@mui/material";
import { useMemo, useState, useEffect } from "react";
import { handleGetData as getCategories } from "../../../services/httpService"; // Renaming Import Function
import { Category } from "../../../types/type";
import NewCategory from "./manageCategory/newCategory";
import ChangeCategory from "./manageCategory/changeCategory";
import RemoveCategory from "./manageCategory/removeCategory";

const ManageCategories = (): JSX.Element => {
  // Local Store
  const [purpose, setPurpose] = useState("newCategory");
  const [categories, setCategories] = useState<Category | []>([]);

  // CDM
  useEffect(() => {
    getCategories("categories", setCategories);
  }, []);

  //
  const formToShow: JSX.Element | undefined = useMemo(() => {
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
