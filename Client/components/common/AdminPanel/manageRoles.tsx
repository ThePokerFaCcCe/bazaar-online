import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  RadioGroup,
  Radio,
} from "@mui/material";
import { useMemo, useState, useEffect } from "react";
import {
  getPermissionList,
  handleGetData as getRoles,
} from "../../../services/httpService"; // Renaming Import Function
import { Roles } from "../../../types/type";
import ChangeRole from "./manageRole/changeRole";
import NewRole from "./manageRole/newRole";
import RemoveRole from "./manageRole/removeRole";

const ManageRoles = (): JSX.Element => {
  // Local Store
  const [purpose, setPurpose] = useState("newRole");
  const [roles, setRoles] = useState<Roles | []>([]);
  const [permissions, setPermissions] = useState([]);
  // CDM
  useEffect(() => {
    getRoles("roles", setRoles);
    getPermissionList(setPermissions);
  }, []);
  //
  const formToShow: JSX.Element | undefined = useMemo(() => {
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
