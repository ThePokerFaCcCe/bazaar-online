import React, { useMemo, useState } from "react";
import { Menu, MenuProps, Select, Input } from "antd";
import { Box, Grid } from "@mui/material";
import {
  PeopleOutline,
  Key,
  Newspaper,
  Category,
  HistoryEdu,
  MarkunreadSharp,
} from "@mui/icons-material";
import RTL from "../../services/rtl";
import ManageUsers from "../../components/AdminPanel/manageUsers";
import { useRouter } from "next/router";
import styles from "../../styles/Dashboard.module.css";
import { GetServerSideProps } from "next";
import axios from "axios";
import ManageRoles from "../../components/AdminPanel/manageRoles";
import ManageAds from "../../components/AdminPanel/mangeAds";
import ManageCategories from "../../components/AdminPanel/manageCategories";
import ManageFields from "../../components/AdminPanel/manageFields";
import Head from "next/head";
const { Option } = Select;
const { Search } = Input;

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

const App = (): JSX.Element => {
  const [current, setCurrent] = useState("sub1");
  const { query, push, pathname } = useRouter();

  const onClick: MenuProps["onClick"] = ({ key }) => {
    setCurrent(key);
  };
  const categoryToShow = useMemo(() => {
    switch (current) {
      case "sub2":
        return <ManageRoles />;
      case "sub3":
        return <ManageAds />;
      case "sub4":
        return <ManageCategories />;
      case "sub5":
        return <ManageFields />;
      default:
        return <ManageUsers />;
    }
  }, [current]);

  const handleChange = (value: string) => {
    push(`${pathname}?filterBy=${value}`);
  };

  return (
    <>
      <Head>
        <title>بازار آنلاین | پنل مدیریت</title>
      </Head>
      <div className="row">
        <div className="col-sm-9">
          <Box sx={{ p: 2 }}>
            {/* <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <Search placeholder="جستجوی کاربر" style={{ width: "100%" }} />
              </Grid>
              <Grid item xs={12} sm={6}>
                <Select
                  placeholder="مرتب سازی بر اساس"
                  style={{ width: "100%" }}
                  onChange={handleChange}
                >
                  <Option value="oldest">قدیمی ترین</Option>
                  <Option value="newest">جدید ترین</Option>
                </Select>
              </Grid>
            </Grid> */}
            <Box className={styles.users__holder}>{categoryToShow}</Box>
          </Box>
        </div>
        <div className="col-sm-3">
          <Box className="border">
            <Menu
              theme="light"
              onClick={onClick}
              selectedKeys={[current]}
              style={{ width: "100%" }}
              mode="inline"
              items={items}
            />
          </Box>
        </div>
      </div>
    </>
  );
};

// export const getServerSideProps: GetServerSideProps = async () => {
//   const { query } = useRouter();
//   const { data: makes } = await axios.get(
//     "https://jsonplaceholder.typicode.com/posts"
//   );
//   return {
//     props: {
//       make: makes,
//     },
//   };
// };

export default App;
