import { createContext, useContext } from "react";
import { AccountStore } from "./accountStore";
import { ExpenseStore } from "./expenseStore";
import { ExpenseGroupStore } from "./expenseGroupStore";

interface Store {
  accountStore: AccountStore;
  expenseStore: ExpenseStore;
  expenseGroupStore: ExpenseGroupStore
}

export const store: Store = {
  accountStore: new AccountStore(),
  expenseStore: new ExpenseStore(),
  expenseGroupStore: new ExpenseGroupStore()
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
