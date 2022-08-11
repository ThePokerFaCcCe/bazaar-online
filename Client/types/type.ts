import { Dispatch, SetStateAction } from "react";

export type Menus = { title: string; icon: JSX.Element }[];

export type Category = {
  id: number;
  title: string;
  children?: {}[];
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
  };
}

export interface Card {
  title: string;
}

export interface AdvertisementListProps {
  post: object;
}

export type MegaMenuProps = {
  onSetMegaMenu2Display: Dispatch<SetStateAction<string>>;
};

export type StepsProp = {
  onSetStep: Dispatch<SetStateAction<number>>;
};

export type RTLProps = {
  children: JSX.Element;
};

export type DesktopNavBarProps = {
  onSetMegaMenuToDisplay: Dispatch<SetStateAction<string>>;
  onMegaMenu2Display: string;
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
}
