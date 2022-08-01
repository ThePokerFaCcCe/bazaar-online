import { Box, Button } from "@mui/material";
import { useState } from "react";
import Category from "../components/common/Advertisement/category";
import Card from "../components/common/Advertisement/card";
import { Sidebar } from "primereact/sidebar";
import CloseIcon from "@mui/icons-material/Close";

const Advertisement = (): JSX.Element => {
  const [visible, setVisible] = useState(false);
  return (
    <>
      <div className="row mt-2 mb-5">
        <div className="col-xs-5 col-sm-3">
          <div className="mobile__category">
            <Button
              sx={{ margin: "1rem" }}
              variant="outlined"
              onClick={() => setVisible(true)}
            >
              نمایش منو دسته بندی
            </Button>
            <Sidebar
              icons={() => <CloseIcon onClick={() => setVisible(false)} />}
              showCloseIcon={false}
              position="right"
              visible={visible}
              onHide={() => setVisible(false)}
            >
              <Box sx={{ direction: "rtl" }}>
                <Category />
              </Box>
            </Sidebar>
          </div>
          <div className="desktop__category">
            <Category />
          </div>
        </div>
        <div className="col-xs-7 col-sm-9">
          <div className="row gx-0 gy-3 flex-wrap">
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Advertisement;
