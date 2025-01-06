import React from "react";
import { Table, Button } from "react-bootstrap";

export interface Column<T> {
  header: string;
  field: keyof T | ((item: T) => React.ReactNode);
}

interface DataTableProps<T> {
  data: T[];
  columns: Column<T>[];
  onEdit?: (item: T) => void;
  onDelete?: (item: T) => void;
  actions?: boolean;
}

export const DataTable = <T extends { id: string }>({
  data,
  columns,
  onEdit,
  onDelete,
  actions = true,
}: DataTableProps<T>) => {
  const renderCell = (item: T, field: Column<T>["field"]) => {
    if (typeof field === "function") {
      return field(item);
    }
    return String(item[field]);
  };

  return (
    <Table striped bordered hover responsive>
      <thead>
        <tr>
          {columns.map((column, index) => (
            <th key={index}>{column.header}</th>
          ))}
          {actions && <th>İşlemler</th>}
        </tr>
      </thead>
      <tbody>
        {data.map((item) => (
          <tr key={item.id}>
            {columns.map((column, index) => (
              <td key={index}>{renderCell(item, column.field)}</td>
            ))}
            {actions && (
              <td>
                {onEdit && (
                  <Button
                    variant="info"
                    size="sm"
                    className="me-2"
                    onClick={() => onEdit(item)}
                  >
                    Düzenle
                  </Button>
                )}
                {onDelete && (
                  <Button
                    variant="danger"
                    size="sm"
                    onClick={() => onDelete(item)}
                  >
                    Sil
                  </Button>
                )}
              </td>
            )}
          </tr>
        ))}
      </tbody>
    </Table>
  );
};
