import { Dispatch, SetStateAction } from "react";

export type ShowCity = {
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

export type MegaMenuProp = {
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