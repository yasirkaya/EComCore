import React from "react";
import { Row, Col, Button } from "react-bootstrap";

interface PageHeaderProps {
  title: string;
  buttonText?: string;
  onButtonClick?: () => void;
}

export const PageHeader: React.FC<PageHeaderProps> = ({
  title,
  buttonText,
  onButtonClick,
}) => {
  return (
    <Row className="mb-4 align-items-center">
      <Col>
        <h2 className="m-0">{title}</h2>
      </Col>
      {buttonText && onButtonClick && (
        <Col xs="auto">
          <Button variant="primary" onClick={onButtonClick}>
            {buttonText}
          </Button>
        </Col>
      )}
    </Row>
  );
};
