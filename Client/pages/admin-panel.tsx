import React, { useState } from "react";
import { Menu, MenuProps } from "antd";
import Box from "@mui/material/Box";
import {
  PeopleOutline,
  Key,
  Newspaper,
  Category,
  HistoryEdu,
} from "@mui/icons-material";
import RTL from "../services/rtl";
import UserCard from "../components/common/AdminPanel/userCard";

type MenuItem = Required<MenuProps>["items"][number];

function getItem(
  label: React.ReactNode,
  key?: React.Key | null,
  icon?: React.ReactNode,
  children?: MenuItem[],
  type?: "group"
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
    type,
  } as MenuItem;
}

const items: MenuItem[] = [
  getItem(
    "مدیریت کاربران",
    "sub1",
    <PeopleOutline style={{ fontSize: "1.3rem" }} />,
    undefined
  ),
  getItem(
    "مدیریت نقش ها",
    "sub2",
    <Key style={{ fontSize: "1.3rem" }} />,
    undefined
  ),
  getItem(
    "مدیریت آگهی ها",
    "sub3",
    <Newspaper style={{ fontSize: "1.3rem" }} />,
    undefined
  ),
  getItem(
    "مدیریت دسته بندی ها ",
    "sub4",
    <Category style={{ fontSize: "1.3rem" }} />,
    undefined
  ),
  getItem(
    "مدیریت فیلد ها",
    "sub5",
    <HistoryEdu style={{ fontSize: "1.3rem" }} />,
    undefined
  ),
];

const App: React.FC = () => {
  const [current, setCurrent] = useState("1");

  const onClick: MenuProps["onClick"] = ({ key }) => {
    console.log(key);
    setCurrent(key);
  };
  return (
    <>
      <Box>
        <div className="row">
          <div className="col-sm-9">
            <Box
              sx={{
                mt: 3,
                display: "flex",
                flexWrap: "wrap",
                gap: "5px",
                justifyContent: "center",
              }}
            >
              <UserCard
                name="پدرام"
                email="pedran.az@Gmail.com"
                createDate="1399/12/26"
                status={true}
              />
              <UserCard
                name="متین "
                email="soltane.gham@Gmail.com"
                createDate="1400/12/28"
                status={false}
              />
            </Box>
          </div>
          <div className="col-sm-3">
            <Box className="border">
              <RTL>
                <Menu
                  theme="light"
                  onClick={onClick}
                  defaultOpenKeys={["sub1"]}
                  selectedKeys={[current]}
                  style={{ width: "100%" }}
                  mode="inline"
                  items={items}
                />
              </RTL>
            </Box>
          </div>
        </div>
      </Box>
    </>
  );
};

export default App;
