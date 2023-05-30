import { Card, Container, Header, Segment } from "semantic-ui-react";
import "./BalanceSummary.css";

const BalanceSummary = () => {
  return (
    <>
      <Card style={{ padding: "36px", margin: 0, width: "100%" }}>
        <Card.Header className="balance-header">
          <Header style={{ margin: 0 }} as="h3">
            My Balance
          </Header>
          <select>
            <option value="DOP">DOP</option>
            <option value="USD">USD</option>
          </select>
        </Card.Header>
        <Card.Content>
          <Container className="amount-section">
            <p>
              What I <strong>have</strong>
            </p>
            <p>$502,345.00</p>
          </Container>
          <Container className="amount-section">
            <p>
              What I <strong>owe</strong>
            </p>
            <p>$502,345.00</p>
          </Container>
          <Container className="amount-section">
            <p>
              Available <strong>credit</strong>
            </p>
            <p>$502,345.00</p>
          </Container>
        </Card.Content>
      </Card>
    </>
  );
};

export default BalanceSummary;
