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
import { Ad } from "../../../types/type";
import Link from "next/link";
import timeDiffrence from "../../../services/timeDiffrence";
import { AdPageProps } from "../../../types/type";
const items = [
  { title: "ودیعه", value: 900000000 },
  { title: "اجاره ماهانه", value: 7500000 },
  { title: "ودیعه و اجازه", value: "غیر قابل تبدیل" },
  { title: "مناسب برای", value: "خانواده و مجرد" },
];

const AdPage = ({ ad }: AdPageProps): JSX.Element => {
  return (
    <>
      <Box sx={{ margin: "2rem 3rem" }}>
        <Breadcrumb>
          <Breadcrumb.Item>
            <Link href="/">خانه</Link>
          </Breadcrumb.Item>
          <Breadcrumb.Item>
            <Link href="/dashboard">آگهی ها</Link>
          </Breadcrumb.Item>
          <Breadcrumb.Item>{ad.title}</Breadcrumb.Item>
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
              {ad.title}
            </Typography>
            <Typography sx={{ width: "383px" }}>
              <span>{timeDiffrence(ad.createDate)}</span>
              <span> {ad.city.name} |</span>
              <span> {ad.category.title} </span>
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
                    <div> {ad.title}</div>
                    <div>قیمت</div>
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
                <p>{ad.description}</p>
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

export default AdPage;
