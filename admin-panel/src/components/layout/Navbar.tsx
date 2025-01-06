import React from "react";
import { Navbar as BNavbar, Nav, Container } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";

export const Navbar: React.FC = () => {
  const { user, logout } = useAuth();

  return (
    <BNavbar bg="dark" variant="dark" expand="lg">
      <Container fluid>
        <BNavbar.Brand as={Link} to="/dashboard">
          Admin Panel
        </BNavbar.Brand>
        <BNavbar.Toggle aria-controls="basic-navbar-nav" />
        <BNavbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link as={Link} to="/dashboard">
              Dashboard
            </Nav.Link>
            <Nav.Link as={Link} to="/users">
              Kullanıcılar
            </Nav.Link>
            <Nav.Link as={Link} to="/products">
              Ürünler
            </Nav.Link>
            <Nav.Link as={Link} to="/categories">
              Kategoriler
            </Nav.Link>
          </Nav>
          <Nav>
            <Nav.Item className="text-light d-flex align-items-center me-3">
              {user?.email}
            </Nav.Item>
            <Nav.Link onClick={logout}>Çıkış Yap</Nav.Link>
          </Nav>
        </BNavbar.Collapse>
      </Container>
    </BNavbar>
  );
};
