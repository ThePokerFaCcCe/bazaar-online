import { Modal, Tabs } from "antd";
import { useSelector, useDispatch } from "react-redux";
import { selectModals, SIGN_MODAL_CLOSED } from "../../store/state/ui";
import { useEffect } from "react";
import { getNavBarInfo } from "../../services/httpService";
import CityModal from "../CityModal";
import MobileNavBar from "./mobileNavBar";
import DesktopNavBar from "./desktopNavBar";
import Register from "../Register";
import Login from "../Login";

const { TabPane } = Tabs;

const NavBar = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  const { signModalVisible } = useSelector(selectModals);

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
