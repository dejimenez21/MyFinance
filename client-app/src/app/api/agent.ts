import axios, { AxiosError, AxiosResponse } from "axios";
import { Expense } from "../models/expenses/expense";
import Liquidity from "../models/liquidity";
import { ExpenseGroup } from "../models/expenses/expenseGroup";
import ExpenseCategory from "../models/expenses/expenseCategory";
import PaymentAccount from "../models/expenses/paymentAccount";

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (err: AxiosError) => {
    const { data } = err.response as AxiosResponse;
    console.log(data.response);
    return Promise.reject(err);
  }
);

axios.interceptors.request.use((request) => {
  console.log(request.data);
  return request;
});

const getResponseData = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(uri: string) => axios.get<T>(uri).then(getResponseData),
  post: <T, U>(uri: string, data: U) =>
    axios.post<T>(uri, data).then(getResponseData),
};

const Expenses = {
  list: () => requests.get<Expense[]>("/expenses"),
  post: (expense: Expense) =>
    requests.post<Expense, Expense>("/expenses", expense),
  listCategories: () => requests.get<ExpenseCategory[]>("/expenses/categories"),
};

const ExpenseGroups = {
  list: () => requests.get<ExpenseGroup[]>("/expenseGroups"),
};

const LiquidAccounts = {
  list: (onlyPaymentElegible: boolean) =>
    requests.get<Liquidity[]>(
      `/accounts/liquidity?onlyPaymentElegible=${onlyPaymentElegible}`
    ),
};

const PaymentAccounts = {
  list: () => requests.get<PaymentAccount[]>("/accounts/payment-accounts"),
};

const agent = {
  Expenses,
  ExpenseGroups,
  LiquidAccounts,
  PaymentAccounts,
};

export default agent;
