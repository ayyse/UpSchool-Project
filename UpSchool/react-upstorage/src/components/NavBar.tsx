import { Container, Menu,Image } from "semantic-ui-react";
import { NavLink } from "react-router-dom";

function NavBar() {
    return (
        <>
          <Menu fixed='top' inverted>
            <Container>
              <Menu.Item header>
                <Image size='mini' src='/vite.svg' style={{ marginRight: '1.5em' }} />
                UpStorage
              </Menu.Item>
              <Menu.Item as={NavLink} to={"/"}>Home</Menu.Item>
              <Menu.Item as={NavLink} to={"/accounts"}>Accounts</Menu.Item>
              <Menu.Item as={NavLink} to={"/sadasdjfh"}>Not Found</Menu.Item>
            </Container>
          </Menu>
        </>
    );
}

export default NavBar;