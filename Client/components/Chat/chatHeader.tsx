import { Box, IconButton } from "@mui/material";
import { Menu } from "@mui/icons-material";
import styles from "../../styles/Chat.module.css";

const ChatHeader = (): JSX.Element => (
  <>
    <div className="col-xs-12 my-2 border-bottom nopadding">
      <IconButton>
        <Menu />
      </IconButton>
      <span>چت بازار</span>
    </div>
    <div className="col-sm-3 nopadding" style={{ padding: "0" }}>
      <div className="d-flex flex-column borderBottom">
        <Box className={styles.chat__name}>
          <span className="mx-3">IMG</span>
          <span>پستچی بازار</span>
        </Box>
      </div>
    </div>
  </>
);

export default ChatHeader;
