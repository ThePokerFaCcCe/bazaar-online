import { useEffect, useState } from "react";
import { handleGetData as getUsers } from "../../../services/httpService";
import UserCard from "./userCard";
import { UserDashboard } from "../../../types/type";
import isoToPersianDate from "../../../services/isoToPersianDate";
import paginate from "../../../services/paginate";
import { Pagination } from "@mui/material";

const ManageUsers = (): JSX.Element => {
  const [users, setUsers] = useState<UserDashboard | []>([]);

  useEffect(() => {
    if (users.length === 0) {
      // I Did this because the data is nested.
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
      {/* <Pagination
        count={10}
        color="primary"
        sx={{
          position: "absolute",
          bottom: 200,
          direction: "ltr !important",
        }}
      /> */}
    </>
  );
};

export default ManageUsers;
