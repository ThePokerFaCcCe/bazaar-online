import { Box } from "@mui/material";
import Card from "../Advertisement/card";
import Link from "next/link";

const ads = [
  { title: "iPhone 13 ProMax 256", href: "/dashboard/ad/1" },
  { title: "iPhone 13 ProMax 512", href: "/dashboard/ad/2" },
];

const ManageAds = (): JSX.Element => {
  return (
    <>
      {ads.map((item) => (
        <Link href={item.href}>
          <Box sx={{ cursor: "pointer" }}>
            <Card title={item.title} />
          </Box>
        </Link>
      ))}
    </>
  );
};

export default ManageAds;
