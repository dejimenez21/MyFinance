import { Divider, Grid, Header, Icon, Item, Label } from "semantic-ui-react";
import { Expense } from "../../app/models/expenses/expense";

interface Props {
  expense: Expense;
}

const ExpenseItem = ({ expense }: Props) => {
  return (
    <>
      <Item>
        <Item.Content>
          <Grid>
            <Grid.Row>
              <Grid.Column width={2} textAlign="left">
                <Icon circular size="large" name="dollar" />
              </Grid.Column>
              <Grid.Column width={8}>
                <Item.Header>
                  <Header size="medium">{expense.description}</Header>
                </Item.Header>
                <Item.Meta>Credit Card</Item.Meta>
              </Grid.Column>
              <Grid.Column width={6} textAlign="right">
                <Item.Description>
                  <Label size="large" color="red">
                    ${expense.amount.value}
                  </Label>
                </Item.Description>
                <Item.Extra>{expense.date}</Item.Extra>
              </Grid.Column>
            </Grid.Row>
          </Grid>
        </Item.Content>
      </Item>
      <Divider />
    </>
  );
};

export default ExpenseItem;
