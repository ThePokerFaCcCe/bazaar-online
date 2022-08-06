import { Dispatch, SetStateAction } from "react";

export type SelectCityProps = {
  onShowCity(value: boolean): void;
};

export type Menus = { title: string; icon: JSX.Element }[];

export type Category = { title: string; link: string; icon: JSX.Element }[];

export interface Card {
  title: string;
}

export interface AdvertisementListProps {
  post: object;
}

export type MegaMenuProps = {
  onSetShowMegaMenu: Dispatch<SetStateAction<boolean>>;
  onSetMegaMenu2Display: Dispatch<SetStateAction<string>>;
};

export type StepsProp = {
  onSetStep: Dispatch<SetStateAction<number>>;
};

export type RTLProps = {
  children: JSX.Element;
};

export type DesktopNavBarProps = {
  onSetShowMenu: Dispatch<SetStateAction<boolean>>;
  onSetShowMegaMenu: Dispatch<SetStateAction<boolean>>;
  onSetMegaMenuToDisplay: Dispatch<SetStateAction<string>>;
  onShowMenu: boolean;
  onShowMegaMenu: boolean;
  onMegaMenu2Display: string;
};

export type NavItems = { title: string; icon: JSX.Element }[];

export interface CityModal {
  onOk: () => void;
  onCloseModal: () => void;
  onSetShowCity: Dispatch<SetStateAction<boolean>>;
  modalVisible: boolean;
  showCity: boolean;
}

export interface LoginModalProps {
  onShowLogin: boolean;
  onLogin: () => void;
  onCloseLogin: () => void;
}

export interface MyBazzarMenuProps {
  onSetShowLogin: () => void;
  onSetShowRegister: () => void;
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
  onFormikChange: (e: any) => void;
}
