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
import ChangeRole from "./manageRole/changeRole";
import NewRole from "./manageRole/newRole";
import RemoveRole from "./manageRole/removeRole";

const ManageRoles = (): JSX.Element => {
  // Redux Setup
  const { roles, permissions } = useSelector(selectDashboard);
  // Local Store
  const [purpose, setPurpose] = useState("newRole");

  //
  const formToShow: JSX.Element = useMemo(() => {
    switch (purpose) {
      case "changeRole":
        return <ChangeRole roles={roles} permissions={permissions} />;
      case "removeRole":
        return <RemoveRole roles={roles} />;
      default:
        return <NewRole permissions={permissions} />;
    }
  }, [purpose, roles, permissions]);

  // Render
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
