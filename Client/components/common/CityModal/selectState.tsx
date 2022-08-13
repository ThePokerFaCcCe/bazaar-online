import { Box, Grid, Divider } from "@mui/material";
import { Input } from "antd";
import SearchIcon from "@mui/icons-material/Search";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";
import styles from "../../../styles/CityModal.module.css";
import { Store, City, CityObj } from "../../../types/type";
import { useSelector } from "react-redux";
import { useState } from "react";

const SelectState = ({ onSelectState }: any): JSX.Element => {
  // Redux Setup
  const city = useSelector((state: Store) => state.entities.states);
  // Local State
  const [search, setSearch] = useState<string>("");
  let filtered: City = [];

  if (search !== null) {
    city.forEach((item: CityObj) => {
      if (item.name.startsWith(search)) filtered.push(item);
    });
  }

  const dataToShow =
    filtered.length > 0
      ? filtered?.map((ct) => {
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
        })
      : city?.map((ct) => {
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
        });

  return (
    <>
      <Box sx={{ padding: "24px" }}>
        <h6>انتخاب شهر</h6>
        <br />
        <p>حداقل یک شهر را انتخاب کنید.</p>
        <br />
        <Input
          onChange={(e) => setSearch(e.target.value)}
          size="large"
          placeholder="جستجو در شهرها"
          className="searchInput"
          prefix={<SearchIcon sx={{ fill: "#ccc" }} />}
        />
        <br />
      </Box>
      <Divider className={styles.divider} />
      <Box className={styles.citylist}>{dataToShow}</Box>
    </>
  );
};

export default SelectState;
