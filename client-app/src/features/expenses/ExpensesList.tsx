import { Item } from "semantic-ui-react";
import ExpenseItem from "./ExpenseItem";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";

const ExpensesList = () => {
  const { expenseStore } = useStore();
  const { expenses } = expenseStore;

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

export default observer(ExpensesList);
