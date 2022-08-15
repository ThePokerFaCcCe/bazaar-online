import { Card, CardContent, Typography, Divider } from "@mui/material";
import {
  MailOutline,
  PhoneAndroid,
  PersonOutline,
  DateRange,
  Block,
  Check,
} from "@mui/icons-material";
import { UserCardProps } from "../../../types/type";

const UserCard = ({
  name,
  email,
  createDate,
  status,
}: UserCardProps): JSX.Element => (
  <Card sx={{ width: 250, textAlign: "center" }} className="border userCard">
    <CardContent>
      <ul
        className="list-group list-group-flush nopadding"
        style={{ textAlign: "center" }}
      >
        <Typography variant="subtitle2" component="div" mb={2}>
          <span>
            <PersonOutline sx={{ color: "rgba(0, 0, 0, 0.56)" }} />
          </span>
          <span>{name}</span>
        </Typography>
        <li className="list-group-item">
          <div className="mb-2">
            <MailOutline color="info" />
          </div>
          <span>{email}</span>
        </li>
        <li className="list-group-item">
          <div className="my-2">
            <div className="d-flex justify-content-evenly align-items-center">
              <div className="border-left">
                <div>
                  {status ? <Check color="success" /> : <Block color="error" />}
                </div>
                <span>{status ? "فعال" : "غیر فعال"}</span>
              </div>
              <Divider
                sx={{ borderColor: "#000" }}
                orientation="vertical"
                flexItem
              />
              <div>
                <div>
                  <DateRange color="secondary" />
                </div>
                <span>{createDate}</span>
              </div>
            </div>
          </div>
        </li>
      </ul>
    </CardContent>
  </Card>
);

export default UserCard;
