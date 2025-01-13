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
  multiple?: boolean;
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
      onChange: (
        e: React.ChangeEvent<
          HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement
        >
      ) => {
        if (field.multiple && e.target instanceof HTMLSelectElement) {
          console.log("girdiiiii");
          const selectedOptions = Array.from(
            e.target.selectedOptions,
            (option) => option.value
          );
          const currentValues = values[field.name] || [];
          const newValues = [
            ...new Set([...currentValues.map(String), ...selectedOptions]),
          ];
          onChange(field.name, newValues);
          console.log("selectedOptions", newValues);
        } else {
          console.log("girmediiii");
          onChange(field.name, e.target.value);
        }
      },
      required: field.required,
    };

    if (field.as === "select" && field.options) {
      return (
        <Form.Select
          {...commonProps}
          multiple={field.multiple}
          value={values[field.name] || []} // value prop'u burada ayarlanıyor
        >
          {field.options.map((option) => (
            <option key={option.value} value={option.value}>
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
