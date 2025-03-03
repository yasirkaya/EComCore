import React, { useEffect, useState } from "react";
import { User, Role, UserRole } from "../types/models";
import { roleService, userService } from "../services/api";
import { DataTable, FormModal, PageHeader } from "../components/ui";
import { Column } from "../components/ui";
import { Button, Form, Modal } from "react-bootstrap";
import userRoleService from "../services/api/userRole.sevice";

const defaultFormData = {
  roles: [] as Role[],
};

export const Users: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedUser, setSelectedUser] = useState<User | null>(null);
  const [formData, setFormData] = useState<{ roles: Role[] }>(defaultFormData);
  const [roles, setRoles] = useState<Role[]>([]);

  useEffect(() => {
    loadUsers();
    loadRoles();
  }, []);

  const loadUsers = async () => {
    try {
      const data = await userService.getAll();
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

  const loadRoles = async () => {
    try {
      const data = await roleService.getAll(); // Roller için ayrı bir endpoint varsa
      setRoles(data);
    } catch (error) {
      console.error("Roller yüklenirken hata oluştu:", error);
    }
  };

  const handleShowModal = (user?: User) => {
    if (user) {
      setSelectedUser(user);
      setFormData({
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
        const userId = selectedUser.id;
        const selectedroleIds = formData.roles.map((role) => role.id);
        const currentRoleIds =
          users
            .find((user) => user.id === userId)
            ?.roles.map((role) => role.id) || [];
        const rolesToAdd = selectedroleIds.filter(
          (id) => !currentRoleIds.includes(id)
        );
        const rolesToRemove = currentRoleIds.filter(
          (id) => !selectedroleIds.includes(id)
        );

        for (const roleId of rolesToAdd) {
          await userRoleService.create({ userId, roleId } as UserRole);
        }

        for (const roleId of rolesToRemove) {
          await userRoleService.deleteByUserIdAndRoleId(userId, roleId);
        }
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

      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>
            {selectedUser ? "Kullanıcı Düzenle" : "Davet Gönder"}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3">
              <Form.Label>Roller</Form.Label>
              <Form.Select
                multiple
                required
                value={formData.roles.map((role) => role.id)}
                onChange={(e) => {
                  const selectedRoleIds = Array.from(
                    e.target.selectedOptions,
                    (option) => Number(option.value)
                  );

                  setFormData((prevData) => {
                    const currentRoleIds = prevData.roles.map((role) =>
                      Number(role.id)
                    );

                    let updatedRoleIds: number[];
                    if (currentRoleIds.includes(selectedRoleIds[0])) {
                      updatedRoleIds = currentRoleIds.filter(
                        (id) => Number(id) !== selectedRoleIds[0]
                      );
                    } else {
                      updatedRoleIds = [...currentRoleIds, selectedRoleIds[0]];
                    }

                    const updatedRoles = roles.filter((role) =>
                      updatedRoleIds.includes(Number(role.id))
                    );

                    return { ...prevData, roles: updatedRoles };
                  });
                }}
              >
                {roles.map((option) => (
                  <option key={option.id} value={option.id}>
                    {option.name}
                  </option>
                ))}
              </Form.Select>
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
