import { Card, Grid, Header, Image } from "semantic-ui-react";

const LiquidityItem = () => {
  return (
    <>
      <Card.Group>
        <Card>
          <Card.Content>
            <Image
              src="./assets/bankImages/bpd.jpg"
              size="mini"
              floated="right"
            />
            <Card.Header>Cuenta de Ahorros Popular</Card.Header>
            <Card.Description>804015204</Card.Description>
            <Card.Meta>Last Transaction Date: 2023-03-05</Card.Meta>
          </Card.Content>
          <Card.Content textAlign="right">
            <Grid>
              <Grid.Row>
                <Grid.Column width="6" textAlign="left">
                  <Header>Balance</Header>
                </Grid.Column>
                <Grid.Column width="10" textAlign="right">
                  <Header color="green">RD$12,500.00</Header>
                </Grid.Column>
              </Grid.Row>
            </Grid>
          </Card.Content>
        </Card>
      </Card.Group>
    </>
  );
};

export default LiquidityItem;
