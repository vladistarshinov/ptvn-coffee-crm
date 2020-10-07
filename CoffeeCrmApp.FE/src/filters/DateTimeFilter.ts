import moment from "moment";

const DateTimeFilter = (date: Date) => {
  return moment(date).format("DD.MM.YYYY HH:MM:SS");
};

export default DateTimeFilter;
