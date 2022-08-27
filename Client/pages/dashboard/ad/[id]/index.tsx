import AdPage from "../../../../components/common/Advertisement/adPage";
import axios from "axios";

const AdPageExtra = (props) => {
  console.log("props", props);
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
      posts: data,
    },
  };
};
