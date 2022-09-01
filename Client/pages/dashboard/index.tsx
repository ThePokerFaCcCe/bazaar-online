import React, { useEffect, useMemo, useState } from "react";
import { Menu, MenuProps } from "antd";
import { Box } from "@mui/material";
import { handleGetData } from "../../services/httpService";
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
import axios from "axios";
import nookies from "nookies";
import config from "../../config.json";
import { GetServerSideProps } from "next";
import { DashboardProps } from "../../types/type";
import { wrapper } from "../../store/configureStore";
import Store from "../../store/configureStore";
import {
  SET_ADS,
  SET_CATEGORIES,
  SET_ROLES,
  SET_USERS,
  SET_PERMISSIONS,
} from "../../store/state/dashboard";
import { useDispatch } from "react-redux";

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

const Dashboard = ({
  ads,
  categories,
  roles,
  users,
  permissions,
}: DashboardProps): JSX.Element => {
  // Local State
  const dispatch = useDispatch();
  const [current, setCurrent] = useState("sub1");
  const { push, pathname } = useRouter();
  // CDM

  useEffect(() => {
    dispatch(SET_USERS(users));
    dispatch(SET_ADS(ads));
    dispatch(SET_CATEGORIES(categories));
    dispatch(SET_ROLES(roles));
    dispatch(SET_PERMISSIONS(permissions));
  }, []);

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

export const getServerSideProps = wrapper.getServerSideProps(
  () => async (context: any) => {
    const { token } = nookies.get(context);
    const header = {
      headers: {
        "Content-Type": "application/json",
        Authorization: `bearer ${token}`,
      },
    };

    const { data: ads } = await axios.get(
      `${config.apiEndPoint}/Advertiesements/Management/List`,
      header
    );
    const { data: users } = await axios.get(
      `${config.apiEndPoint}/users`,
      header
    );
    const { data: roles } = await axios.get(
      `${config.apiEndPoint}/roles`,
      header
    );
    const { data: categories } = await axios.get(
      `${config.apiEndPoint}/categories`,
      header
    );

    const { data: permissions } = await axios.get(
      `${config.apiEndPoint}/permissions`,
      header
    );

    return {
      props: {
        ads: ads.content,
        users: users.content,
        categories,
        roles,
        permissions,
      },
    };
  }
);

export default Dashboard;
