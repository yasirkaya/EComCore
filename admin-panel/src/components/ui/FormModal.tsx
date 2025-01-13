import React from "react";
import { Modal, Button, Form } from "react-bootstrap";

interface FormField {
  name: string;
  label: string;
  type: string;
  required?: boolean;
  as?: "input" | "textarea" | "select";
  rows?: number;
  options?: Array<{ value: string; label: string }>;
}

interface FormModalProps {
  show: boolean;
  onHide: () => void;
  title: string;
  fields: FormField[];
  values: Record<string, any>;
  onChange: (name: string, value: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  isEdit?: boolean;
}

export const FormModal: React.FC<FormModalProps> = ({
  show,
  onHide,
  title,
  fields,
  values,
  onChange,
  onSubmit,
  isEdit = false,
}) => {
  const renderField = (field: FormField) => {
    const commonProps = {
      type: field.type,
      value: values[field.name],
      onChange: (e: React.ChangeEvent<HTMLInputElement>) =>
        onChange(field.name, e.target.value),
      required: field.required,
    };

    if (field.as === "select" && field.options) {
      return (
        <Form.Select
          value={values[field.name]}
          onChange={(e) => onChange(field.name, e.target.value)}
          required={field.required}
        >
          <option value="">Seçiniz</option>
          {field.options.map((option) => (
            <option
              key={option.value}
              value={option.value}
              selected={values[field.name] === option.value}
            >
              {option.label}
            </option>
          ))}
        </Form.Select>
      );
    }

    if (field.as === "textarea") {
      return <Form.Control {...commonProps} as="textarea" rows={field.rows} />;
    }

    return <Form.Control {...commonProps} />;
  };

  return (
    <Modal show={show} onHide={onHide}>
      <Modal.Header closeButton>
        <Modal.Title>{title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form onSubmit={onSubmit}>
          {fields.map((field) => (
            <Form.Group key={field.name} className="mb-3">
              <Form.Label>{field.label}</Form.Label>
              {renderField(field)}
            </Form.Group>
          ))}
          <Button variant="primary" type="submit">
            {isEdit ? "Güncelle" : "Ekle"}
          </Button>
        </Form>
      </Modal.Body>
    </Modal>
  );
};
