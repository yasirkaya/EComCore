import React, { useEffect, useState } from "react";
import { Category } from "../types/models";
import { categoryService } from "../services/api";
import { DataTable, FormModal, PageHeader, Column } from "../components/ui";

const defaultFormData = {
  name: "",
  description: "",
  parentId: "",
};

export const Categories: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState<Category | null>(
    null
  );
  const [formData, setFormData] = useState(defaultFormData);

  useEffect(() => {
    loadCategories();
  }, []);

  const loadCategories = async () => {
    try {
      const data = await categoryService.getAll();
      setCategories(data);
    } catch (error) {
      console.error("Kategoriler yüklenirken hata oluştu:", error);
    }
  };

  const handleShowModal = (category?: Category) => {
    if (category) {
      setSelectedCategory(category);
      setFormData({
        name: category.name,
        description: category.description,
        parentId: category.parentId || "",
      });
    } else {
      setSelectedCategory(null);
      setFormData(defaultFormData);
    }
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedCategory(null);
    setFormData(defaultFormData);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (selectedCategory) {
        await categoryService.update(selectedCategory.id, formData);
      } else {
        await categoryService.create(formData);
      }
      handleCloseModal();
      loadCategories();
    } catch (error) {
      console.error("İşlem sırasında hata oluştu:", error);
    }
  };

  const handleDelete = async (category: Category) => {
    if (window.confirm("Bu kategoriyi silmek istediğinizden emin misiniz?")) {
      try {
        await categoryService.delete(category.id);
        loadCategories();
      } catch (error) {
        console.error("Silme işlemi sırasında hata oluştu:", error);
      }
    }
  };

  const getParentName = (category: Category) => {
    if (!category.parentId) return "-";
    const parent = categories.find((c) => c.id === category.parentId);
    return parent ? parent.name : "-";
  };

  const columns: Column<Category>[] = [
    { header: "Kategori Adı", field: (category: Category) => category.name },
    { header: "Açıklama", field: (category: Category) => category.description },
    {
      header: "Üst Kategori",
      field: (category: Category) => getParentName(category),
    },
  ];

  const formFields = [
    { name: "name", label: "Kategori Adı", type: "text", required: true },
    {
      name: "description",
      label: "Açıklama",
      type: "text",
      as: "textarea" as const,
      rows: 3,
      required: true,
    },
    {
      name: "parentId",
      label: "Üst Kategori",
      type: "select",
      as: "select" as const,
      options: categories.map((c) => ({ value: c.id, label: c.name })),
      multiple: false,
    },
  ];

  return (
    <div>
      <PageHeader
        title="Kategori Yönetimi"
        buttonText="Yeni Kategori"
        onButtonClick={() => handleShowModal()}
      />

      <DataTable
        data={categories}
        columns={columns}
        onEdit={handleShowModal}
        onDelete={handleDelete}
      />

      <FormModal
        show={showModal}
        onHide={handleCloseModal}
        title={selectedCategory ? "Kategori Düzenle" : "Yeni Kategori"}
        fields={formFields}
        values={formData}
        onChange={(name, value) => setFormData({ ...formData, [name]: value })}
        onSubmit={handleSubmit}
        isEdit={!!selectedCategory}
      />
    </div>
  );
};
