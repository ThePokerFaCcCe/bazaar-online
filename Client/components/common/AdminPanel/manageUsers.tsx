import { useEffect, useState } from "react";
import { handleGetData as getUsers } from "../../../services/httpService"; // Renaming Import Function
import { UserDashboard } from "../../../types/type";
import isoToPersianDate from "../../../services/isoToPersianDate";
import UserCard from "./userCard";

const ManageUsers = (): JSX.Element => {
  const [users, setUsers] = useState<UserDashboard | []>([]);

  useEffect(() => {
    if (users.length === 0) {
      // I await for it because the data is nested.
      async function getUserList() {
        const { content } = await getUsers("users", setUsers);
        setUsers(content);
      }
      getUserList();
    }
  }, []);

  return (
    <>
      {users.map?.((user) => (
        <UserCard
          name={user.fullName}
          key={user.id}
          email={user.email}
          createDate={isoToPersianDate(user.createDate)}
          status={user.isActive}
        />
      ))}
    </>
  );
};

export default ManageUsers;
