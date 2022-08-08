import { useState } from "react";
import { CssBaseline } from "@mui/material";
import { Modal } from "antd";
import { useSelector, useDispatch } from "react-redux";
import { Store } from "../types/type";
import { cityModalToggle } from "../store/state/ui";
import SelectState from "./common/CityModal/selectState";
import SelectCity from "./common/CityModal/selectCity";
import RTL from "../services/rtl";

const CityModal = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  const { cityModalVisible } = useSelector(
    (state: Store) => state.entities.ui.modals
  );
  // Local State
  const [stateSelected, setStateSelected] = useState(false);
  // Render
  return (
    <>
      <CssBaseline />
      <RTL>
        <Modal
          className="city__modal"
          visible={cityModalVisible}
          closable={false}
          onOk={() => console.log("Done")}
          onCancel={() => dispatch(cityModalToggle())}
          okText="انتخاب"
          cancelText="انصراف"
          centered
        >
          {stateSelected ? (
            <SelectCity onSelectState={setStateSelected} />
          ) : (
            <SelectState onSelectState={setStateSelected} />
          )}
        </Modal>
      </RTL>
    </>
  );
};

export default CityModal;
