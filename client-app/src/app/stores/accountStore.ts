import { makeAutoObservable, runInAction } from "mobx";
import Liquidity from "../models/liquidity";
import agent from "../api/agent";

export class AccountStore {
  liquidAccountsRegistry = new Map<string, Liquidity>();

  constructor() {
    makeAutoObservable(this);
  }

  get liquidAccounts() {
    return Array.from(this.liquidAccountsRegistry.values());
  }

  get groupedLiquidAccounts() {
    return Object.entries(
      this.liquidAccounts.reduce((accounts, account) => {
        const group = account.group;
        const groupExist = accounts[group];

        const toAdd = groupExist ? [...accounts[group], account] : [account];

        accounts[group] = toAdd;
        return accounts;
      }, {} as { [key: string]: Liquidity[] })
    );
  }

  loadLiquidAccounts = async (onlyPaymentElegible: boolean = false) => {
    agent.LiquidAccounts.list(onlyPaymentElegible)
      .then((accounts) => {
        runInAction(() => {
          accounts.forEach((account) => {
            this.liquidAccountsRegistry.set(account.id, account);
          });
        });
      })
      .catch((error) => console.log(error));
  };
}
