import { ConfigProvider } from "antd";
import { RTLProps } from "types/types";

const RTL = (props: RTLProps) => (
  <ConfigProvider direction="rtl">{props.children}</ConfigProvider>
);

export default RTL;
