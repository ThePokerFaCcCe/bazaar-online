import AdPage from "../../../../components/common/Advertisement/adPage";
import axios from "axios";

interface UserPageProps {
  ad: object;
}

function UserPage({ ad }: UserPageProps) {
  console.log(ad);
  return (
    <>
      <AdPage title="بای" />
      <AdPage title="سلام" />
    </>
  );
}

export async function getServerSideProps() {
  const { data } = await axios.get(
    "https://jsonplaceholder.typicode.com/posts"
  );
  return {
    props: {
      posts: data,
    },
  };
}

export default UserPage;
