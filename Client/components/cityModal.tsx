import { useSelector, useDispatch } from "react-redux";
import { CITY_MODAL_CLOSED } from "../store/state/ui";
import { CssBaseline } from "@mui/material";
import { useState } from "react";
import { Modal } from "antd";
import { Store } from "../types/type";
import SelectState from "./common/CityModal/selectState";
import SelectCity from "./common/CityModal/selectCity";

const CityModal = (): JSX.Element => {
  // Redux Setup
  const dispatch = useDispatch();
  const { cityModalVisible } = useSelector(
    (state: Store) => state.entities.ui.modals
  );
  // Local State
  const [selectedState, setSelectedState] = useState<number | null>(null);
  // Render
  return (
    <>
      <CssBaseline />
      <Modal
        className="city__modal"
        visible={cityModalVisible}
        closable={false}
        onOk={() => console.log("Done")}
        onCancel={() => dispatch(CITY_MODAL_CLOSED())}
        okText="انتخاب"
        cancelText="انصراف"
        centered
      >
        {selectedState ? (
          <SelectCity
            selectedState={selectedState}
            onSelectState={setSelectedState}
          />
        ) : (
          <SelectState onSelectState={setSelectedState} />
        )}
      </Modal>
    </>
  );
};

export default CityModal;
