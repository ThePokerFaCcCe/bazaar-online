import { Box, Grid, Typography, Button } from "@mui/material";
import { Select } from "antd";
import styles from "../../../../styles/NewAd.module.css";
import { Category, StepsProp } from "../../../../type/allTypes";
import RTL from "../../../../services/rtl";
import { PlusOutlined } from "@ant-design/icons";
import { Modal, Upload } from "antd";
import type { RcFile, UploadProps } from "antd/es/upload";
import type { UploadFile } from "antd/es/upload/interface";
import React, { useState } from "react";

const { Option } = Select;

const getBase64 = (file: RcFile): Promise<string> =>
  new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result as string);
    reader.onerror = (error) => reject(error);
  });

const StepOne = ({ onSetStep }: StepsProp): JSX.Element => {
  const [previewVisible, setPreviewVisible] = useState(false);
  const [previewImage, setPreviewImage] = useState("");
  const [previewTitle, setPreviewTitle] = useState("");
  const [fileList, setFileList] = useState<UploadFile[]>([]);

  const handleCancel = () => setPreviewVisible(false);

  const handlePreview = async (file: UploadFile) => {
    if (!file.url && !file.preview) {
      file.preview = await getBase64(file.originFileObj as RcFile);
    }

    setPreviewImage(file.url || (file.preview as string));
    setPreviewVisible(true);
    setPreviewTitle(
      file.name || file.url!.substring(file.url!.lastIndexOf("/") + 1)
    );
  };

  const handleChange: UploadProps["onChange"] = ({ fileList: newFileList }) =>
    setFileList(newFileList);

  const uploadButton = (
    <div>
      <PlusOutlined />
      <div style={{ marginTop: 8 }}>آپلود</div>
    </div>
  );

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
        <Typography className={styles.category__name}>نام دسته‌بندی</Typography>
        <Button variant="text" onClick={() => onSetStep(1)}>
          <Typography className={styles.change__category}>
            تغییر دسته بندی
          </Typography>
        </Button>
      </Box>
      <Box className="my-5">
        <Typography className={styles.section__title}>شهر</Typography>
        <RTL>
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
            <Option value="rasht">رشت</Option>
            <Option value="tehran">تهران</Option>
            <Option value="isfahan">اصفهان</Option>
          </Select>
        </RTL>
      </Box>
      <Box className="my-5">
        <Typography className={styles.section__title}>نقشه</Typography>
        <Typography className={styles.section__text}>
          پس از تعیین محدوده روی نقشه، می‌توانید انتخاب کنید که موقعیت دقیق
          مکانی در آگهی نمایش داده نشود.
        </Typography>
        <span>MAP HERE</span>
      </Box>
      <Box className="my-5">
        <Typography className={styles.section__title}>عکس آگهی</Typography>
        <Typography className={styles.section__text}>
          عکس‌هایی از فضای داخل و بیرون ملک اضافه کنید. آگهی‌های دارای عکس تا «۳
          برابر» بیشتر توسط کاربران دیده می‌شوند.
        </Typography>
        <div className="mt-3">
          <Upload
            action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
            listType="picture-card"
            fileList={fileList}
            onPreview={handlePreview}
            onChange={handleChange}
          >
            {fileList.length >= 8 ? null : uploadButton}
          </Upload>
          <Modal
            visible={previewVisible}
            title={previewTitle}
            footer={null}
            onCancel={handleCancel}
          >
            <img alt="example" style={{ width: "100%" }} src={previewImage} />
          </Modal>
        </div>
        <Typography className={styles.section__text}>
          تعداد عکس‌های انتخاب شده نباید بیشتر از 5 تا باشد.
        </Typography>
      </Box>
    </Box>
  );
};

export default StepOne;
