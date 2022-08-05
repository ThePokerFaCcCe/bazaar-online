import React, { useState } from "react";
import { CssBaseline } from "@mui/material";
import { Button, Modal, ConfigProvider } from "antd";
import SelectState from "./common/CityModal/selectState";
import SelectCity from "./common/CityModal/selectCity";
import { CityModal } from "../types/type";


const CityModal = ({ onOk, onCloseModal, onSetShowCity, modalVisible, showCity }: CityModal): JSX.Element => {
  return (
    <>
      <CssBaseline />
      <ConfigProvider direction="rtl">
        <Modal
          className="city__modal"
          visible={modalVisible}
          closable={false}
          onOk={onOk}
          onCancel={onCloseModal}
          okText="انتخاب"
          cancelText="انصراف"
          centered
        >
          {showCity ? (
            <SelectCity onShowCity={onSetShowCity} />
          ) : (
            <SelectState onShowCity={onSetShowCity} />
          )}
        </Modal>
      </ConfigProvider>
    </>
  );
};

export default CityModal;
