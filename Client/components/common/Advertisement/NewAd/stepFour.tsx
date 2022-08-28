import { Box, Grid, Typography, Button } from "@mui/material";
import { Select } from "antd";
import { StepsProp, Store } from "../../../../types/type";
import UploadImg from "./upload";
import dynamic from "next/dynamic";
import styles from "../../../../styles/NewAd.module.css";
import { useSelector } from "react-redux";
import Map from "./map";
const { Option } = Select;

const NoSSR = dynamic(() => import("./map"), {
  ssr: false,
});
const StepFour = ({
  onBackToCategories,
  selectedCtg,
  selectedSubCtg,
  selectedSubChildCtg,
}: StepsProp): JSX.Element => {
  // Redux Setup

  const city = useSelector((state: Store) => state.entities.states);
  // CDM
  const onChange = (value: string) => {
    console.log(`selected ${value}`);
  };

  const onSearch = (value: string) => {
    console.log("search:", value);
  };
  return (
    <Box className="NewAd">
      <Grid
        sx={{ mb: "0.3rem" }}
        container
        direction="column"
        alignItems="start"
      >
        <Typography className={styles.create__new_ad}>ثبت آگهی</Typography>
      </Grid>
      <Box
        sx={{
          display: "flex",
          direction: "row",
          justifyContent: "space-between",
          alignItems: "center",
          p: "2rem",
        }}
        className="border"
      >
        <Typography className={styles.category__name}>
          {selectedSubChildCtg?.title ||
            selectedSubCtg?.title ||
            selectedCtg?.title}
        </Typography>
        <Button variant="text" onClick={onBackToCategories}>
          <Typography className={styles.change__category}>
            تغییر دسته بندی
          </Typography>
        </Button>
      </Box>
      <Box className="my-5">
        <Typography className={styles.section__title}>شهر</Typography>
        <Select
          style={{ width: "100%" }}
          showSearch
          placeholder="شهر خود را انتخاب کنید"
          optionFilterProp="children"
          onChange={onChange}
          onSearch={onSearch}
          filterOption={(input, option) =>
            (option!.children as unknown as string)
              .toLowerCase()
              .includes(input.toLowerCase())
          }
        >
          {city?.map((ct: any) => (
            <Option key={ct.id} value={ct.id}>
              {ct.name}
            </Option>
          ))}
        </Select>
      </Box>
      <Box className="my-5">
        <Typography className={styles.section__title}>نقشه</Typography>
        <Typography className={styles.section__text}>
          پس از تعیین محدوده روی نقشه، می‌توانید انتخاب کنید که موقعیت دقیق
          مکانی در آگهی نمایش داده نشود.
        </Typography>
        <Map />
      </Box>
      <Box className="my-5">
        <Typography className={styles.section__title}>عکس آگهی</Typography>
        <Typography className={styles.section__text}>
          عکس‌هایی از فضای داخل و بیرون ملک اضافه کنید. آگهی‌های دارای عکس تا «۳
          برابر» بیشتر توسط کاربران دیده می‌شوند.
        </Typography>
        <UploadImg />
        <Typography className={styles.section__text}>
          تعداد عکس‌های انتخاب شده نباید بیشتر از 5 تا باشد.
        </Typography>
      </Box>
    </Box>
  );
};

export default StepFour;
