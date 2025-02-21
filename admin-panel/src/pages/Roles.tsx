import React, { useState, useEffect } from "react";
import { DataTable, PageHeader, FormModal } from "../components/ui";
import { Button } from "react-bootstrap";

interface Role {
  id: string;
  name: string;
  description: string;
  permissions: string[];
  userCount: number;
}

const Roles: React.FC = () => {
  const [roles, setRoles] = useState<Role[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedRole, setSelectedRole] = useState<Role | null>(null);

  useEffect(() => {
    loadRoles();
  }, []);

  const loadRoles = async () => {
    // API call to fetch roles
    //const data = await fetchRoles();
    //setRoles(data);
  };

  const handleShowModal = (role?: Role) => {
    if (role) {
      setSelectedRole(role);
    } else {
      setSelectedRole(null);
    }
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedRole(null);
  };

  const handleDelete = async (role: Role) => {
    if (window.confirm("Bu rolü silmek istediğinizden emin misiniz?")) {
      //await deleteRole(role.id);
      loadRoles();
    }
  };

  const columns = [
    { header: "Rol Adı", field: (role: Role) => role.name },
    { header: "Açıklama", field: (role: Role) => role.description },
    { header: "Yetkiler", field: (role: Role) => role.permissions.join(", ") },
    { header: "Kullanıcı Sayısı", field: (role: Role) => role.userCount },
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
        fields={[
          { name: "name", label: "Rol Adı", type: "text", required: true },
          {
            name: "description",
            label: "Açıklama",
            type: "text",
            as: "textarea",
            rows: 3,
            required: true,
          },
          {
            name: "permissions",
            label: "Yetkiler",
            type: "select",
            as: "select",
            options: [],
            multiple: true,
          },
        ]}
        values={selectedRole || { name: "", description: "", permissions: [] }}
        onChange={(name, value) =>
          setSelectedRole({ ...selectedRole, [name]: value } as Role)
        }
        onSubmit={async (e) => {
          e.preventDefault();
          if (selectedRole) {
            //await updateRole(selectedRole);
          } else {
            //await createRole(selectedRole);
          }
          handleCloseModal();
          loadRoles();
        }}
        isEdit={!!selectedRole}
      />
    </div>
  );
};

export default Roles;
