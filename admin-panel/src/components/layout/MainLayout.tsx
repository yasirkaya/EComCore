import React from "react";
import { Container } from "react-bootstrap";
import { Navbar } from "./Navbar";
import { useAuth } from "../../hooks/useAuth";

interface MainLayoutProps {
  children: React.ReactNode;
}

export const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
  const { isAuthenticated } = useAuth();

  if (!isAuthenticated) {
    return <>{children}</>;
  }

  return (
    <div className="d-flex flex-column min-vh-100">
      <Navbar />
      <Container fluid className="flex-grow-1 py-4">
        {children}
      </Container>
    </div>
  );
};
