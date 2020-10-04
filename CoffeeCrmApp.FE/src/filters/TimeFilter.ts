import moment from "moment";

const TimeFilter = (date: Date) => {
    return moment(date).format('HH:MM:SS');
};

export default TimeFilter;