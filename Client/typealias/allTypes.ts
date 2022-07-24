export type ShowCity = {
  onShowCity(value: boolean): void;
};

export type Menus = [
  {
    title: string;
    icon: JSX.Element;
  },
  {
    title: string;
    icon: JSX.Element;
  },
  {
    title: string;
    icon: JSX.Element;
  },
  {
    title: string;
    icon: JSX.Element;
  }
];

export type Category = [
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element },
  { title: string; link: string; icon: JSX.Element }
];

export interface Card {
  title: string;
}
