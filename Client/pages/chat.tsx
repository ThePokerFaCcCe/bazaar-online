import { Box } from "@mui/material";
import ChatHeader from "../components/common/Chat/chatHeader";
import ChatBody from "../components/common/Chat/chatBody";
const Chat = (): JSX.Element => {
  return (
    <>
      <Box sx={{ margin: "1rem 5rem" }}>
        <div className="row justify-content-center border">
          <ChatHeader />
          <ChatBody />
        </div>
      </Box>
    </>
  );
};

export default Chat;
