import React from "react";
import {
  AppBar,
  Toolbar,
  Typography,
  Button,
  IconButton,
  Badge,
  Box,
  useTheme,
} from "@mui/material";
import {
  ShoppingCart as ShoppingCartIcon,
  Favorite as FavoriteIcon,
  Person as PersonIcon,
} from "@mui/icons-material";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../store/store";
import { store } from "../store/store";

export const Header: React.FC = () => {
  const theme = useTheme();
  const navigate = useNavigate();
  const token = store.getState().auth.token;
  const isAuthenticated = !!token;
  const cart = useSelector((state: RootState) => state.cart.cart);
  const totalQuantity =
    cart?.items?.reduce((total, item) => total + item.quantity, 0) ?? 0;

  return (
    <AppBar position="sticky" sx={{ mb: 2 }}>
      <Toolbar>
        <Typography
          variant="h6"
          component="div"
          sx={{ flexGrow: 1, cursor: "pointer" }}
          onClick={() => navigate("/")}
        >
          EComCore
        </Typography>

        <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
          {isAuthenticated ? (
            <>
              <IconButton
                color="inherit"
                onClick={() => navigate("/favorites")}
              >
                <Badge color="secondary">
                  <FavoriteIcon />
                </Badge>
              </IconButton>

              <IconButton color="inherit" onClick={() => navigate("/cart")}>
                <Badge badgeContent={totalQuantity} color="secondary">
                  <ShoppingCartIcon />
                </Badge>
              </IconButton>

              <IconButton color="inherit" onClick={() => navigate("/profile")}>
                <PersonIcon />
              </IconButton>
            </>
          ) : (
            <>
              <Button color="inherit" onClick={() => navigate("/login")}>
                Giriş Yap
              </Button>
              <Button color="inherit" onClick={() => navigate("/register")}>
                Kayıt Ol
              </Button>
            </>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
};
