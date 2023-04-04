import { Item } from "semantic-ui-react";
import { Expense } from "../../app/models/expense";
import ExpenseItem from "./ExpenseItem";

interface Props {
  expenses: Expense[],
}

const ExpensesList = ({expenses}: Props) => {
  return (
    <>
      <Item.Group>
        {expenses.map((e) => (
          <ExpenseItem key={e.id} expense={e} />
        ))}
      </Item.Group>
    </>
  );
};

export default ExpensesList;
