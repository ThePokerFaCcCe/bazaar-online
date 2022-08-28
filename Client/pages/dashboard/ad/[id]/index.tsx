import AdPage from "../../../../components/common/Advertisement/adPage";
import axios from "axios";
import nookies from "nookies";
import config from "../../../../config.json";
import { Ad, AdPageExtraProps } from "../../../../types/type";
import { GetServerSideProps } from "next";
import Forbidden from "../../../../components/common/AdminPanel/forbidden";

interface AdPageExtra {
  ad: Ad;
  error: string;
}

const AdPageExtra = ({ ad, error }: AdPageExtra) => {
  return <>{error ? <Forbidden error={error} /> : <AdPage ad={ad} />}</>;
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
  const { data } = await axios.get(
    `${config.apiEndPoint}/Advertiesements/Management/${context.params?.id}`,
    header
  );

  return data
    ? {
        props: {
          ad: data,
        },
      }
    : {
        props: {
          error: "error",
        },
      };
};
