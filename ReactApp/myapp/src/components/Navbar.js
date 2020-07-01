import React from 'react';
import {Navbar,Nav,Form,FormControl,Button} from 'react-bootstrap';

class navbar extends React.Component {
    render() {
      return(
        <Navbar bg="primary" variant="dark">
          <Navbar.Brand href="#home">Studiji</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
              <Nav className="mr-auto">
                <Nav.Link href="#home">Home</Nav.Link>
                <Nav.Link href="#vrste_studija">Vrste studija</Nav.Link>
                <Nav.Link href="#about">About</Nav.Link>
              </Nav>
              <Form inline>
              <FormControl type="text" placeholder="Search" className="mr-sm-2" />
              <Button variant="dark">Search</Button>
              </Form>
          </Navbar.Collapse>
        </Navbar>
      );
    }
}
export default navbar;