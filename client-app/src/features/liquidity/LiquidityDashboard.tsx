import { Fragment, useEffect, useState } from "react";
import { Container, Grid, Header } from "semantic-ui-react";
import agent from "../../app/api/agent";
import Liquidity from "../../app/models/liquidity";
import LiquidityItem from "./LiquidityItem";
import "./LiquidityDashboard.css";

const LiquidityDashboard = () => {
  const [liquidAccounts, setLiquidAccounts] = useState<Liquidity[]>([]);

  useEffect(() => {
    agent.LiquidAccounts.list()
      .then((accounts) => {
        setLiquidAccounts(accounts);
      })
      .catch((error) => alert(error));
  }, []);

  const groupedLiquidAccounts = () => {
    return Object.entries(
      liquidAccounts.reduce((accounts, account) => {
        const group = account.group;
        const groupExist = accounts[group];

        const toAdd = groupExist ? [...accounts[group], account] : [account];

        accounts[group] = toAdd;
        return accounts;
      }, {} as { [key: string]: Liquidity[] })
    );
  };

  return (
    <>
      {groupedLiquidAccounts().map(([group, accounts]) => (
        <Fragment key={group}>
          <Header as="h2" style={{marginBottom: "1em"}}>{group}</Header>
          <Container style={{ marginBottom: "5em"}}>
            <Grid>
              {accounts.map((account) => (
                <Grid.Column key={account.id} width={5}>
                  <LiquidityItem account={account} />
                </Grid.Column>
              ))}
            </Grid>
          </Container>
        </Fragment>
      ))}
    </>
  );
};

export default LiquidityDashboard;
