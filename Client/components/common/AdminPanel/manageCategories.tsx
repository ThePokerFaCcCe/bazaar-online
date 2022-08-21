import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  RadioGroup,
  Radio,
} from "@mui/material";
import { Input } from "antd";
import { useMemo, useState, useEffect } from "react";
import NewCategory from "./manageCategory/newCategory";
import ChangeCategory from "./manageCategory/changeCategory";
import RemoveCategory from "./manageCategory/removeCategory";
import { handleGetData } from "../../../services/httpService";
import { Category } from "../../../types/type";

const ManageCategories = (): JSX.Element => {
  // Local Store
  const [purpose, setPurpose] = useState("newCategory");
  const [categories, setCategories] = useState<Category | []>([]);

  // CDM
  useEffect(() => {
    handleGetData("categories", setCategories);
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
