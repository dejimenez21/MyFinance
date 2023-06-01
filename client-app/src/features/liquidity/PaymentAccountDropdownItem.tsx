import { Grid, Header, Image } from "semantic-ui-react";
import utils from "../../app/utils/assetsUtils";
import PaymentAccount from "../../app/models/expenses/paymentAccount";
import { paymentMethods } from "../../app/models/expenses/paymentMethod";

interface Props {
  account: PaymentAccount;
}

const PaymentAccountDropdownItem = ({ account }: Props) => {
  return (
    <Grid>
      <Grid.Row>
        <Grid.Column width={1} textAlign="left" verticalAlign="middle">
          <Image
            src={utils.getLiquidAccountIcon(account.bank)}
            size="mini"
            floated="left"
          />
        </Grid.Column>
        <Grid.Column width={14}>
          {account.bank ? `${account.number} - ` : ""}
          {account.name}
        </Grid.Column>
        {account.network ? (
        <Grid.Column width={1} textAlign="right" verticalAlign="middle">
          <Image
            src={utils.getPaymentNetworkImage(account.network!)}
            size="mini"
            floated="right"
          />
        </Grid.Column>
        ) : ""} 
      </Grid.Row>
    </Grid>
  );
};

export default PaymentAccountDropdownItem;
