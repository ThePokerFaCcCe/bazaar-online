const isoToPersianDate = (date: string) =>
  new Date(date).toLocaleDateString("fa-IR");

export default isoToPersianDate;
