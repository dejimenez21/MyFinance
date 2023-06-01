import { createContext, useContext } from "react";
import { AccountStore } from "./accountStore";
import { ExpenseStore } from "./expenses/expenseStore";
import { ExpenseGroupStore } from "./expenses/expenseGroupStore";
import { PaymentAccountStore } from "./expenses/paymentAccountStore";

interface Store {
  accountStore: AccountStore;
  expenseStore: ExpenseStore;
  expenseGroupStore: ExpenseGroupStore;
  paymentAccountStore: PaymentAccountStore;
}

export const store: Store = {
  accountStore: new AccountStore(),
  expenseStore: new ExpenseStore(),
  expenseGroupStore: new ExpenseGroupStore(),
  paymentAccountStore: new PaymentAccountStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
