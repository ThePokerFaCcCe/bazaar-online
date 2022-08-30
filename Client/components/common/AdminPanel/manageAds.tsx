import { Box } from "@mui/material";
import Card from "../Advertisement/card";
import { handleGetData as handleGetAds } from "../../../services/httpService";
import Link from "next/link";
import { useEffect, useState } from "react";
import dayjs from "dayjs";
import { Ad } from "../../../types/type";
import timeDiffrence from "../../../services/timeDiffrence";

const ads = [
  { title: "iPhone 13 ProMax 256", href: "/dashboard/ad/1" },
  { title: "iPhone 13 ProMax 512", href: "/dashboard/ad/2" },
];

const ManageAds = (): JSX.Element => {
  const [adList, setAdList] = useState<Ad[] | []>([]);

  // CDM

  useEffect(() => {
    async function getAdsList() {
      // I await for it because the data is nested.
      const { content } = await handleGetAds("Advertiesements/Management/List");
      setAdList(content);
    }

    getAdsList();
  }, []);

  //Render
  return (
    <>
      {adList.map((item) => (
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
