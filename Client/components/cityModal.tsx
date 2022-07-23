import { useState } from "react";
import { CssBaseline } from "@mui/material";
import { Button, Modal, ConfigProvider } from "antd";
import SelectState from "./common/CityModal/selectState";
import SelectCity from "./common/CityModal/selectCity";

const CityModal = (): JSX.Element => {
  const [visible, setVisible] = useState(false);
  const [confirmLoading, setConfirmLoading] = useState(false);
  const [showCity, setShowCity] = useState(false);
  const handleOk = (): void => {
    setConfirmLoading(true);
    setTimeout(() => {
      setVisible(false);
      setConfirmLoading(false);
    }, 2000);
  };

  const showModal = (): void => {
    setVisible(true);
  };

  const closeModal = (): void => {
    setVisible(false);
  };

  console.log(showCity);
  return (
    <>
      <CssBaseline />
      <Button type="primary" onClick={showModal}>
        Open Modal with async logic
      </Button>
      <ConfigProvider direction="rtl">
        <Modal
          className="city__modal"
          visible={visible}
          closable={false}
          onOk={handleOk}
          onCancel={closeModal}
          okText="انتخاب"
          cancelText="انصراف"
          centered
        >
          {showCity ? (
            <SelectCity onShowCity={setShowCity} />
          ) : (
            <SelectState onShowCity={setShowCity} />
          )}
        </Modal>
      </ConfigProvider>
    </>
  );
};

export default CityModal;
