import { Box, Grid, Divider, Button } from "@mui/material";
import LocationOnOutlinedIcon from "@mui/icons-material/LocationOnOutlined";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import ChatBubbleOutlineOutlinedIcon from "@mui/icons-material/ChatBubbleOutlineOutlined";
import styles from '../styles/NavBar.module.css';
const NavBar = (): JSX.Element => {
  return (
    <Box sx={{padding: '1rem'}}>
      <Grid
        container
        direction="row"
        justifyContent="space-between"
        alignItems="center"
      >
        <Grid item>
          <Grid
            container
            spacing={1}
            direction="row"
            justifyContent="center"
            alignItems="center"
          >
            <Grid item>
              <h4 style={{color:'#A62626'}}>بازار آنلاین</h4>
            </Grid>
            <Grid item>
              |
            </Grid>
            <Grid item>
              <Button className={styles.nav__items} variant="text">
                <LocationOnOutlinedIcon />
                <span className={styles.navbtn__text}>انتخاب شهر</span>
              </Button>
            </Grid>
          </Grid>
        </Grid>
        <Grid item>
        <Grid container direction="row" alignItems="center" spacing={1}>
          <Grid item>
          <Button className={styles.nav__items} variant="text">
            <span>
              <PersonOutlineOutlinedIcon />
            </span>
            <span className={styles.navbtn__text}>بازاره من</span>
          </Button>

          </Grid>
          <Grid item>
          <Button className={styles.nav__items} variant="text">
            <span>
              <ChatBubbleOutlineOutlinedIcon />
            </span>
            <span className={styles.navbtn__text}>چت</span>
          </Button>
          </Grid>
          <Grid item>
          <Button className={styles.nav__items}>پشتیبانی</Button>

          </Grid>
          <Grid item>
          <Button  sx={{ backgroundColor: "#A62626" }} variant="contained">
            ثبت آگهی
          </Button>
          </Grid>
        </Grid>
        </Grid>
      </Grid>
    </Box>
  );
};

export default NavBar;
