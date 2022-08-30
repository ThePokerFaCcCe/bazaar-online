import {
  Box,
  Grid,
  Typography,
  IconButton,
  Button,
  Divider,
  CssBaseline,
} from "@mui/material";
import {
  adTitle,
  advertiesementButton,
  descriptionHeader,
  noteHint,
  dividerColor,
} from "../../../styles/AdvertisementSx";
import { useState, useMemo } from "react";
import { Breadcrumb, Input } from "antd";
import { BookmarkBorderOutlined, ShareOutlined } from "@mui/icons-material";
import { AdPageProps } from "../../../types/type";
import { toast } from "react-toastify";
import { FileCopy, ContentCopy } from "@mui/icons-material";
import timeDiffrence from "../../../services/timeDiffrence";
import Link from "next/link";
import styles from "../../../styles/Advertisement.module.css";
import MapWithNoSSR from "../AdminPanel/manageAd/MapWithNoSSR";

const items = [
  { title: "ودیعه", value: 900000000 },
  { title: "اجاره ماهانه", value: 7500000 },
  { title: "ودیعه و اجازه", value: "غیر قابل تبدیل" },
  { title: "مناسب برای", value: "خانواده و مجرد" },
];

const AdPage = ({ ad }: AdPageProps): JSX.Element => {
  // Local State
  const [showContactInfo, setShowContactInfo] = useState(false);
  const [loading, setLoading] = useState(false);
  const [copied, setCopied] = useState(false);

  // Event Handler
  const handleCopy = () => {
    navigator.clipboard.writeText(ad.contact.phoneNumber);
    setCopied(true);
    toast.success("شماره موبایل کپی شد");
  };

  const handleShowContact = () => {
    setLoading(true);
    setTimeout(() => {
      setShowContactInfo(true);
      setLoading(false);
    }, 2000);
  };

  // Which Button To Show ? Step => 1-Show Contact 2-Loading... 3-Info is Visible
  const contactBtn = useMemo((): JSX.Element => {
    if (loading) {
      return (
        <Button sx={{ width: "120px" }} variant="contained" disabled>
          ...
        </Button>
      );
    }
    if (showContactInfo) {
      return (
        <Button variant="contained" disabled>
          نمایش داده شد
        </Button>
      );
    }
    return (
      <Button
        sx={advertiesementButton}
        variant="contained"
        onClick={handleShowContact}
      >
        اطلاعات تماس
      </Button>
    );
  }, [loading, showContactInfo]);

  // Render
  return (
    <>
      <Box sx={{ m: "2rem 3rem" }}>
        <Breadcrumb>
          <Breadcrumb.Item>
            <Link href="/">خانه</Link>
          </Breadcrumb.Item>
          <Breadcrumb.Item>
            <Link href="/dashboard">پنل مدیریت</Link>
          </Breadcrumb.Item>
          <Breadcrumb.Item>{ad.title}</Breadcrumb.Item>
        </Breadcrumb>
        <div className="row gx-5">
          <div className="col-sm-4 mt-4">
            <Typography sx={adTitle}>{ad.title}</Typography>
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
              <Grid item>{contactBtn}</Grid>
              <Grid item>
                <Grid
                  spacing={3}
                  container
                  justifyContent="center"
                  alignItems="center"
                >
                  <Grid item>
                    <IconButton>
                      <BookmarkBorderOutlined />
                    </IconButton>
                  </Grid>
                  <Grid item>
                    <IconButton>
                      <ShareOutlined />
                    </IconButton>
                  </Grid>
                </Grid>
              </Grid>
            </Grid>
            {showContactInfo && (
              <Box sx={{ m: "2rem 0" }} className="contactSection">
                <Grid
                  container
                  direction="row"
                  alignItems="center"
                  justifyContent="space-between"
                >
                  <Grid item>
                    <Typography>شماره موبایل</Typography>
                  </Grid>
                  <Grid item>
                    <Grid container alignItems="center" spacing={2}>
                      <Grid item>
                        <Typography>{ad.contact.phoneNumber}</Typography>
                      </Grid>
                      <Grid item>
                        <IconButton onClick={handleCopy}>
                          {copied ? <FileCopy /> : <ContentCopy />}
                        </IconButton>
                      </Grid>
                    </Grid>
                  </Grid>
                </Grid>
              </Box>
            )}
            <Box sx={{ m: "2rem 0 " }}>
              {items.map((item, index) => (
                <Box key={index}>
                  <CssBaseline />
                  {index === 0 ? <Divider sx={dividerColor} /> : null}
                  <div className="d-flex justify-content-between align-items-center p-2">
                    <div> {ad.title}</div>
                    <div>قیمت</div>
                  </div>
                  <Divider sx={dividerColor} />
                </Box>
              ))}
            </Box>
            <Box>
              <Typography sx={descriptionHeader}>توضیحات</Typography>
              <Box>
                <p>{ad.description}</p>
                <br />
              </Box>
            </Box>
          </div>
          <div className="col-sm-8">
            <Box sx={{ width: "100%" }}>
              <img
                src="https://s101.divarcdn.com/static/pictures/1658662999/QYwXhPtd.jpg"
                className={styles.ad__img}
              />
              <Input
                placeholder="یادداشت های شما"
                className={styles.note__input}
              />
              <Typography sx={noteHint}>
                یادداشت تنها برای شما قابل دیدن است و پس از حذف آگهی، پاک خواهد
                شد.
              </Typography>
            </Box>
            {ad.latitude && ad.longitude && (
              <MapWithNoSSR marker={[ad.latitude, ad.longitude]} />
            )}
          </div>
        </div>
      </Box>
    </>
  );
};

export default AdPage;
