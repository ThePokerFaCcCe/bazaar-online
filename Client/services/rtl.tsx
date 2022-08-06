import { ConfigProvider } from "antd";
import { RTLProps } from "../types/type";

const RTL = (props: RTLProps) => (
  <ConfigProvider direction="rtl">{props.children}</ConfigProvider>
);

export default RTL;
