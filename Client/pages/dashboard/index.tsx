import React, { useMemo, useState } from "react";
import { Menu, MenuProps } from "antd";
import { Box } from "@mui/material";
import {
  PeopleOutline,
  Key,
  Newspaper,
  Category,
  HistoryEdu,
} from "@mui/icons-material";
import { useRouter } from "next/router";
import styles from "../../styles/Dashboard.module.css";
import ManageUsers from "../../components/common/AdminPanel/manageUsers";
import ManageRoles from "../../components/common/AdminPanel/manageRoles";
import ManageAds from "../../components/common/AdminPanel/manageAds";
import ManageCategories from "../../components/common/AdminPanel/manageCategories";
import ManageFields from "../../components/common/AdminPanel/manageFields";
import Head from "next/head";

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
  // Local State
  const [current, setCurrent] = useState("sub1");
  const { query, push, pathname } = useRouter();
  //
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
  // Event Handlers
  const onClick: MenuProps["onClick"] = ({ key }) => {
    setCurrent(key);
  };

  const handleChange = (value: string) => {
    push(`${pathname}?filterBy=${value}`);
  };

  // Render
  return (
    <>
      <Head>
        <title>بازار آنلاین | پنل مدیریت</title>
      </Head>
      <div className="row">
        <div className="col-sm-9 order2">
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
        <div className="col-sm-3 order1">
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
