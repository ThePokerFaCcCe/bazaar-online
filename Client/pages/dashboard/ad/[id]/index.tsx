import { AdPageExtraProps } from "../../../../types/type";
import { GetServerSideProps } from "next";
import AdPage from "../../../../components/common/Advertisement/adPage";
import Forbidden from "../../../../components/common/AdminPanel/forbidden";
import config from "../../../../config.json";
import axios from "axios";
import nookies from "nookies";

const AdPageExtra = ({ ad, error }: AdPageExtraProps) => {
  return <>{error ? <Forbidden /> : <AdPage ad={ad} />}</>;
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
