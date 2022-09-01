import { Box } from "@mui/material";
import Card from "../Advertisement/card";
import Link from "next/link";
import { useEffect, useState } from "react";
import { Ad } from "../../../types/type";
import timeDiffrence from "../../../services/timeDiffrence";
import { useSelector } from "react-redux";
import { selectDashboard } from "../../../store/state/dashboard";

const ManageAds = (): JSX.Element => {
  // Redux Setup
  const { ads } = useSelector(selectDashboard);
  //Render
  return (
    <>
      {ads.map((item) => (
        <Link key={item.id} href={`dashboard/ad/${item.id}`}>
          <Box sx={{ cursor: "pointer" }}>
            <Card
              title={item.title}
              minuets={timeDiffrence(item.createDate)}
              city={item.city.name}
            />
          </Box>
        </Link>
      ))}
    </>
  );
};

export default ManageAds;
