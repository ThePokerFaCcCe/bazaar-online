import { Modal, Tabs } from "antd";
import { useSelector, useDispatch } from "react-redux";
import { Store } from "../types/type";
import { SIGN_MODAL_CLOSED } from "../store/state/ui";
import CityModal from "./cityModal";
import MobileNavBar from "./common/NavBar/mobileNavBar";
import DesktopNavBar from "./common/NavBar/desktopNavBar";
import Register from "./register";
import Login from "./login";
import { useEffect } from "react";
import { getNavBarInfo } from "../services/httpService";

const { TabPane } = Tabs;

const NavBar = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  const { signModalVisible } = useSelector(
    (state: Store) => state.entities.ui.modals
  );

  useEffect(() => {
    getNavBarInfo(dispatch);
  }, []);

  return (
    <>
      <DesktopNavBar />
      <MobileNavBar />
      {/* Modals */}
      <CityModal />
      <Modal
        visible={signModalVisible}
        onCancel={() => dispatch(SIGN_MODAL_CLOSED())}
        footer={null}
      >
        <Tabs defaultActiveKey="1">
          <TabPane tab="ورود" key="1">
            <Login />
          </TabPane>
          <TabPane tab="ثبت نام" key="2">
            <Register />
          </TabPane>
        </Tabs>
      </Modal>
    </>
  );
};

export default NavBar;
