import AdPage from "../../../../components/common/Advertisement/adPage";
import axios from "axios";
import { AdPageExtraProps } from "../../../../types/type";

const AdPageExtra = ({ ad }: AdPageExtraProps) => {
  return (
    <>
      <AdPage title="بای" />
    </>
  );
};

export default AdPageExtra;

export const getServerSideProps = async () => {
  const { data } = await axios.get(
    "https://jsonplaceholder.typicode.com/posts"
  );
  return {
    props: {
      ad: data,
    },
  };
};
