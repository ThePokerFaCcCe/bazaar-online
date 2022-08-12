import { Box, Grid, Divider } from "@mui/material";
import { Input } from "antd";
import SearchIcon from "@mui/icons-material/Search";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";
import styles from "../../../styles/CityModal.module.css";
import { Store } from "../../../types/type";
import { useSelector } from "react-redux";

const SelectState = ({ onSelectState }: any): JSX.Element => {
  // Redux Setup
  const city = useSelector((state: Store) => state.entities.states);
  console.log(city);
  return (
    <>
      <Box sx={{ padding: "24px" }}>
        <h6>انتخاب شهر</h6>
        <br />
        <p>حداقل یک شهر را انتخاب کنید.</p>
        <br />
        <Input
          size="large"
          placeholder="جستجو در شهرها"
          className="searchInput"
          prefix={<SearchIcon sx={{ fill: "#ccc" }} />}
        />
        <br />
      </Box>
      <Divider sx={{ marginTop: "1.3rem", borderColor: "#000" }} />
      <Box className={styles.citylist}>
        {city &&
          city?.map((ct) => {
            return (
              <Grid
                key={ct.id}
                container
                className={styles.city__names}
                justifyContent="space-between"
                alignItems="center"
                onClick={() => onSelectState(true)}
              >
                <Grid item>
                  <span>{ct.name}</span>
                </Grid>
                <Grid item>
                  <ChevronLeftIcon />
                </Grid>
              </Grid>
            );
          })}
      </Box>
    </>
  );
};

export default SelectState;
