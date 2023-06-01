import { makeAutoObservable, runInAction } from "mobx";
import { ExpenseGroup } from "../../models/expenses/expenseGroup";
import agent from "../../api/agent";

export class ExpenseGroupStore {
  expenseGroupsRegistry = new Map<string, ExpenseGroup>();

  constructor() {
    makeAutoObservable(this);
  }

  get expenseGroups() {
    return Array.from(this.expenseGroupsRegistry.values());
  }

  loadExpenseGroups = () => {
    agent.ExpenseGroups.list()
      .then((groups) => {
        runInAction(() => {
          groups.forEach((group) => {
            this.expenseGroupsRegistry.set(group.id, group);
          });
        });
      })
      .catch((error) => {
        console.log(error);
      });
  };
}
