import { useSelector } from "react-redux";
import { selectDashboard } from "../../../store/state/dashboard";
import UserCard from "./userCard";
import isoToPersianDate from "../../../services/isoToPersianDate";

const ManageUsers = (): JSX.Element => {
  // Redux Setup
  const { users } = useSelector(selectDashboard);

  // Render
  return (
    <>
      {users?.map?.((user) => (
        <UserCard
          name={user.fullName}
          key={user.id}
          phoneNumber={user.phoneNumber}
          createDate={isoToPersianDate(user.createDate)}
          status={user.isActive}
          routeHref={user.id}
        />
      ))}
    </>
  );
};

export default ManageUsers;
