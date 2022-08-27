import { useState } from "react";
import { CssBaseline } from "@mui/material";
import { Modal } from "antd";
import { useSelector, useDispatch } from "react-redux";
import { Store } from "../types/type";
import { cityModalToggle } from "../store/state/ui";
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
        onCancel={() => dispatch(cityModalToggle())}
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
