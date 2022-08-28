import { Checkbox } from "antd";
import { Grid } from "@mui/material";
import { DashboardCheckboxProps } from "../../../../types/type";

const DashboardCheckbox = ({
  title,
  conditionAndTxt,
  ...otherProps
}: DashboardCheckboxProps) => {
  return (
    <div style={{ width: "100%" }}>
      <Grid container direction="row" spacing={2}>
        <Grid item>{title}</Grid>
        <Grid item>{conditionAndTxt}</Grid>
        <Grid item>
          <Checkbox {...otherProps} />
        </Grid>
      </Grid>
    </div>
  );
};

export default DashboardCheckbox;
