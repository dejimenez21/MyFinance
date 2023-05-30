import { NavLink } from "react-router-dom";
import { Container, Header, Menu } from "semantic-ui-react";

//styles
import "./HeaderSection.css";
import NavBar from "./NavBar";

const HeaderSection = () => {
  return (
    <Container fluid as="header">
      <Container fluid className="title-bar-container ">
        <Container className="title-bar">
          <Header
            as={NavLink}
            to="/"
            textAlign="center"
            style={{ color: "white", padding: "2rem" }}
          >
            <Header.Content as='h1'>MyFinance</Header.Content>
          </Header>
        </Container>
      </Container>
      <NavBar />
    </Container>
  );
};

export default HeaderSection;
