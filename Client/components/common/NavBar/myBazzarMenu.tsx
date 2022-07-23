import React from "react";
import {
  Box,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Divider,
} from "@mui/material";
import { Col, Row } from "antd";
import LoginIcon from "@mui/icons-material/Login";
import BookmarkIcon from "@mui/icons-material/Bookmark";
import NoteAltIcon from "@mui/icons-material/NoteAlt";
import RemoveRedEyeIcon from "@mui/icons-material/RemoveRedEye";
import { Menus } from "../../../typealias/allTypes";

const menus: Menus = [
  { title: "ورود", icon: <LoginIcon /> },
  { title: "نشان شده ها", icon: <BookmarkIcon /> },
  { title: "یادداشت شده ها", icon: <NoteAltIcon /> },
  { title: "بازدید های اخیر", icon: <RemoveRedEyeIcon /> },
];

const MyBazzarMenu = (): JSX.Element => (
  <Box
    sx={{
      position: "absolute",
      width: "250px",
      left: "-180px",
      marginTop: "10px",
      fontSize: "5px",
      backgroundColor: "#fff",
      boxShadow: "0 0 0 1px #ccc",
    }}
  >
    <List sx={{ padding: 0 }}>
      {menus.map((item, index) => (
        <React.Fragment key={index}>
          <ListItem disablePadding>
            <ListItemButton>
              <Row align="middle">
                <Col>
                  <ListItemIcon>{item.icon}</ListItemIcon>
                </Col>
                <Col>
                  <ListItemText
                    sx={{ fontSize: "14px" }}
                    disableTypography
                    primary={item.title}
                  />
                </Col>
              </Row>
            </ListItemButton>
          </ListItem>
          <Divider sx={{ borderColor: "#000" }} />
        </React.Fragment>
      ))}
    </List>
  </Box>
);

export default MyBazzarMenu;
