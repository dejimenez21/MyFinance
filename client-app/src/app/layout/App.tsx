import React from "react";
import { Container, Divider } from "semantic-ui-react";
import "./App.css";
import ExpensesList from "../../features/expenses/ExpensesList";
import NavBar from "./NavBar";
import ExpensesDashboard from "../../features/expenses/ExpensesDashboard";

function App() {
  return (
    <>
      <NavBar />
      <Container style={{marginTop: "5em"}}>
        <ExpensesDashboard />
      </Container>
    </>
  );
}

export default App;
