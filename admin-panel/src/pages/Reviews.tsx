import React, { useEffect, useState } from "react";
import { Review } from "../types/models";
import { reviewService } from "../services/api";
import { DataTable, FormModal, PageHeader, Column } from "../components/ui";
import { Button } from "react-bootstrap";

const defaultFormData = {
  id: "",
  status: "",
  moderationReason: "",
};

export const Reviews: React.FC = () => {
  const [reviews, setReviews] = useState<Review[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedReview, setSelectedReview] = useState<Review | null>(null);
  const [formData, setFormData] = useState(defaultFormData);

  useEffect(() => {
    loadReviews();
  }, []);

  const loadReviews = async () => {
    try {
      const data = await reviewService.getAll();
      setReviews(data);
    } catch (error) {
      console.error("Yorumlar yüklenirken hata oluştu:", error);
    }
  };

  const handleShowModal = (review?: Review) => {
    if (review) {
      setSelectedReview(review);
      setFormData({
        id: review.id,
        status: review.status,
        moderationReason: review.moderationReason || "",
      });
    } else {
      setSelectedReview(null);
      setFormData(defaultFormData);
    }
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedReview(null);
    setFormData(defaultFormData);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (selectedReview) {
        await reviewService.updateStatus(
          selectedReview.id,
          formData.status,
          formData.moderationReason
        );
      }
      handleCloseModal();
      loadReviews();
    } catch (error) {
      console.error("İşlem sırasında hata oluştu:", error);
    }
  };

  const handleDelete = async (review: Review) => {
    if (window.confirm("Bu yorumu silmek istediğinizden emin misiniz?")) {
      try {
        await reviewService.delete(review.id);
        loadReviews();
      } catch (error) {
        console.error("Silme işlemi sırasında hata oluştu:", error);
      }
    }
  };

  const columns: Column<Review>[] = [
    { header: "Ürün Adı", field: (review: Review) => review.productName },
    { header: "Kullanıcı", field: (review: Review) => review.userName },
    { header: "Yorum", field: (review: Review) => review.comment },
    { header: "Puan", field: (review: Review) => String(review.rating) },
    {
      header: "Durum",
      field: (review: Review) => (
        <Button
          variant={
            review.status === "Onaylandı"
              ? "outline-success"
              : review.status === "Reddedildi"
              ? "outline-danger"
              : "outline-warning"
          }
          size="sm"
        >
          {review.status}
        </Button>
      ),
    },
  ];

  const formFields = [
    {
      name: "status",
      label: "Durum",
      type: "select",
      as: "select" as const,
      options: [
        { value: "Onaylandı", label: "Onaylandı" },
        { value: "Reddedildi", label: "Reddedildi" },
        { value: "Beklemede", label: "Beklemede" },
      ],
      required: true,
    },
    {
      name: "moderationReason",
      label: "Moderasyon Sebebi",
      type: "text",
      as: "textarea" as const,
      rows: 3,
    },
  ];

  return (
    <div>
      <PageHeader title="Yorum Yönetimi" />

      <DataTable
        data={reviews}
        columns={columns}
        onEdit={handleShowModal}
        onDelete={handleDelete}
      />

      <FormModal
        show={showModal}
        onHide={handleCloseModal}
        title={selectedReview ? "Yorum Durumunu Güncelle" : "Yeni Yorum"}
        fields={formFields}
        values={formData}
        onChange={(name, value) => setFormData({ ...formData, [name]: value })}
        onSubmit={handleSubmit}
        isEdit={!!selectedReview}
      />
    </div>
  );
};
