export interface IResponseService<T> {
    isSuccess: boolean;
    message: string;
    time: Date;
    data: T;
}