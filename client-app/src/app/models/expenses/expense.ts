import Money from "../money";

export interface Expense {
  id: string;
  amount: Money;
  description: string;
  date: string;
  accountId: string;
  groupId: string | undefined;
  category: string;
}
