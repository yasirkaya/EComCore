import React, { useState, useEffect } from "react";
import { Container, Row, Col, Card, Table } from "react-bootstrap";
import { Line, Bar } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";

// Chart.js'yi kaydet
ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  BarElement,
  Title,
  Tooltip,
  Legend
);

const Dashboard = () => {
  const [stats, setStats] = useState({
    totalUsers: 1250,
    totalProducts: 456,
    totalOrders: 789,
    totalRevenue: 125000,
    recentOrders: [
      {
        id: 1,
        customer: "Ahmet Yılmaz",
        amount: 1200,
        status: "Tamamlandı",
        date: "2024-03-17",
      },
      {
        id: 2,
        customer: "Ayşe Demir",
        amount: 850,
        status: "İşleniyor",
        date: "2024-03-16",
      },
      {
        id: 3,
        customer: "Mehmet Kaya",
        amount: 2100,
        status: "Tamamlandı",
        date: "2024-03-15",
      },
      {
        id: 4,
        customer: "Zeynep Çelik",
        amount: 950,
        status: "Beklemede",
        date: "2024-03-14",
      },
    ],
    topProducts: [
      { name: "iPhone 15", sales: 45, revenue: 67500 },
      { name: "Samsung Galaxy S24", sales: 38, revenue: 49400 },
      { name: "MacBook Pro", sales: 25, revenue: 87500 },
      { name: "AirPods Pro", sales: 120, revenue: 36000 },
    ],
  });

  const salesData = {
    labels: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran"],
    datasets: [
      {
        label: "Aylık Satışlar (₺)",
        data: [65000, 59000, 80000, 81000, 56000, 95000],
        fill: false,
        borderColor: "rgb(75, 192, 192)",
        tension: 0.1,
      },
    ],
  };

  const categoryData = {
    labels: ["Elektronik", "Giyim", "Kitap", "Spor", "Ev & Yaşam"],
    datasets: [
      {
        label: "Kategori Bazlı Satışlar",
        data: [300, 250, 150, 100, 200],
        backgroundColor: [
          "rgba(255, 99, 132, 0.5)",
          "rgba(54, 162, 235, 0.5)",
          "rgba(255, 206, 86, 0.5)",
          "rgba(75, 192, 192, 0.5)",
          "rgba(153, 102, 255, 0.5)",
        ],
      },
    ],
  };

  return (
    <Container fluid className="py-4">
      {/* İstatistik Kartları */}
      <Row className="mb-4">
        <Col md={3}>
          <Card className="h-100">
            <Card.Body>
              <Card.Title>Toplam Kullanıcı</Card.Title>
              <h3>{stats.totalUsers}</h3>
            </Card.Body>
          </Card>
        </Col>
        <Col md={3}>
          <Card className="h-100">
            <Card.Body>
              <Card.Title>Toplam Ürün</Card.Title>
              <h3>{stats.totalProducts}</h3>
            </Card.Body>
          </Card>
        </Col>
        <Col md={3}>
          <Card className="h-100">
            <Card.Body>
              <Card.Title>Toplam Sipariş</Card.Title>
              <h3>{stats.totalOrders}</h3>
            </Card.Body>
          </Card>
        </Col>
        <Col md={3}>
          <Card className="h-100">
            <Card.Body>
              <Card.Title>Toplam Gelir</Card.Title>
              <h3>₺{stats.totalRevenue.toLocaleString()}</h3>
            </Card.Body>
          </Card>
        </Col>
      </Row>

      {/* Grafikler */}
      <Row className="mb-4">
        <Col md={8}>
          <Card>
            <Card.Body>
              <Card.Title>Aylık Satış Grafiği</Card.Title>
              <Line data={salesData} />
            </Card.Body>
          </Card>
        </Col>
        <Col md={4}>
          <Card>
            <Card.Body>
              <Card.Title>Kategori Dağılımı</Card.Title>
              <Bar data={categoryData} />
            </Card.Body>
          </Card>
        </Col>
      </Row>

      {/* Tablolar */}
      <Row>
        <Col md={6}>
          <Card>
            <Card.Body>
              <Card.Title>Son Siparişler</Card.Title>
              <Table striped hover>
                <thead>
                  <tr>
                    <th>Müşteri</th>
                    <th>Tutar</th>
                    <th>Durum</th>
                    <th>Tarih</th>
                  </tr>
                </thead>
                <tbody>
                  {stats.recentOrders.map((order) => (
                    <tr key={order.id}>
                      <td>{order.customer}</td>
                      <td>₺{order.amount}</td>
                      <td>{order.status}</td>
                      <td>{order.date}</td>
                    </tr>
                  ))}
                </tbody>
              </Table>
            </Card.Body>
          </Card>
        </Col>
        <Col md={6}>
          <Card>
            <Card.Body>
              <Card.Title>En Çok Satan Ürünler</Card.Title>
              <Table striped hover>
                <thead>
                  <tr>
                    <th>Ürün</th>
                    <th>Satış Adedi</th>
                    <th>Gelir</th>
                  </tr>
                </thead>
                <tbody>
                  {stats.topProducts.map((product, index) => (
                    <tr key={index}>
                      <td>{product.name}</td>
                      <td>{product.sales}</td>
                      <td>₺{product.revenue.toLocaleString()}</td>
                    </tr>
                  ))}
                </tbody>
              </Table>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default Dashboard;
