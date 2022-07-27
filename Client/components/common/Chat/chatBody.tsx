import { Grid, Box, IconButton } from "@mui/material";
import { Send, AttachFile } from "@mui/icons-material";
import styles from "../../../styles/Chat.module.css";

const ChatBody = (): JSX.Element => (
  <div className="col-sm-9 border-end nopadding">
    <div className="d-flex flex-column position-relative">
      <Box className={styles.chat__holder}>
        <Box className={styles.chat__messageBox}>
          <span className={styles.chat__message}>
            <span className={styles.chat__text}>سلام چطوری؟</span>
            <span className={styles.chat__message_time}>16:45</span>
          </span>
        </Box>
        <Box
          sx={{ display: "flex", justifyContent: "end" }}
          className={styles.chat__messageBox}
        >
          <span className={styles.chat__message}>
            <span className={styles.chat__text}>
              قربونت داداش خوبم تو چطوری؟
            </span>
            <span className={styles.chat__message_time}>16:45</span>
          </span>
        </Box>
      </Box>
      <Box className="border p-1">
        <Grid
          container
          direction="row"
          justifyContent="space-between"
          alignItems="center"
        >
          <Grid item xs={10.5} md={11.5}>
            <IconButton>
              <Send sx={{ color: "#A62626" }} />
            </IconButton>
            <input className={styles.chat__input} placeholder="متنی بنویسید" />
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

export default ChatBody;

{
  /* <IconButton>
  <Send sx={{ color: "#A62626" }} />
</IconButton>
<input className={styles.chat__input} placeholder="متنی بنویسید" />
<IconButton component="label">
  <input hidden accept="image/*" type="file" />
  <AttachFile />
</IconButton> */
}
