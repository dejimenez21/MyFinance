import React, { useEffect, useState } from "react";
import { Divider, Item } from "semantic-ui-react";
import { Expense } from "../../app/models/expense";
import ExpenseItem from "./ExpenseItem";
import agent from "../../app/api/agent";

const expenses: Expense[] = [
  {
    id: "dasfdf",
    description: "Gasto 1",
    amount: 500,
    date: "2023-2-23",
  },
  {
    id: "dasfgf",
    description: "Gasto 2",
    amount: 1452,
    date: "2023-2-25",
  },
  {
    id: "asfdf",
    description: "Gasto 3",
    amount: 1200,
    date: "2023-2-28",
  }
];

const ExpensesList = () => {

    const [expenses, setExpenses] = useState<Expense[]>([]);

    useEffect(() => {
        agent.Expenses.list().then((response) => {
            setExpenses(response);
        })
    }, []);

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
