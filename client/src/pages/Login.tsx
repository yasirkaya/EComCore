import React from "react";
import { useFormik } from "formik";
import * as yup from "yup";
import { Box, Button, Container, TextField, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { authService } from "../services/auth.service";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../store/store";

const validationSchema = yup.object({
  email: yup
    .string()
    .email("Geçerli bir e-posta adresi girin")
    .required("E-posta gerekli"),
  password: yup.string().required("Şifre gerekli"),
});

export const Login = () => {
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();

  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema,
    onSubmit: async (values) => {
      try {
        await authService.login(values, dispatch);
        navigate("/");
      } catch (error) {
        console.error("Login error:", error);
      }
    },
  });

  return (
    <Container component="main" maxWidth="xs">
      <Box
        sx={{
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Typography component="h1" variant="h5">
          Giriş Yap
        </Typography>
        <Box component="form" onSubmit={formik.handleSubmit} sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            fullWidth
            id="email"
            label="E-posta Adresi"
            name="email"
            autoComplete="email"
            autoFocus
            value={formik.values.email}
            onChange={formik.handleChange}
            error={formik.touched.email && Boolean(formik.errors.email)}
            helperText={formik.touched.email && formik.errors.email}
          />
          <TextField
            margin="normal"
            fullWidth
            name="password"
            label="Şifre"
            type="password"
            id="password"
            autoComplete="current-password"
            value={formik.values.password}
            onChange={formik.handleChange}
            error={formik.touched.password && Boolean(formik.errors.password)}
            helperText={formik.touched.password && formik.errors.password}
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Giriş Yap
          </Button>
          <Button
            fullWidth
            variant="text"
            onClick={() => navigate("/register")}
          >
            Hesabınız yok mu? Kayıt olun
          </Button>
          <Button
            fullWidth
            variant="text"
            onClick={() => navigate("/forgot-password")}
          >
            Şifremi unuttum
          </Button>
        </Box>
      </Box>
    </Container>
  );
};
