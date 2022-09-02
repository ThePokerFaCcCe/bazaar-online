import { Select } from "antd";
import { useSelector } from "react-redux";
import { useForm } from "react-hook-form";
import { Box, Grid, Typography, Button } from "@mui/material";
import { StepsProp } from "../../../types/type";
import { newAdCtgHolder } from "../../../styles/AdvertisementSx";
import { selectStore } from "../../../store/state/ui";
import UploadImg from "./upload";
import MapWithNoSSR from "../../AdminPanel/manageAds/MapWithNoSSR";
import ControlledInput from "../../controlledInput";
import ControlledTextArea from "./controlledTextArea";
import ControlledSelect from "./controlledSelect";
import styles from "../../../styles/NewAd.module.css";

const { Option } = Select;

const StepFour = ({
  onBackToCategories,
  selectedCtg,
  selectedSubCtg,
  selectedSubChildCtg,
}: StepsProp): JSX.Element => {
  // Redux Setup
  const { states: city } = useSelector(selectStore);

  // CityList For Select OPTIONS
  const cityList: { value: number; label: string }[] = [];

  city.forEach(({ id: value, name: label }) => {
    cityList.push({ value, label });
  });
  // React Hook Form
  const { control, handleSubmit } = useForm({
    defaultValues: {
      select: {},
      title: "",
      description: "",
      address: "",
      latLng: [],
      cityId: null,
      advertiesementPrice: {
        value: "",
        isAgreement: false,
        type: null,
      },
      categoryId:
        selectedSubChildCtg?.id || selectedSubCtg?.id || selectedCtg?.id,
    },
  });

  const onSubmit = (data: any) => console.log(data);

  // Render
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
      <Box sx={newAdCtgHolder} className="border">
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
      <form onSubmit={handleSubmit(onSubmit)}>
        <Box className="my-5">
          <Typography className={styles.section__title}>شهر</Typography>
          <ControlledSelect
            name="cityId"
            control={control}
            options={cityList}
            placeholder="لطفا شهر خود را انتخاب کنید"
          />
        </Box>
        <Box className="my-5">
          <Typography className={styles.section__title}>نقشه</Typography>
          <Typography className={styles.section__text}>
            پس از تعیین محدوده روی نقشه، می‌توانید انتخاب کنید که موقعیت دقیق
            مکانی در آگهی نمایش داده نشود.
          </Typography>
          <MapWithNoSSR />
        </Box>
        <Box className="my-5">
          <Typography className={styles.section__title}>عکس آگهی</Typography>
          <Typography className={styles.section__text}>
            عکس‌هایی از فضای داخل و بیرون ملک اضافه کنید. آگهی‌های دارای عکس تا
            «۳ برابر» بیشتر توسط کاربران دیده می‌شوند.
          </Typography>
          <UploadImg />
          <Typography className={styles.section__text}>
            تعداد عکس‌های انتخاب شده نباید بیشتر از 5 تا باشد.
          </Typography>
        </Box>
        <Box className="my-5">
          <Typography className={styles.section__title}>عنوان آگهی</Typography>
          <ControlledInput
            name="title"
            control={control}
            placeholder="عنوان را وارد کنید"
          />
        </Box>
        <Box className="my-5">
          <Typography className={styles.section__title}>توضیحات</Typography>
          <ControlledTextArea
            name="description"
            control={control}
            placeholder="توضیحات مربوط به آگهی را وارد کنید"
          />
        </Box>
        <Box className="my-5">
          <Typography className={styles.section__title}>آدرس</Typography>
          <ControlledInput
            name="address"
            control={control}
            placeholder="آدرس خود را وارد کنید"
          />
        </Box>
        <Box className="my-5">
          <Typography className={styles.section__title}>نوع آگهی</Typography>
          <Select style={{ width: "100%" }} placeholder="نوع آگهی را مشخص کنید">
            <Option value="0">فروشی</Option>
            <Option value="1">اجاره ای</Option>
            <Option value="2">درخواستی</Option>
          </Select>
        </Box>
        <button type="submit" className="btn btn-sm btn-primary">
          Click
        </button>
      </form>
    </Box>
  );
};

export default StepFour;
