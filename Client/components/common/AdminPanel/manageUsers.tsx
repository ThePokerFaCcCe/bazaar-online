import { useEffect, useState } from "react";
import { handleGetData as getUsers } from "../../../services/httpService"; // Renaming Import Function
import { UserDashboard } from "../../../types/type";
import isoToPersianDate from "../../../services/isoToPersianDate";
import UserCard from "./userCard";

const ManageUsers = (): JSX.Element => {
  const [users, setUsers] = useState<UserDashboard | []>([]);

  useEffect(() => {
    // I await for it because the data is nested.
    async function getUserList() {
      const { content } = await getUsers("users", setUsers);
      setUsers(content);
    }
    getUserList();
  }, []);
  console.log("user", users);
  return (
    <>
      {users.map?.((user) => (
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
