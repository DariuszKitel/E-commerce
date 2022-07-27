import IProduct from "./Product";

export default interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[];
  }