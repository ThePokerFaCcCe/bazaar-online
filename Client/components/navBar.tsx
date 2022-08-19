import { useState } from "react";
import { Modal, Tabs } from "antd";
import { useSelector, useDispatch } from "react-redux";
import { Store } from "../types/type";
import { signModalToggle } from "../store/state/ui";
import RTL from "../services/rtl";
import CityModal from "./cityModal";
import MobileNavBar from "./common/NavBar/mobileNavBar";
import DesktopNavBar from "./common/NavBar/desktopNavBar";
import Register from "./register";
import Login from "./login";
const { TabPane } = Tabs;

const NavBar = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  const { signModalVisible } = useSelector(
    (state: Store) => state.entities.ui.modals
  );

  // Render
  return (
    <>
      <DesktopNavBar />
      <MobileNavBar />
      {/* Modals */}
      <CityModal />
      <Modal
        visible={signModalVisible}
        onCancel={() => dispatch(signModalToggle())}
        footer={null}
      >
        <Tabs defaultActiveKey="1">
          <TabPane tab="ثبت نام" key="1">
            <Register />
          </TabPane>
          <TabPane tab="ورود" key="2">
            <Login />
          </TabPane>
        </Tabs>
      </Modal>
    </>
  );
};

export default NavBar;
