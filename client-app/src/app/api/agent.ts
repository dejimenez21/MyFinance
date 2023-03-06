import axios, { AxiosResponse } from "axios";
import { Expense } from "../models/expense";

axios.defaults.baseURL = "https://localhost:44348/api";

const getResponseData = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(uri: string) => axios.get<T>(uri).then(getResponseData),
};

const Expenses = {
  list: () => requests.get<Expense[]>("/expenses"),
};

const agent = {
  Expenses,
};

export default agent;
