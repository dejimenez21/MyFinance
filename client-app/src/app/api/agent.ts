import axios, { AxiosResponse } from "axios";
import { Expense } from "../models/expense";
import Liquidity from "../models/liquidity";
import { settings } from "../../appConfig";

axios.defaults.baseURL = "https://localhost:44348/api";
// axios.defaults.baseURL = "http://localhost:5244/api";

const getResponseData = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(uri: string) => axios.get<T>(uri).then(getResponseData),
  post: <T, U>(uri: string, data: U) => axios.post<T>(uri, data).then(getResponseData)
};

const Expenses = {
  list: () => requests.get<Expense[]>("/expenses"),
  post: (expense: Expense) => requests.post<Expense, Expense>("/expenses", expense),
};

const LiquidAccounts = {
  list: () => requests.get<Liquidity[]>("/accounts/liquidity"),
}

const agent = {
  Expenses,
  LiquidAccounts,
};

export default agent;
