import { Button, Container, Grid, GridColumn, GridRow } from "semantic-ui-react";
import ExpensesList from "./ExpensesList";

const ExpensesDashboard = () => {
  return (
    <>
      <Grid>
        <GridRow>
          <GridColumn width="10">
            <Container><Button floated="right" color="teal" content="Add expense" /></Container>
            
            <ExpensesList />
          </GridColumn>
          <GridColumn width="6">

          </GridColumn>
        </GridRow>
      </Grid>
    </>
  );
};

export default ExpensesDashboard;
