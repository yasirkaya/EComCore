import React, { useEffect, useState } from "react";
import { Row, Col, Card } from "react-bootstrap";
import { PageHeader } from "../components/ui";
import { userService, productService, categoryService } from "../services/api";

interface DashboardStats {
  totalUsers: number;
  totalProducts: number;
  totalCategories: number;
}

export const Dashboard: React.FC = () => {
  const [stats, setStats] = useState<DashboardStats>({
    totalUsers: 0,
    totalProducts: 0,
    totalCategories: 0,
  });

  useEffect(() => {
    const loadStats = async () => {
      try {
        const [users, products, categories] = await Promise.all([
          userService.getAll(),
          productService.getAll(),
          categoryService.getAll(),
        ]);

        setStats({
          totalUsers: users.length,
          totalProducts: products.length,
          totalCategories: categories.length,
        });
      } catch (error) {
        console.error("İstatistikler yüklenirken hata oluştu:", error);
      }
    };

    loadStats();
  }, []);

  return (
    <div>
      <PageHeader title="Dashboard" />
      <Row>
        <Col md={4}>
          <Card className="mb-4">
            <Card.Body>
              <Card.Title>Toplam Kullanıcı</Card.Title>
              <Card.Text className="display-4">{stats.totalUsers}</Card.Text>
            </Card.Body>
          </Card>
        </Col>
        <Col md={4}>
          <Card className="mb-4">
            <Card.Body>
              <Card.Title>Toplam Ürün</Card.Title>
              <Card.Text className="display-4">{stats.totalProducts}</Card.Text>
            </Card.Body>
          </Card>
        </Col>
        <Col md={4}>
          <Card className="mb-4">
            <Card.Body>
              <Card.Title>Toplam Kategori</Card.Title>
              <Card.Text className="display-4">
                {stats.totalCategories}
              </Card.Text>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </div>
  );
};
