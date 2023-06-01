import { makeAutoObservable, runInAction } from "mobx";
import PaymentAccount from "../../models/expenses/paymentAccount";
import agent from "../../api/agent";

export class PaymentAccountStore {

  paymentAccountRegistry = new Map<string, PaymentAccount>();

  constructor() {
    makeAutoObservable(this);
  }

  get paymentAccounts() {
    return Array.from(this.paymentAccountRegistry.values());
  }

  loadPaymentAccounts = () => {
    agent.PaymentAccounts.list().then(accounts => {
        runInAction(() => {
            accounts.forEach(account => {
                this.paymentAccountRegistry.set(account.id, account);
            });
        });  
    })
  }
}
