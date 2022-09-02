import { Button } from "@mui/material";
import { AdButtonProps } from "../../../types/type";

const AdButton = ({
  title,
  color,
  ...otherProps
}: AdButtonProps): JSX.Element => (
  <Button
    className="rounded-pill"
    sx={{ m: 1 }}
    variant="contained"
    size="small"
    color={color || "primary"}
    {...otherProps}
  >
    {title}
  </Button>
);

export default AdButton;
