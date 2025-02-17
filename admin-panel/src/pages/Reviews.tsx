import React, { useEffect, useState } from "react";
import { Review, ReviewStatus } from "../types/models";
import { reviewService } from "../services/api";
import { DataTable, FormModal, PageHeader, Column } from "../components/ui";
import { Button, Form, InputGroup, Pagination } from "react-bootstrap";

const defaultFormData = {
  id: "0",
  status: ReviewStatus.Pending as number, 
  moderationReason: "",
};

export const Reviews: React.FC = () => {
  const [reviews, setReviews] = useState<Review[]>([]);
  const [filteredReviews, setFilteredReviews] = useState<Review[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedReview, setSelectedReview] = useState<Review | null>(null);
  const [formData, setFormData] = useState(defaultFormData);
  const [searchTerm, setSearchTerm] = useState("");
  const [filterStatus, setFilterStatus] = useState<ReviewStatus | null>(null);
  const [currentPage, setCurrentPage] = useState(1);
  const [reviewsPerPage] = useState(10);

  useEffect(() => {
    loadReviews();
  }, []);

  useEffect(() => {
    filterReviews();
  }, [searchTerm, filterStatus, reviews]);

  const loadReviews = async () => {
    try {
      const data = await reviewService.getAll();
      if (Array.isArray(data)) {
        setReviews(data);
      } else {
        console.error("Beklenmeyen veri formatı:", data);
        setReviews([]);
      }
    } catch (error) {
      console.error("Yorumlar yüklenirken hata oluştu:", error);
      setReviews([]);
    }
  };

  const filterReviews = () => {
    let filtered = reviews;
    if (searchTerm) {
      filtered = filtered.filter((review) =>
        review.comment.toLowerCase().includes(searchTerm.toLowerCase())
      );
    }
    if (filterStatus) {
      filtered = filtered.filter((review) => review.status === Number(filterStatus));
    }
    setFilteredReviews(filtered);
  };

  const handleShowModal = (review?: Review) => {
    if (review) {
      setSelectedReview(review);
      setFormData({
        id: review.id,
        status: review.status as number,
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
        console.log("Güncelleme işlemi yapılacak:", formData);
        await reviewService.updateStatus(
          selectedReview.id,
          formData.status as ReviewStatus,
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
      field: (review: Review) => {
        let statusVariant, statusText;
  
        switch (review.status) {
          case ReviewStatus.Approved:
            statusVariant = "success"; // Yeşil
            statusText = "✅ Onaylandı";
            break;
          case ReviewStatus.Rejected:
            statusVariant = "danger"; // Kırmızı
            statusText = "❌ Reddedildi";
            break;
          case ReviewStatus.Pending:
            statusVariant = "warning"; // Sarı
            statusText = "⏳ Beklemede";
            break;
          default:
            statusVariant = "secondary"; // Gri
            statusText = "❓ Bilinmiyor";
        }
        return (
          <span className={`badge bg-${statusVariant} p-2 rounded`} style={{ minWidth: "100px", display: "inline-block", textAlign: "center" }}>
            {statusText}
          </span>
        );
      },
    },
    { 
      header: "Tarih", 
      field: (review: Review) => {
        const date = new Date(review.createdAt);
        return date.toLocaleDateString("tr-TR", {
          day: "2-digit",
          month: "2-digit",
          year: "numeric",
        });
      }
    },
  ];

  const formFields = [
    {
      name: "status",
      label: "Durum",
      type: "select",
      as: "select" as const,
      options: [
        { value: ReviewStatus.Approved.toString(), label: "Onaylandı" },
        { value: ReviewStatus.Rejected.toString(), label: "Reddedildi" },
        { value: ReviewStatus.Pending.toString(), label: "Beklemede" },
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

  // Get current reviews
  const indexOfLastReview = currentPage * reviewsPerPage;
  const indexOfFirstReview = indexOfLastReview - reviewsPerPage;
  const currentReviews = filteredReviews.slice(indexOfFirstReview, indexOfLastReview);

  // Change page
  const paginate = (pageNumber: number) => setCurrentPage(pageNumber);

  return (
    <div>
      <PageHeader title="Yorum Yönetimi" />

      <div className="d-flex justify-content-center mb-3">
  <div className="d-flex align-items-center gap-3" style={{ maxWidth: "600px", width: "100%" }}>
    <Form.Control
      placeholder="🔍 Yorumlarda ara..."
      value={searchTerm}
      onChange={(e) => setSearchTerm(e.target.value)}
      className="flex-grow-1 p-2 rounded"
      style={{ border: "1px solid #ccc", borderRadius: "8px" }}
    />
    <Form.Select
  value={filterStatus === null ? "" : filterStatus} // filterStatus null ise boş string göster
  onChange={(e) => {
    const value = e.target.value;
    setFilterStatus(value === "" ? null : (value as unknown as ReviewStatus));
  }}
  className="p-2 rounded"
  style={{ minWidth: "180px", border: "1px solid #ccc", borderRadius: "8px" }}
>
  <option value="">Tüm Durumlar</option>
  <option value={ReviewStatus.Pending}>⏳ Beklemede</option>
  <option value={ReviewStatus.Approved}>✅ Onaylandı</option>
  <option value={ReviewStatus.Rejected}>❌ Reddedildi</option>
</Form.Select>
  </div>
</div>

      <DataTable
        data={currentReviews}
        columns={columns}
        onEdit={handleShowModal}
        onDelete={handleDelete}
      />

      <Pagination>
        {Array.from({ length: Math.ceil(filteredReviews.length / reviewsPerPage) }, (_, index) => (
          <Pagination.Item key={index + 1} active={index + 1 === currentPage} onClick={() => paginate(index + 1)}>
            {index + 1}
          </Pagination.Item>
        ))}
      </Pagination>

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
