import React, { useEffect, useState } from "react";
import { Category, Product } from "../types/models";
import { categoryService, productService } from "../services/api";
import { DataTable, FormModal, PageHeader, Column } from "../components/ui";

const defaultFormData = {
  id: "",
  name: "",
  description: "",
  sku: "",
  price: 0,
  stockQuantity: 0,
  categoryIds: [] as string[],
};

export const Products: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [categories, setCategories] = useState<Category[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);
  const [formData, setFormData] = useState(defaultFormData);

  useEffect(() => {
    loadProducts();
    loadCategories();
  }, []);

  const loadProducts = async () => {
    try {
      const data = await productService.getAll();
      setProducts(data);
    } catch (error) {
      console.error("Ürünler yüklenirken hata oluştu:", error);
    }
  };

  const loadCategories = async () => {
    try {
      const data = await categoryService.getAll();
      setCategories(data);
    } catch (error) {
      console.error("Kategoriler yüklenirken hata oluştu:", error);
    }
  };

  const handleShowModal = (product?: Product) => {
    if (product) {
      setSelectedProduct(product);
      setFormData({
        id: product.id,
        name: product.name,
        description: product.description,
        sku: product.sku,
        price: product.price,
        stockQuantity: product.stockQuantity,
        categoryIds: product.categoryIds,
      });
    } else {
      setSelectedProduct(null);
      setFormData(defaultFormData);
    }
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedProduct(null);
    setFormData(defaultFormData);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (selectedProduct) {
        await productService.update(selectedProduct.id, formData);
      } else {
        await productService.create(formData);
      }
      handleCloseModal();
      loadProducts();
    } catch (error) {
      console.error("İşlem sırasında hata oluştu:", error);
    }
  };

  const handleDelete = async (product: Product) => {
    if (window.confirm("Bu ürünü silmek istediğinizden emin misiniz?")) {
      try {
        await productService.delete(product.id);
        loadProducts();
      } catch (error) {
        console.error("Silme işlemi sırasında hata oluştu:", error);
      }
    }
  };

  const formatPrice = (price: number) => {
    return new Intl.NumberFormat("tr-TR", {
      style: "currency",
      currency: "TRY",
    }).format(price);
  };

  const columns: Column<Product>[] = [
    { header: "Ürün Adı", field: (product: Product) => product.name },
    { header: "Açıklama", field: (product: Product) => product.description },
    { header: "Ürün Kodu ", field: (product: Product) => product.sku },
    {
      header: "Fiyat",
      field: (product: Product) => formatPrice(product.price),
    },
    {
      header: "Stok",
      field: (product: Product) => String(product.stockQuantity),
    },
    {
      header: "Kategoriler",
      field: (item) =>
        item.categoryIds
          .map((id) => {
            const category = categories.find((c) => c.id === id);
            return category ? category.name : "";
          })
          .join(", "),
    },
  ];

  const formFields = [
    { name: "name", label: "Ürün Adı", type: "text", required: true },
    {
      name: "description",
      label: "Açıklama",
      type: "text",
      as: "textarea" as const,
      rows: 3,
      required: true,
    },
    { name: "sku", label: "Ürün Kodu", type: "text", required: true },
    { name: "price", label: "Fiyat", type: "number", required: true },
    { name: "stockQuantity", label: "Stok", type: "number", required: true },
    {
      name: "categoryIds",
      label: "Kategoriler",
      type: "select",
      as: "select" as const,
      options: categories.map((c) => ({ value: c.id, label: c.name })),
      required: true,
      multiple: true,
    },
  ];

  return (
    <div>
      <PageHeader
        title="Ürün Yönetimi"
        buttonText="Yeni Ürün"
        onButtonClick={() => handleShowModal()}
      />

      <DataTable
        data={products}
        columns={columns}
        onEdit={handleShowModal}
        onDelete={handleDelete}
      />

      <FormModal
        show={showModal}
        onHide={handleCloseModal}
        title={selectedProduct ? "Ürün Düzenle" : "Yeni Ürün"}
        fields={formFields}
        values={formData}
        onChange={(name, value) => setFormData({ ...formData, [name]: value })}
        onSubmit={handleSubmit}
        isEdit={!!selectedProduct}
      />
    </div>
  );
};
