import { Card, CardContent, Typography, Divider } from "@mui/material";
import {
  PhoneAndroid,
  PersonOutline,
  DateRange,
  Block,
  Check,
} from "@mui/icons-material";
import { UserCardProps } from "../../../types/type";
import Link from "next/link";

const UserCard = ({
  name,
  phoneNumber,
  createDate,
  status,
  routeHref,
}: UserCardProps): JSX.Element => (
  <Link href={`dashboard/user/${routeHref}`}>
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
              <PhoneAndroid color="info" />
            </div>
            <span>{phoneNumber}</span>
          </li>
          <li className="list-group-item">
            <div className="my-2">
              <div className="d-flex justify-content-evenly align-items-center">
                <div style={{ width: "57px" }}>
                  <div>
                    {status ? (
                      <Check color="success" />
                    ) : (
                      <Block color="error" />
                    )}
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
  </Link>
);

export default UserCard;
