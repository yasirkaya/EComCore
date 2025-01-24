import React from "react";
import { useFormik } from "formik";
import * as yup from "yup";
import { Box, Button, Container, TextField, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { authService } from "../services/auth.service";
import { setUser } from "../store/slices/authSlice";

const validationSchema = yup.object({
  firstName: yup.string().required("Ad gerekli"),
  lastName: yup.string().required("Soyad gerekli"),
  email: yup
    .string()
    .email("Geçerli bir e-posta adresi girin")
    .required("E-posta gerekli"),
  password: yup
    .string()
    .min(6, "Şifre en az 6 karakter olmalıdır")
    .required("Şifre gerekli"),
  confirmPassword: yup
    .string()
    .oneOf([yup.ref("password")], "Şifreler eşleşmiyor")
    .required("Şifre tekrarı gerekli"),
});

export const Register = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const formik = useFormik({
    initialValues: {
      firstName: "",
      lastName: "",
      email: "",
      password: "",
      confirmPassword: "",
    },
    validationSchema,
    onSubmit: async (values) => {
      try {
        const response = await authService.register(values, dispatch);
        dispatch(setUser(response.user));
        navigate("/");
      } catch (error) {
        console.error("Register error:", error);
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
          Kayıt Ol
        </Typography>
        <Box component="form" onSubmit={formik.handleSubmit} sx={{ mt: 3 }}>
          <TextField
            margin="normal"
            fullWidth
            id="firstName"
            label="Ad"
            name="firstName"
            autoComplete="given-name"
            autoFocus
            value={formik.values.firstName}
            onChange={formik.handleChange}
            error={formik.touched.firstName && Boolean(formik.errors.firstName)}
            helperText={formik.touched.firstName && formik.errors.firstName}
          />
          <TextField
            margin="normal"
            fullWidth
            id="lastName"
            label="Soyad"
            name="lastName"
            autoComplete="family-name"
            value={formik.values.lastName}
            onChange={formik.handleChange}
            error={formik.touched.lastName && Boolean(formik.errors.lastName)}
            helperText={formik.touched.lastName && formik.errors.lastName}
          />
          <TextField
            margin="normal"
            fullWidth
            id="email"
            label="E-posta Adresi"
            name="email"
            autoComplete="email"
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
            value={formik.values.password}
            onChange={formik.handleChange}
            error={formik.touched.password && Boolean(formik.errors.password)}
            helperText={formik.touched.password && formik.errors.password}
          />
          <TextField
            margin="normal"
            fullWidth
            name="confirmPassword"
            label="Şifre Tekrarı"
            type="password"
            id="confirmPassword"
            value={formik.values.confirmPassword}
            onChange={formik.handleChange}
            error={
              formik.touched.confirmPassword &&
              Boolean(formik.errors.confirmPassword)
            }
            helperText={
              formik.touched.confirmPassword && formik.errors.confirmPassword
            }
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Kayıt Ol
          </Button>
          <Button fullWidth variant="text" onClick={() => navigate("/login")}>
            Zaten hesabınız var mı? Giriş yapın
          </Button>
        </Box>
      </Box>
    </Container>
  );
};
