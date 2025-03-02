import React, { useEffect, useState } from "react";
import { User, Role } from "../types/models";
import { userService } from "../services/api";
import { DataTable, FormModal, PageHeader } from "../components/ui";
import { Column } from "../components/ui";
import { Button, Form, Modal } from "react-bootstrap";

const defaultFormData = {
  email: "",
  username: "",
  isDeleted: true,
  isEmailVerified: true,
  roles: [] as Role[],
};

export const Users: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedUser, setSelectedUser] = useState<User | null>(null);
  const [formData, setFormData] = useState(defaultFormData);

  useEffect(() => {
    loadUsers();
  }, []);

  const loadUsers = async () => {
    try {
      console.log("Loading users...");
      const data = await userService.getAll();
      console.log("Users loaded:", data);
      setUsers(data);
    } catch (error) {
      console.error("Kullanıcılar yüklenirken hata detayları:", {
        error,
        status: (error as any)?.response?.status,
        data: (error as any)?.response?.data,
        config: (error as any)?.config,
      });
    }
  };

  const handleShowModal = (user?: User) => {
    if (user) {
      setSelectedUser(user);
      setFormData({
        email: user.email,
        username: user.username,
        isDeleted: user.isDeleted,
        isEmailVerified: user.isEmailVerified,
        roles: user.roles,
      });
    } else {
      setSelectedUser(null);
      setFormData(defaultFormData);
    }
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedUser(null);
    setFormData(defaultFormData);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (selectedUser) {
        await userService.update(selectedUser.id, formData);
      } else {
        await userService.create(formData);
      }
      handleCloseModal();
      loadUsers();
    } catch (error) {
      console.error("İşlem sırasında hata oluştu:", error);
    }
  };

  const handleDelete = async (user: User) => {
    if (window.confirm("Bu kullanıcıyı silmek istediğinizden emin misiniz?")) {
      try {
        await userService.delete(user.id);
        loadUsers();
      } catch (error) {
        console.error("Silme işlemi sırasında hata oluştu:", error);
      }
    }
  };

  const columns: Column<User>[] = [
    { header: "Kullanıcı Adı", field: (user: User) => user.username },
    { header: "Email", field: (user: User) => user.email },
    {
      header: "Durum",
      field: (user: User) => (user.isDeleted ? "Pasif" : "Aktif"),
    },
    {
      header: "Email Doğrulama",
      field: (user: User) =>
        user.isEmailVerified ? "Doğrulandı" : "Doğrulanmadı",
    },
    {
      header: "Roller",
      field: (user: User) => (
        <div className="flex flex-wrap gap-2">
          {user.roles.map((role) => {
            let statusVariant, statusText;

            switch (role.name) {
              case "Admin":
                statusVariant = "primary";
                statusText = "🔒 Admin";
                break;
              case "Customer":
                statusVariant = "secondary";
                statusText = "🛒 Müşteri";
                break;
              case "Manager":
                statusVariant = "success";
                statusText = "👔 Yönetici";
                break;
              default:
                statusVariant = "warning";
                statusText = "❓ Bilinmiyor";
            }
            return (
              <span
                key={role.name}
                className={`badge text-bg-${statusVariant} ms-2 p-2 `}
              >
                {statusText}
              </span>
            );
          })}
        </div>
      ),
    },
  ];

  const formFields = [
    { name: "email", label: "Email", type: "email", required: true },
    { name: "firstName", label: "Ad", type: "text", required: true },
    { name: "lastName", label: "Soyad", type: "text", required: true },
    {
      name: "password",
      label: "Şifre",
      type: "password",
      required: !selectedUser,
    },
  ];

  return (
    <div>
      <PageHeader
        title="Kullanıcı Yönetimi"
        buttonText="Davet Gönder"
        onButtonClick={() => handleShowModal()}
      />

      <DataTable
        data={users}
        columns={columns}
        onEdit={handleShowModal}
        onDelete={handleDelete}
      />

      {/* <FormModal
        show={showModal}
        onHide={handleCloseModal}
        title={selectedUser ? "Kullanıcı Düzenle" : "Davet Gönder"}
        fields={formFields}
        values={formData}
        onChange={(name, value) => setFormData({ ...formData, [name]: value })}
        onSubmit={handleSubmit}
        isEdit={!!selectedUser}
      /> */}

      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>
            {selectedUser ? "Kullanıcı Düzenle" : "Davet Gönder"}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3">
              <Form.Label>Email</Form.Label>
              <Form.Control
                type="email"
                value={formData.email}
                onChange={(e) =>
                  setFormData({ ...formData, email: e.target.value })
                }
              />
            </Form.Group>
            <Button variant="primary" type="submit">
              {!!selectedUser ? "Güncelle" : "Ekle"}
            </Button>
          </Form>
        </Modal.Body>
      </Modal>
    </div>
  );
};
