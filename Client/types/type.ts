import { Dispatch, SetStateAction } from "react";

export type Menus = { title: string; icon: JSX.Element }[];

export type Category = { title: string; link: string; icon: JSX.Element }[];

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
  };
}

export interface StepTwoProps {
  email: string;
}

export interface EmailVerify {
  email: string;
}
