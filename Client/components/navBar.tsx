import { useState } from "react";
import { Modal, Tabs } from "antd";
import MobileNavBar from "./common/NavBar/mobileNavBar";
import DesktopNavBar from "./common/NavBar/desktopNavBar";
import Register from "./register";
import Login from "./login";
import { useSelector, useDispatch } from "react-redux";
import { Store } from "../types/type";
import { signModalToggle } from "../store/state/ui";
import RTL from "../services/rtl";
import CityModal from "./cityModal";
const { TabPane } = Tabs;

const NavBar = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  const { signModalVisible } = useSelector(
    (state: Store) => state.entities.ui.modals
  );
  // Local State
  const [showMegaMenu, setShowMegaMenu] = useState(false);
  const [megaMenu2Display, setMegaMenu2Display] = useState("");

  return (
    <>
      <DesktopNavBar
        onShowMegaMenu={showMegaMenu}
        onSetShowMegaMenu={setShowMegaMenu}
        onMegaMenu2Display={megaMenu2Display}
        onSetMegaMenuToDisplay={setMegaMenu2Display}
      />
      <MobileNavBar />
      {/* Modals */}
      <RTL>
        <>
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
      </RTL>
    </>
  );
};

export default NavBar;
