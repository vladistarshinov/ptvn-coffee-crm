import moment from "moment";

const DateFilter = (date: Date) => {
  return moment(date).format("DD MM YYYY");
};

export default DateFilter;
