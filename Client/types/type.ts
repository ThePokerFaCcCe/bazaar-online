import { CheckboxChangeEvent } from "antd/lib/checkbox";
import { Dispatch, SetStateAction } from "react";

export type Menus = { title: string; icon: JSX.Element }[];

export type Category = {
  id: number;
  title: string;
  children?: {}[];
  icon: string | null;
  parentId: number | null;
}[];

export type CategoryArrayWithChildren = {
  id: number;
  title: string;
  children?: Category[];
  icon: string | null;
  parentId: number | null;
}[];

export type CategoryObject = {
  id: number;
  title: string;
  children?: Category[];
  icon: string | null;
  parentId: number | null;
};
export type CategoryObjectWithChildren = {
  id: number;
  title: string;
  children?: CategoryObject[];
  icon: string | null;
  parentId: number | null;
};

export interface Store {
  entities: {
    isLoggedIn: boolean;
    ui: {
      modals: {
        signModalVisible: boolean;
        cityModalVisible: boolean;
      };
      navbar: {
        desktopMenuVisible: boolean;
        mobileMenuVisible: boolean;
        megaMenuVisible: boolean;
      };
    };
    category: {
      id: number;
      title: string;
      children?: {}[];
      icon: string | null;
      parentId: number | null;
    }[];
    states: { id: number; name: string }[];
  };
}

export interface Card {
  title: string;
  minuets: string;
  city: string;
}

export interface AdvertisementListProps {
  title: string;
}

export type StepsProp = {
  onNextStep: (parameter: any) => void;
  selectedCtg?: CategoryObjectWithChildren;
  selectedSubCtg?: CategoryObjectWithChildren;
  selectedSubChildCtg?: CategoryObjectWithChildren;
  onBackToCategories?: () => void;
};

export type RTLProps = {
  children: JSX.Element;
};

export type NavItems = { title: string; icon: JSX.Element }[];

export interface CityModal {
  onOk: () => void;
}

export interface User {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  password: string;
}

export type InputOnChange = React.KeyboardEvent<HTMLInputElement>;

export interface StepOneProps {
  onShowTerms: boolean;
  onSetTerms: Dispatch<SetStateAction<boolean>>;
  onFormik: any;
}

export interface CategoryStepOneProps {
  icons: JSX.Element[];
  onSelectCategory: (
    handleSelectCategory: Dispatch<SetStateAction<string>>
  ) => void;
}

export interface StepTwoProps {
  email: string;
}

export interface EmailVerify {
  email: string;
}

// Redux
export interface State {
  dispatch: (parameter: any) => void;
  getState: () => Store;
}

export type Next = (action: Action) => void;

export interface Action {
  type: string;
  payload: unknown;
}

//
export interface CategoryStepTwoProps {
  selectedCategory: CategoryObjectWithChildren;
  onSelectCategory: (params: any) => void;
}
export interface CategoryStepThreeProps {
  selectedChildren: CategoryObjectWithChildren;
  onSelectCategory: (params: any) => void;
  selectedCategory: CategoryObjectWithChildren;
}

export type City = { id: number; name: string }[];
export type CityObj = { id: number; name: string };

export interface UserCardProps {
  name: string;
  phoneNumber: string;
  createDate: string;
  status: boolean;
  routeHref: number;
}

export interface UserActive {
  code: string;
  email: string;
}

export interface LoginUser {
  phoneNumber: string;
  password: string;
}

export type UserDashboard = {
  createDate: string;
  phoneNumber: string;
  fullName: string;
  id: number;
  isActive: boolean;
}[];

export type Roles = {
  id: string;
  title: string;
}[];

export type GetUsersProp = Dispatch<SetStateAction<UserDashboard | []>>;
export type GetRolesProp = Dispatch<SetStateAction<any>>;

export interface RolePagesProps {
  roles: Roles | [];
}
export interface ChangeRoleProps {
  roles: Roles | [];
  permissions: Permissions[];
}

export interface ManageCategoriesProps {
  categories: Category | [];
}

export interface Permissions {
  groupTitle: string;
  permissions: { id: number; title: string }[];
}
export interface NewRoleProps {
  permissions: Permissions[];
}

export interface NewRoleData {
  title: string;
  permissions: number[];
}

export interface Cities {
  id: number;
  name: string;
}

export interface Ad {
  id: number;
  title: string;
  description: string;
  nullable: boolean;
  deniedByAdminReason: string;
  isDeniedByAdmin: boolean;
  deletedByAdminReason: string;
  isDeletedByAdmin: boolean;
  latitude: number;
  longitude: number;
  isDeleted: boolean;
  isAccepted: boolean;
  createDate: string;
  category: { id: number; title: string };
  city: { id: number; name: string };
  price: {
    value: null | number;
    isAgreement: boolean;
    priceType: number;
    priceTypeName: string;
  };
  picture: { image: string; thumbnail: string };
}

export interface AdPageExtraProps {
  ad: Ad;
  error: string;
}

export interface DashboardUserPage {
  createDate: string;
  phoneNumber: string;
  fullName: string;
  firstName: string;
  lastName: string;
  password: string;
  id: number;
  email: string;
  isActive: boolean;
  isDeleted: boolean;
  isEmailActive: boolean;
  roles: { id: number; title: string }[];
}

export interface DashboardUserProps {
  user: DashboardUserPage;
  error: "error";
}

export interface AdPageProps {
  ad: Ad;
}

export interface DashboardInputProps {
  placeholder: string;
  name: string;
  value: string;
  onChange: ({ target }: InputOnChange) => void;
}

export interface DashboardCheckboxProps {
  title: string;
  name: string;
  defaultChecked: boolean;
  onChange: ({ target }: CheckboxChangeEvent) => void;
  conditionAndTxt: string;
}

export interface DashboardUserFormProps {
  user: DashboardUserPage;
  onHandleChange: ({ target }: InputOnChange) => void;
  onCheckboxChange: ({ target }: CheckboxChangeEvent) => void;
  onModify: () => void;
  onDelete: () => void;
}

export interface Map {
  center?: [number, number];
  marker?: [number, number];
}
