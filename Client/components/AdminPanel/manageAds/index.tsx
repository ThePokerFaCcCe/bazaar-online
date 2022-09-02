import { Box } from "@mui/material";
import { useSelector } from "react-redux";
import { selectDashboard } from "../../../store/state/dashboard";
import Link from "next/link";
import Card from "../../Advertisement/card";
import timeDiffrence from "../../../services/timeDiffrence";

const ManageAds = (): JSX.Element => {
  // Redux Setup
  const { ads } = useSelector(selectDashboard);
  console.log("Ads", ads);
  //Render
  return (
    <>
      {ads &&
        ads?.map?.((item) => (
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
