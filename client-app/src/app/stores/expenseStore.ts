import { makeAutoObservable, runInAction } from "mobx";
import { Expense } from "../models/expenses/expense";
import agent from "../api/agent";
import ExpenseCategory from "../models/expenses/expenseCategory";

export class ExpenseStore {
  expensesRegistry = new Map<string, Expense>();
  categoriesRegistry = new Map<string, ExpenseCategory>();

  constructor() {
    makeAutoObservable(this);
  }

  get expenses() {
    return Array.from(this.expensesRegistry.values());
  }

  get categories() {
    return Array.from(this.categoriesRegistry.values()); 
  }

  loadExpenses = () => {
    agent.Expenses.list().then((expenses) => {
      runInAction(() => {
        expenses.forEach((e) => {
          this.expensesRegistry.set(e.id, e);
        });
      });
    });
  };

  loadCategories = () => {
    agent.Expenses.listCategories().then((categories) => {
      runInAction(() => {
        categories.forEach((c) => {
          this.categoriesRegistry.set(c.name, c);
        });
      });
    });
  };

  addExpense(expense: Expense) {
    agent.Expenses.post(expense).then((createdExpense) => {
      runInAction(() => {
        this.expensesRegistry.set(createdExpense.id, createdExpense);
      });
    });
  }

  removeExpense(expenseId: string) {
    this.expensesRegistry.delete(expenseId);
  }
}
