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
import {
  Bookmark,
  NoteAlt,
  RemoveRedEye,
  PeopleOutline,
} from "@mui/icons-material";
import { Menus } from "../../../types/type";
import { SIGN_MODAL_OPEN, DESKTOP_MENU_CLOSED } from "../../../store/state/ui";
import { useDispatch } from "react-redux";

const menus: Menus = [
  { title: "ثبت نام | ورود", icon: <PeopleOutline /> },
  { title: "نشان شده ها", icon: <Bookmark /> },
  { title: "یادداشت شده ها", icon: <NoteAlt /> },
  { title: "بازدید های اخیر", icon: <RemoveRedEye /> },
];

const MyBazzarMenu = (): JSX.Element => {
  //Redux Setup
  const dispatch = useDispatch();
  // Event Handlers
  const modalToOpen = (title: string) => {
    if (title === "ثبت نام | ورود") {
      dispatch(SIGN_MODAL_OPEN());
      dispatch(DESKTOP_MENU_CLOSED());
      return;
    }
    return null;
  };
  // Render
  return (
    <>
      <Box
        sx={{
          position: "absolute",
          width: "224px",
          left: "-160px",
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
                <ListItemButton onClick={() => modalToOpen(item.title)}>
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
    </>
  );
};

export default MyBazzarMenu;
