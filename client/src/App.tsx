import React, { useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Provider } from "react-redux";
import { store, AppDispatch } from "./store/store";
import { Login } from "./pages/Login";
import { Register } from "./pages/Register";
import { Home } from "./pages/Home";
import { Header } from "./components/Header";
import { ThemeProvider, createTheme } from "@mui/material";
import ProductDetail from "./pages/ProductDetail";
import ShoppingCart from "./pages/ShoppingCart";
import { useDispatch } from "react-redux";
import { fetchCart } from "./store/slices/cartSlice";

const theme = createTheme({
  palette: {
    primary: {
      main: "#1976d2",
    },
    secondary: {
      main: "#dc004e",
    },
  },
});

function App() {
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    const token = store.getState().auth.token;
    if (token) {
      dispatch(fetchCart());
    }
  }, [dispatch]);

  return (
    <ThemeProvider theme={theme}>
      <Router>
        <div className="App">
          <Header />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/product/:id" element={<ProductDetail />} />
            <Route path="/cart" element={<ShoppingCart />} />
          </Routes>
        </div>
      </Router>
    </ThemeProvider>
  );
}

export default App;
