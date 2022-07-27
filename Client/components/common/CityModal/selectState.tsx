import { Box, Grid, Divider } from "@mui/material";
import { Input } from "antd";
import SearchIcon from "@mui/icons-material/Search";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";
import styles from "../../../styles/CityModal.module.css";
import { ShowCity } from "../../../type/allTypes";

const SelectState = ({ onShowCity }: ShowCity): JSX.Element => (
  <>
    <Box sx={{ padding: "24px" }}>
      <h6>انتخاب شهر</h6>
      <br />
      <p>حداقل یک شهر را انتخاب کنید.</p>
      <br />
      <Input
        size="large"
        placeholder="جستجو در شهرها"
        prefix={<SearchIcon sx={{ fill: "#ccc" }} />}
      />
      <br />
    </Box>
    <Divider sx={{ marginTop: "1.3rem", borderColor: "#000" }} />
    <Box sx={{ padding: "10px 24px 24px" }}>
      <Grid
        container
        className={styles.city__names}
        justifyContent="space-between"
        alignItems="center"
        onClick={() => onShowCity(true)}
      >
        <Grid item>
          <span>آذربایجان شرقی</span>
        </Grid>
        <Grid item>
          <ChevronLeftIcon />
        </Grid>
      </Grid>
      <Grid
        container
        className={styles.city__names}
        justifyContent="space-between"
        alignItems="center"
      >
        <Grid item>
          <span>آذربایجان شرقی</span>
        </Grid>
        <Grid item>
          <ChevronLeftIcon />
        </Grid>
      </Grid>
    </Box>
  </>
);

export default SelectState;
