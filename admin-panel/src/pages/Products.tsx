import React, { useEffect, useState } from "react";
import { Product } from "../types/models";
import { productService } from "../services/api";
import { DataTable, FormModal, PageHeader, Column } from "../components/ui";

const defaultFormData = {
  name: "",
  description: "",
  price: 0,
  stockQuantity: 0,
  categoryId: "",
};

export const Products: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);
  const [formData, setFormData] = useState(defaultFormData);

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    try {
      const data = await productService.getAll();
      setProducts(data);
    } catch (error) {
      console.error("Ürünler yüklenirken hata oluştu:", error);
    }
  };

  const handleShowModal = (product?: Product) => {
    if (product) {
      setSelectedProduct(product);
      setFormData({
        name: product.name,
        description: product.description,
        price: product.price,
        stockQuantity: product.stockQuantity,
        categoryId: product.categoryId,
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
    {
      header: "Fiyat",
      field: (product: Product) => formatPrice(product.price),
    },
    {
      header: "Stok",
      field: (product: Product) => String(product.stockQuantity),
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
    { name: "price", label: "Fiyat", type: "number", required: true },
    { name: "stockQuantity", label: "Stok", type: "number", required: true },
    { name: "categoryId", label: "Kategori", type: "text", required: true },
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
