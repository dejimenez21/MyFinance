import { Card, Grid, Header, Image } from "semantic-ui-react";
import Liquidity from "../../app/models/liquidity";
import "./LiquidityDashboard.css";
import utils from "../../app/utils/assetsUtils";

interface Props {
  account: Liquidity;
}

const LiquidityItem = ({account}: Props) => {
  return (
      <Card.Group>
        <Card className="liquidity-item">
          <Card.Content>
            <Image
              src={utils.getLiquidAccountIcon(account.bankCode)}
              size="mini"
              floated="right"
            />
            <Card.Header>{account.alias}</Card.Header>
            <Card.Description>{account.number}</Card.Description>
            <Card.Meta>Last Transaction Date: 2023-03-05</Card.Meta>
          </Card.Content>
          <Card.Content textAlign="right">
            <Grid>
              <Grid.Row>
                <Grid.Column width="6" textAlign="left">
                  <Header>Balance</Header>
                </Grid.Column>
                <Grid.Column width="10" textAlign="right">
                  <Header color="green">RD${account.balance}</Header>
                </Grid.Column>
              </Grid.Row>
            </Grid>
          </Card.Content>
        </Card>
      </Card.Group>
  );
};

export default LiquidityItem;
