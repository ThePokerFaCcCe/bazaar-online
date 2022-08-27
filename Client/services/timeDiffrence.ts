import dayjs from "dayjs";

const timeDiffrence = (date: string): string => {
  const createdDate = dayjs(date);
  const diffByMin = createdDate.diff(dayjs(), "minute").toString().slice(1);
  const diffByHour = createdDate.diff(dayjs(), "hour").toString().slice(1);
  const diffByDay = createdDate.diff(dayjs(), "day").toString().slice(1);

  if (+diffByMin > 1400) {
    return `${diffByDay} روز پیش در `;
  }
  if (+diffByMin > 60) {
    return `${diffByHour} ساعت پیش در `;
  }
  return `${diffByMin} دقیقه پیش در `;
};

export default timeDiffrence;
