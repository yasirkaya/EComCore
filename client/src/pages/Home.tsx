import React, { useEffect, useState } from "react";
import {
  Container,
  Box,
  Card,
  CardContent,
  CardMedia,
  Typography,
  TextField,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Button,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { useNavigate } from "react-router-dom";
import { productService } from "../services/product.service";
import { Product, Category, ProductFilter } from "../types/product";

export const Home: React.FC = () => {
  const navigate = useNavigate();
  const [products, setProducts] = useState<Product[]>([]);
  const [categories, setCategories] = useState<Category[]>([]);
  const [loading, setLoading] = useState(true);
  const [filter, setFilter] = useState<ProductFilter>({
    pageNumber: 1,
    pageSize: 12,
    categoryId: "",
    includeDeleted: false,
  });
  const [priceRange, setPriceRange] = useState<[number, number]>([0, 1000]);

  useEffect(() => {
    loadCategories();
  }, []);

  useEffect(() => {
    loadProducts();
  }, [filter]);

  const loadProducts = async () => {
    try {
      console.log("Fetching products with filter:", filter);
      const response = await productService.getProducts(filter);
      console.log("API Response:", response);
      console.log("Response type:", typeof response);
      console.log("Is array?", Array.isArray(response));
      console.log("Response.items:", response.items);

      // API yanıtı direkt array ise
      const products = Array.isArray(response)
        ? response
        : response.items || [];
      console.log("Final products:", products);
      setProducts(products);
    } catch (error) {
      console.error("Error loading products:", error);
    } finally {
      setLoading(false);
    }
  };

  const loadCategories = async () => {
    try {
      const data = await productService.getCategories();
      setCategories(data);
    } catch (error) {
      console.error("Error loading categories:", error);
    }
  };

  const handlePriceRangeChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
    newValue: number | number[]
  ) => {
    setPriceRange(newValue as [number, number]);
    setFilter({
      ...filter,
      minPrice: (newValue as [number, number])[0],
      maxPrice: (newValue as [number, number])[1],
    });
  };

  return (
    <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
      <Box sx={{ display: "flex", gap: 3 }}>
        {/* Filters */}
        <Box sx={{ flex: "0 0 25%", maxWidth: "25%" }}>
          <Card>
            <CardContent>
              <Typography variant="h6" gutterBottom>
                Filtreler
              </Typography>

              {/* Category Filter */}
              <FormControl fullWidth sx={{ mb: 2 }}>
                <InputLabel>Kategori</InputLabel>
                <Select
                  value={filter.categoryId || ""}
                  onChange={(e) =>
                    setFilter({
                      ...filter,
                      categoryId: e.target.value as string,
                    })
                  }
                >
                  <MenuItem value="">Tümü</MenuItem>
                  {categories.map((category) => (
                    <MenuItem key={category.id} value={category.id}>
                      {category.name}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>

              {/* Price Range Filter */}
              <FormControl fullWidth sx={{ mb: 2 }}>
                <TextField
                  label="Min Fiyat"
                  type="number"
                  value={priceRange[0]}
                  onChange={(e) =>
                    handlePriceRangeChange(e, [
                      Number(e.target.value),
                      priceRange[1],
                    ])
                  }
                />
              </FormControl>

              <FormControl fullWidth sx={{ mb: 2 }}>
                <TextField
                  label="Max Fiyat"
                  type="number"
                  value={priceRange[1]}
                  onChange={(e) =>
                    handlePriceRangeChange(e, [
                      priceRange[0],
                      Number(e.target.value),
                    ])
                  }
                />
              </FormControl>

              {/* Search Filter */}
              <FormControl fullWidth sx={{ mb: 2 }}>
                <TextField
                  label="Ara"
                  value={filter.search || ""}
                  onChange={(e) =>
                    setFilter({ ...filter, search: e.target.value })
                  }
                />
              </FormControl>
            </CardContent>
          </Card>
        </Box>

        {/* Product List */}
        <Box sx={{ flex: "1 1 auto" }}>
          <Box
            sx={{
              display: "grid",
              gridTemplateColumns: "repeat(auto-fill, minmax(250px, 1fr))",
              gap: 3,
            }}
          >
            {products.map((product) => (
              <Card
                key={product.id}
                sx={{
                  height: "100%",
                  display: "flex",
                  flexDirection: "column",
                  cursor: "pointer",
                  "&:hover": {
                    transform: "scale(1.02)",
                    transition: "transform 0.2s ease-in-out",
                  },
                }}
                onClick={() => navigate(`/product/${product.id}`)}
              >
                <CardMedia
                  component="img"
                  height="200"
                  image={process.env.PUBLIC_URL + "urun.jpeg"}
                  alt={product.name}
                />
                <CardContent sx={{ flexGrow: 1 }}>
                  <Typography gutterBottom variant="h6" component="h2">
                    {product.name}
                  </Typography>
                  <Typography>${product.price}</Typography>
                </CardContent>
              </Card>
            ))}
          </Box>
        </Box>
      </Box>
    </Container>
  );
};
