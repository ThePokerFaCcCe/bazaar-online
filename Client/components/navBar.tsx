import { useState } from "react";
import MobileNavBar from "./common/NavBar/mobileNavBar";
import DesktopNavBar from "./common/NavBar/desktopNavBar";

const NavBar = (): JSX.Element => {
  const [showMenu, setShowMenu] = useState(false);
  const [showMegaMenu, setShowMegaMenu] = useState(false);
  const [megaMenu2Display, setMegaMenu2Display] = useState("");

  return (
    <>
      <DesktopNavBar
        onShowMenu={showMenu}
        onSetShowMenu={setShowMenu}
        onShowMegaMenu={showMegaMenu}
        onSetShowMegaMenu={setShowMegaMenu}
        onMegaMenu2Display={megaMenu2Display}
        onSetMegaMenuToDisplay={setMegaMenu2Display}
      />
      <MobileNavBar />
    </>
  );
};

export default NavBar;
