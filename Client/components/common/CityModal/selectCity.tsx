import { Box, Grid, Divider, Checkbox } from "@mui/material";
import { Input } from "antd";
import { ShowCity } from "../../types/type";
import SearchIcon from "@mui/icons-material/Search";
import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import styles from "../../../styles/CityModal.module.css";

const SelectCity = ({ onShowCity }: ShowCity): JSX.Element => {
  return (
    <>
      <Box sx={{ padding: "24px 24px 7px" }}>
        <Box>
          <h6>انتخاب شهر</h6>
        </Box>
        <Box sx={{ margin: "15px 0" }}>
          <p>حداقل یک شهر را انتخاب کنید.</p>
        </Box>
        <Input
          size="large"
          placeholder="جستجو در شهرها"
          prefix={<SearchIcon sx={{ fill: "#ccc" }} />}
        />
      </Box>
      <Divider sx={{ marginTop: "1.3rem", borderColor: "#000" }} />
      <Box
        sx={{
          padding: "5px 24px 24px",
          maxHeight: "300px",
          overflow: "auto",
        }}
      >
        <Grid
          container
          className={styles.city__names}
          alignItems="center"
          onClick={() => onShowCity(false)}
          sx={{ paddingTop: "1rem" }}
        >
          <Grid item>
            <ArrowForwardIcon sx={{ fill: "#656565", margin: "0 5px" }} />
          </Grid>
          <Grid item>
            <span>همه شهرها</span>
          </Grid>
        </Grid>
        <Grid
          container
          className={styles.city__names}
          justifyContent="space-between"
          alignItems="center"
        >
          <Grid item>
            <span>همه شهرهای آذربایجان شرقی</span>
          </Grid>
          <Grid item>
            <Checkbox />
          </Grid>
        </Grid>
        <Grid
          container
          className={styles.city__names}
          justifyContent="space-between"
          alignItems="center"
        >
          <Grid item>
            <span>آذرشهر</span>
          </Grid>
          <Grid item>
            <Checkbox />
          </Grid>
        </Grid>
      </Box>
    </>
  );
};

export default SelectCity;
