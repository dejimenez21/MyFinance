import { Grid, Header, Image } from "semantic-ui-react";
import Liquidity from "../../app/models/liquidity";
import utils from "../../app/utils/assetsUtils";

interface Props {
  account: Liquidity;
}

const PaymentAccountDropdownItem = ({ account }: Props) => {
  return (
    <Grid>
      <Grid.Row>
        <Grid.Column width={1} textAlign="left" verticalAlign="middle">
          <Image
            src={utils.getLiquidAccountIcon(account.bankCode)}
            size="mini"
            floated="left"
          />
        </Grid.Column>
        <Grid.Column width={11}>{account.alias}</Grid.Column>
        <Grid.Column width={4} textAlign="right">
          <Header color={account.balance > 0 ? 'green' : "red"}>{account.balance}</Header>
        </Grid.Column>
      </Grid.Row>
    </Grid>
  );
};

export default PaymentAccountDropdownItem;
