import {
  Box,
  Grid,
  Typography,
  IconButton,
  Button,
  Divider,
  CssBaseline,
} from "@mui/material";
import { Breadcrumb, Input } from "antd";
import styles from "../../../styles/Advertisement.module.css";
import BookmarkBorderOutlinedIcon from "@mui/icons-material/BookmarkBorderOutlined";
import ShareOutlinedIcon from "@mui/icons-material/ShareOutlined";
import axios from "axios";
import Image from "next/image";
import { GetServerSideProps } from "next/types";
import { AdvertisementListProps } from "../../../type/allTypes";
import Link from "next/link";

const items = [
  { title: "ودیعه", value: 900000000 },
  { title: "اجاره ماهانه", value: 7500000 },
  { title: "ودیعه و اجازه", value: "غیر قابل تبدیل" },
  { title: "مناسب برای", value: "خانواده و مجرد" },
];

const AD = ({ post }: AdvertisementListProps): JSX.Element => {
  return (
    <>
      <Box sx={{ margin: "2rem 3rem" }}>
        <Breadcrumb>
          <Breadcrumb.Item>
            <Link href="/">خانه</Link>
          </Breadcrumb.Item>
          <Breadcrumb.Item>
            <Link href="/ad">آگهی ها</Link>
          </Breadcrumb.Item>
          <Breadcrumb.Item>کلاچ اتوماتیک HAC PLUS CENTERAL</Breadcrumb.Item>
        </Breadcrumb>
        <div className="row gx-5">
          <div className="col-sm-4 mt-4">
            <Typography
              sx={{
                fontWeight: "500",
                fontSize: "1.3rem",
                marginBottom: "1rem",
              }}
            >
              کلاچ اتوماتیک HAC PLUS CENTERAL
            </Typography>
            <Typography sx={{ width: "383px" }}>
              لحظاتی پیش در تهران، تهران‌سر | قطعات یدکی و لوازم جانبی خودرو
            </Typography>
            <Grid
              container
              sx={{ marginTop: "3rem" }}
              direction="row"
              justifyContent="space-between"
              alignItems="center"
            >
              <Grid item>
                <Button
                  className={styles.advertisement__button}
                  variant="contained"
                >
                  اطلاعات تماس
                </Button>
              </Grid>
              <Grid item>
                <Grid
                  spacing={3}
                  container
                  justifyContent="center"
                  alignItems="center"
                >
                  <Grid item>
                    <IconButton>
                      <BookmarkBorderOutlinedIcon />
                    </IconButton>
                  </Grid>
                  <Grid item>
                    <IconButton>
                      <ShareOutlinedIcon />
                    </IconButton>
                  </Grid>
                </Grid>
              </Grid>
            </Grid>
            <Box sx={{ margin: "2rem 0 " }}>
              {items.map((item, index) => (
                <Box key={index}>
                  <CssBaseline />
                  {index === 0 ? (
                    <Divider sx={{ borderColor: "#000" }} />
                  ) : null}
                  <div className="d-flex justify-content-between align-items-center p-2">
                    <div>{item.title}</div>
                    <div>{item.value}</div>
                  </div>
                  <Divider sx={{ borderColor: "#000" }} />
                </Box>
              ))}
            </Box>
            <Box>
              <Typography
                sx={{
                  fontSize: "1.4rem",
                  fontWeight: "500",
                  marginBottom: "1rem",
                }}
              >
                توضیحات
              </Typography>
              <Box>
                <p>
                  از فروشگاه معتبر،مطمئن خرید کنیم
                  <br />
                  فروش ویژه ایفون 13
                  <br />
                  6.1"
                  <br />
                  1170x2532 pixels
                  <br />
                  12MP2160p
                  <br />
                  4GB RAMApple A15 Bionic
                  <br />
                  3240mAhLi-Ion
                </p>
                <br />
              </Box>
            </Box>
          </div>
          <div className="col-sm-6">
            <Box sx={{ width: "100%" }}>
              <img
                src="https://s101.divarcdn.com/static/pictures/1658662999/QYwXhPtd.jpg"
                width="100%"
                height="487px"
                style={{ objectFit: "contain" }}
              />
              <Input
                placeholder="یادداشت های شما"
                style={{
                  padding: "5px 1rem 6rem ",
                  margin: "1rem 0",
                  width: "100%",
                }}
              />
              <Typography
                sx={{
                  padding: "0.5rem 0",
                  fontSize: "12px",
                  fontWeight: "500",
                  color: "rgba(0,0,0,.56)",
                }}
              >
                یادداشت تنها برای شما قابل دیدن است و پس از حذف آگهی، پاک خواهد
                شد.
              </Typography>
            </Box>
          </div>
        </div>
      </Box>
    </>
  );
};

export default AD;

export const getServerSideProps: GetServerSideProps = async (context) => {
  console.log("context", context);
  const { data: post } = await axios.get(
    `https://jsonplaceholder.typicode.com/posts/${context?.params?.id}`
  );
  return {
    props: {
      post,
    },
  };
};
