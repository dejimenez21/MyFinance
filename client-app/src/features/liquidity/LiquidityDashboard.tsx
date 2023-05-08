import { Fragment, useEffect } from "react";
import { Container, Grid, Header } from "semantic-ui-react";
import LiquidityItem from "./LiquidityItem";
import "./LiquidityDashboard.css";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";

const LiquidityDashboard = () => {
  const { accountStore } = useStore();
  const { groupedLiquidAccounts, loadLiquidAccounts } = accountStore;

  useEffect(() => {
    loadLiquidAccounts();
  }, [loadLiquidAccounts]);

  return (
    <>
      {accountStore.liquidAccountsRegistry.size > 0 ? (
        groupedLiquidAccounts.map(([group, accounts]) => (
          <Fragment key={group}>
            <Header as="h2" style={{ marginBottom: "1em" }}>
              {group}
            </Header>
            <Container style={{ marginBottom: "5em" }}>
              <Grid columns={3}>
                {accounts.map((account) => (
                  <Grid.Column key={account.id}>
                    <LiquidityItem account={account} />
                  </Grid.Column>
                ))}
              </Grid>
            </Container>
          </Fragment>
        ))
      ) : (
        <Container
          style={{
            height: "100vh",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Header as="h1" style={{ marginBottom: "1em" }}>
            There isn't any liquid account to display
          </Header>
        </Container>
      )}
    </>
  );
};

export default observer(LiquidityDashboard);
