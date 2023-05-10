import { Button, Container, Grid, GridColumn } from "semantic-ui-react";
import ExpensesList from "./ExpensesList";
import ExpenseForm from "./ExpenseForm";
import { useEffect, useState } from "react";
import { Expense } from "../../app/models/expenses/expense";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";

const ExpensesDashboard = () => {
  const [modalOpen, setModalOpen] = useState(false);

  const { expenseStore } = useStore();
  const { loadExpenses, addExpense } = expenseStore;

  const handleOpen = () => {
    setModalOpen(true);
  };

  const handleClose = () => {
    setModalOpen(false);
  };

  const handleSubmit = (expense: Expense) => {
    addExpense(expense);
    setModalOpen(false);
  };

  useEffect(() => {
    loadExpenses();
  }, [loadExpenses]);

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
          <ExpensesList />
        </GridColumn>
        <ExpenseForm
          modalOpen={modalOpen}
          handleClose={handleClose}
          handleSubmit={handleSubmit}
        />
      </Grid>
    </>
  );
};

export default observer(ExpensesDashboard);
