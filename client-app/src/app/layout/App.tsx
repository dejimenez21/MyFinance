import { Container } from "semantic-ui-react";
import "./App.css";
import NavBar from "./NavBar";
import { Outlet } from "react-router-dom";
import HeaderSection from "./HeaderSection";
import { Fragment } from "react";

function App() {
  return (
    <>
      <HeaderSection />
      <Container as="main" className="main">
        <Outlet />
      </Container>
    </>
  );
}

export default App;
