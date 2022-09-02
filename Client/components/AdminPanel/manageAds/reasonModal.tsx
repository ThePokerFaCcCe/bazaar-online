import { Modal, Input, Button } from "antd";
import { useDispatch } from "react-redux";
import { ReasonModalProps } from "../../../../types/type";

const ReasonModal = ({
  title,
  reason,
  modalVisibility,
  onHandleOk,
  onCloseModal,
  onSetReason,
}: ReasonModalProps): JSX.Element => {
  const dispatch = useDispatch();

  return (
    <Modal
      title={title}
      visible={modalVisibility}
      footer={[
        <Button
          onClick={() => {
            onSetReason("");
            dispatch(onCloseModal());
          }}
          type="primary"
        >
          لغو
        </Button>,
        <Button danger onClick={() => reason && onHandleOk()} type="primary">
          تایید
        </Button>,
      ]}
    >
      <label htmlFor="reasonInput">دلیل {title}: </label>
      <br />
      <br />
      <Input
        id="reasonInput"
        value={reason}
        placeholder="دلیل را ذکر کنید"
        onChange={({ target }) => onSetReason(target.value)}
      />
    </Modal>
  );
};

export default ReasonModal;
