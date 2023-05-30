import { useState } from "react";
import { NavLink } from "react-router-dom";
import { Container, Menu } from "semantic-ui-react";
import "./NavBar.css"

const NavBar = () => {
  const [activeItem, setActiveItem] = useState("");

  const handleItemClick = (_: any, { name }: any) => setActiveItem(name);

  return (
    <>
      <Menu pointing secondary style={{marginTop: 0}} >
        <Container className="bar">
          <Menu.Item
            name="home"
            as={NavLink}
            to='/'
            active={activeItem === "home"}
            onClick={handleItemClick}
          >
            Home
          </Menu.Item>
          <Menu.Item
            name="expenses"
            as={NavLink}
            to='/expenses'
            active={activeItem === "expenses"}
            onClick={handleItemClick}
          >
            Expenses
          </Menu.Item>
        </Container>
      </Menu>
    </>
  );
};

export default NavBar;
