import Category from "../components/common/Advertisement/category";
import Card from "../components/common/Advertisement/card";

const Advertisement = (): JSX.Element => {
  return (
    <>
      <div className="row mt-2 mb-5">
        <div className="col-xs-5 col-sm-3">
          <Category />
        </div>
        <div className="col-xs-7 col-sm-9">
          <div className="row gx-0 gy-3 flex-wrap">
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Advertisement;
