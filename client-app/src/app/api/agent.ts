import axios, { AxiosResponse } from "axios";
import { Expense } from "../models/expense";
import Liquidity from "../models/liquidity";

axios.defaults.baseURL = "https://localhost:44348/api";
// axios.defaults.baseURL = "http://localhost:5244/api";

const getResponseData = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(uri: string) => axios.get<T>(uri).then(getResponseData),
};

const Expenses = {
  list: () => requests.get<Expense[]>("/expenses"),
};

const LiquidAccounts = {
  list: () => requests.get<Liquidity[]>("/accounts/liquidity"),
}

const agent = {
  Expenses,
  LiquidAccounts,
};

export default agent;
