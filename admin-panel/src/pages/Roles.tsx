import React, { useState, useEffect } from "react";
import { DataTable, PageHeader, FormModal } from "../components/ui";
import { Role, Permission, UpdateRole, CreateRole } from "../types/models";
import { permissionService, roleService } from "../services/api";
import { Badge } from "react-bootstrap";

const defaultFormData = {
  name: "",
  permissions: [] as Permission[],
};

const Roles: React.FC = () => {
  const [roles, setRoles] = useState<Role[]>([]);
  const [permissions, setPermissions] = useState<Permission[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedRole, setSelectedRole] = useState<Role | null>(null);
  const [formData, setFormData] = useState(defaultFormData);

  useEffect(() => {
    loadRoles();
    loadPermissions();
  }, []);

  const loadRoles = async () => {
    try {
      const data = await roleService.getAll();
      setRoles(data);
    } catch (error) {
      console.error("Roller yüklenirken hata oluştu:", error);
    }
  };

  const loadPermissions = async () => {
    try {
      const data = await permissionService.getAll();
      setPermissions(data);
    } catch (error) {
      console.error("İzinler yüklenirken hata oluştu:", error);
    }
  };

  const handleShowModal = (role?: Role) => {
    if (role) {
      setSelectedRole(role);
      setFormData({
        name: role.name,
        permissions: role.permissions,
      });
    } else {
      setSelectedRole(null);
      setFormData(defaultFormData);
    }
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedRole(null);
    setFormData(defaultFormData);
  };

  const handleDelete = async (role: Role) => {
    if (window.confirm("Bu rolü silmek istediğinizden emin misiniz?")) {
      try {
        await roleService.deleteRole(Number(role.id));
        loadRoles();
      } catch (error) {
        console.error("Silme işlemi sırasında hata oluştu:", error);
      }
    }
  };

  const columns = [
    { header: "Rol Adı", field: (role: Role) => role.name },
    {
      header: "Yetkiler",
      field: (role: Role) => (
        <div className="flex flex-wrap gap-2">
          {role.permissions.map((role) => {
            return (
              <Badge pill bg="secondary" className="ms-1">
                {role.name}
              </Badge>
            );
          })}
        </div>
      ),
    },
  ];

  const formFields = [
    { name: "name", label: "Rol Adı", type: "text", required: true },
    {
      name: "permissions",
      label: "Yetkiler",
      type: "select",
      as: "select" as const,
      options: permissions.map((p) => ({ value: p.id, label: p.name })),
      multiple: true,
      required: true,
    },
  ];

  return (
    <div>
      <PageHeader
        title="Rol Yönetimi"
        buttonText="Yeni Rol"
        onButtonClick={() => handleShowModal()}
      />

      <DataTable
        data={roles}
        columns={columns}
        onEdit={handleShowModal}
        onDelete={handleDelete}
      />

      <FormModal
        show={showModal}
        onHide={handleCloseModal}
        title={selectedRole ? "Rol Düzenle" : "Yeni Rol"}
        fields={formFields}
        values={formData}
        onChange={(name, value) => {
          if (name === "permissions" && Array.isArray(value)) {
            setFormData({
              ...formData,
              [name]: value.map((permissionId) => permissionId),
            });
          } else {
            setFormData({ ...formData, [name]: value });
          }
        }}
        onSubmit={async (e) => {
          e.preventDefault();
          try {
            if (selectedRole) {
              await roleService.updateRole({
                id: Number(selectedRole.id),
                name: formData.name,
                permissionIds: formData.permissions.map((p) => Number(p)),
              } as UpdateRole);
            } else {
              await roleService.createRole({
                name: formData.name,
                permissionIds: formData.permissions.map((p) => Number(p)),
              } as CreateRole);
            }
            handleCloseModal();
            loadRoles();
          } catch (error) {
            console.error("İşlem sırasında hata oluştu:", error);
          }
        }}
        isEdit={!!selectedRole}
      />
    </div>
  );
};

export default Roles;
