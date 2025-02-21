import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import { MainLayout } from "./components/layout/MainLayout";
import { Login } from "./pages/Login";
import { Dashboard } from "./pages/Dashboard";
import { Users } from "./pages/Users";
import { Products } from "./pages/Products";
import { Categories } from "./pages/Categories";
import { useAuth } from "./hooks/useAuth";
import { Reviews } from "./pages/Reviews";

// Styles
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import Roles from "./pages/Roles";

const PrivateRoute: React.FC<{ element: React.ReactElement }> = ({
  element,
}) => {
  const { isAuthenticated, loading } = useAuth();

  if (loading) {
    return <div>Loading...</div>;
  }

  return isAuthenticated ? element : <Navigate to="/login" />;
};

const App: React.FC = () => {
  return (
    <Router>
      <MainLayout>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route
            path="/dashboard"
            element={<PrivateRoute element={<Dashboard />} />}
          />
          <Route path="/users" element={<PrivateRoute element={<Users />} />} />
          <Route
            path="/products"
            element={<PrivateRoute element={<Products />} />}
          />
          <Route
            path="/categories"
            element={<PrivateRoute element={<Categories />} />}
          />
          <Route
            path="/reviews"
            element={<PrivateRoute element={<Reviews />} />}
          />
          <Route path="/roles" element={<PrivateRoute element={<Roles />} />} />
          <Route path="/" element={<Navigate to="/dashboard" />} />
        </Routes>
      </MainLayout>
    </Router>
  );
};

export default App;
