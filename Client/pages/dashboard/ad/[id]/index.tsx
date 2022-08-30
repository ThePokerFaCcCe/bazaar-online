import { AdPageExtraProps } from "../../../../types/type";
import { GetServerSideProps } from "next";
import { useState } from "react";
import { toast } from "react-toastify";
import { useRouter } from "next/router";
import AdPage from "../../../../components/common/Advertisement/adPage";
import Forbidden from "../../../../components/common/AdminPanel/forbidden";
import config from "../../../../config.json";
import AdButton from "../../../../components/common/AdminPanel/manageAd/adButton";
import ReasonModal from "../../../../components/common/AdminPanel/manageAd/reasonModal";
import {
  confirmAd,
  deleteAd,
  rejectAd,
} from "../../../../services/httpService";
import axios from "axios";
import nookies from "nookies";

const AdPageExtra = ({ ad, error }: AdPageExtraProps) => {
  // Local State
  const { push } = useRouter();
  const [showRejectModal, setShowRejectModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [rejectReason, setRejectReason] = useState("");
  const [deleteReason, setDeleteReason] = useState("");

  // Handle 404 ERROR
  const handle404Error = (response: any) => {
    if (response.status === 404) toast.error("آگهی با این شناسه یافت نشد");
  };

  // Event Handlers
  const handleConfirm = async () => {
    try {
      await confirmAd(ad.id);
      toast.success("آگهی با موفقیت تایید شد");
      push("/dashboard");
    } catch ({ response }) {
      handle404Error(response);
      // TODO: Replace catch block with handleExpectedError if Backend add errors prop to response
    }
  };

  const handleReject = async () => {
    try {
      await rejectAd(ad.id, rejectReason);
      toast.success("آگهی با موفقیت رد شد");
      push("/dashboard");
    } catch ({ response }) {
      handle404Error(response);
      // TODO: Replace catch block with handleExpectedError if Backend add errors prop to response
    }
  };

  const handleDelete = async () => {
    try {
      await deleteAd(ad.id, deleteReason);
      toast.success("آگهی با موفقیت حذف شد");
      push("/dashboard");
    } catch ({ response }) {
      handle404Error(response);
      // TODO: Replace catch block with handleExpectedError if Backend add errors prop to response
    }
  };
  // Render
  return (
    <>
      {error ? (
        <Forbidden />
      ) : (
        <div>
          <div
            style={{ position: "fixed", bottom: 0, zIndex: 9999 }}
            className="d-flex flex-column gy-5 gx-5"
          >
            <AdButton
              title="تایید آگهی"
              color="success"
              onClick={handleConfirm}
            />
            <AdButton
              title="رد آگهی"
              color="warning"
              onClick={() => setShowRejectModal(true)}
            />
            <AdButton
              title="حذف آگهی"
              color="error"
              onClick={() => setShowDeleteModal(true)}
            />
          </div>
          <AdPage ad={ad} />
        </div>
      )}
      <ReasonModal
        title="رد آگهی"
        modalVisibility={showRejectModal}
        onHandleOk={handleReject}
        onCloseModal={setShowRejectModal}
        reason={rejectReason}
        onSetReason={setRejectReason}
      />
      <ReasonModal
        title="حذف آگهی"
        modalVisibility={showDeleteModal}
        onHandleOk={handleDelete}
        onCloseModal={setShowDeleteModal}
        reason={deleteReason}
        onSetReason={setDeleteReason}
      />
    </>
  );
};

export default AdPageExtra;

export const getServerSideProps: GetServerSideProps = async (context) => {
  const { token } = nookies.get(context);
  const header = {
    headers: {
      "Content-Type": "application/json",
      Authorization: `bearer ${token}`,
    },
  };
  // api call
  try {
    const { data: ad } = await axios.get(
      `${config.apiEndPoint}/Advertiesements/Management/${context.params?.id}`,
      header
    );

    return {
      props: {
        ad,
      },
    };
  } catch (ex) {
    return {
      props: {
        error: "error",
      },
    };
  }
};
