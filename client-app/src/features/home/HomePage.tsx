import { Grid } from "semantic-ui-react";
import LiquidityDashboard from "../liquidity/LiquidityDashboard";
import BalanceSummary from "./BalanceSummary";

const HomePage = () => {
  return (
    <>
      <Grid style={{marginTop: '10px'}}>
        <Grid.Column width={10}>
          <LiquidityDashboard />
        </Grid.Column>
        <Grid.Column width={6}>
          <BalanceSummary />
        </Grid.Column>
      </Grid>
    </>
  );
};

export default HomePage;
