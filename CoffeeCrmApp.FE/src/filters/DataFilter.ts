import moment from "moment";

const DataFilter = (date: Date) => {
    return moment(date).format('DD MM YYYY');
};

export default DataFilter;