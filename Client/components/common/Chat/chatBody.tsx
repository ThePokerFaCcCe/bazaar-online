import { Grid, Box, IconButton } from "@mui/material";
import { Send, AttachFile } from "@mui/icons-material";
import styles from "../../../styles/Chat.module.css";
import { useState, useRef, useEffect } from "react";

const ChatBody = (): JSX.Element => {
  const [input, setInput] = useState("");
  const [chatData, setChatData] = useState([
    { id: 0, txt: "سلام چطوری", time: "16:45" },
    { id: 1, txt: "قربونت داداش خوبم تو چطوری؟", time: "16:45" },
    { id: 0, txt: "هعیک هستیم دیگ", time: "16:55" },
  ]);

  const handleNewMessage = () => {
    if (input) {
      const clone = [...chatData];
      const date = new Date();
      clone.push({
        id: 0,
        txt: input,
        time: `${date.getHours()}:${date.getMinutes()}`,
      });
      setChatData(clone);
      setInput("");
    }
  };

  // Scroll to Last Message
  const messagesEndRef = useRef<null | HTMLDivElement>(null);
  const scrollToBottom = () => {
    messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
  };

  useEffect(() => {
    scrollToBottom();
  }, [chatData]);

  return (
    <div className="col-sm-9 border-end nopadding">
      <div className="d-flex flex-column position-relative">
        <Box className={styles.chat__holder}>
          {chatData.map((chat, index) => {
            return chat.id === 0 ? (
              <Box key={index} className={styles.chat__messageBox}>
                <span className={styles.chat__message_self}>
                  <span className={styles.chat__text}>{chat.txt}</span>
                  <span className={styles.chat__message_time}>{chat.time}</span>
                </span>
              </Box>
            ) : (
              <Box
                key={index}
                sx={{ display: "flex", justifyContent: "end" }}
                className={styles.chat__messageBox}
              >
                <span className={styles.chat__message}>
                  <span className={styles.chat__text}>{chat.txt}</span>
                  <span className={styles.chat__message_time}>{chat.time}</span>
                </span>
              </Box>
            );
          })}
          <div ref={messagesEndRef} />
        </Box>
        <Box className="border p-1">
          <Grid
            container
            direction="row"
            justifyContent="space-between"
            alignItems="center"
          >
            <Grid item xs={10.5} md={11.5}>
              <IconButton onClick={handleNewMessage}>
                <Send sx={{ color: "#A62626" }} />
              </IconButton>
              <input
                onChange={(e) => setInput(e.target.value)}
                value={input}
                className={styles.chat__input}
                placeholder="متنی بنویسید"
              />
            </Grid>
            <Grid item xs={1.5} md={0.5}>
              <IconButton component="label">
                <input hidden accept="image/*" type="file" />
                <AttachFile />
              </IconButton>
            </Grid>
          </Grid>
        </Box>
      </div>
    </div>
  );
};

export default ChatBody;
