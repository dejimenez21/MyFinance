import {
  Button,
  Container,
  Grid,
  GridColumn,
  GridRow,
} from "semantic-ui-react";
import ExpensesList from "./ExpensesList";
import ExpenseForm from "./ExpenseForm";
import { useEffect, useState } from "react";
import { Expense } from "../../app/models/expense";
import agent from "../../app/api/agent";
import { error } from "console";
import { AxiosError } from "axios";

const ExpensesDashboard = () => {
  const [modalOpen, setModalOpen] = useState(false);

  const handleOpen = () => {
    setModalOpen(true);
  };

  const handleClose = () => {
    setModalOpen(false);
  };

  const handleSubmit = (expense: Expense) => {
    agent.Expenses.post(expense).then((response) => {
      setExpenses([response, ...expenses]);
      setModalOpen(false);
    }).catch((error: AxiosError) => {
      console.log(error);
    })
    
  }

  const [expenses, setExpenses] = useState<Expense[]>([]);

  useEffect(() => {
    agent.Expenses.list().then((response) => {
      setExpenses(response);
    });
  }, []);

  return (
    <>
      <Grid columns={1} centered verticalAlign="middle">
          <GridColumn>
            <Container style={{ marginBottom: "5em" }}>
              <Button
                floated="right"
                color="teal"
                content="Add expense"
                onClick={handleOpen}
              />
            </Container>
            <ExpensesList expenses={expenses} />
          </GridColumn>
          <ExpenseForm modalOpen={modalOpen} handleClose={handleClose} handleSubmit={handleSubmit} />
      </Grid>
    </>
  );
};

export default ExpensesDashboard;
