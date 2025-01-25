import React, { useState } from 'react';
import { Container, Form, Button, Card, Row, Col, Alert } from 'react-bootstrap';

interface Address {
  id?: number;
  title: string;
  fullName: string;
  addressLine: string;
  city: string;
  district: string;
  zipCode: string;
  phone: string;
}

interface CheckoutStepsProps {
  onComplete: (address: Address) => void;
  onCancel: () => void;
}

const CheckoutSteps: React.FC<CheckoutStepsProps> = ({ onComplete, onCancel }) => {
  const [step, setStep] = useState<'address' | 'payment'>('address');
  const [selectedAddress, setSelectedAddress] = useState<Address | null>(null);
  const [showAddNewAddress, setShowAddNewAddress] = useState(false);
  const [addresses] = useState<Address[]>([
    {
      id: 1,
      title: 'Ev',
      fullName: 'John Doe',
      addressLine: 'Sample Street No:1',
      city: 'Istanbul',
      district: 'Kadikoy',
      zipCode: '34700',
      phone: '5551234567'
    }
  ]);

  const [newAddress, setNewAddress] = useState<Address>({
    title: '',
    fullName: '',
    addressLine: '',
    city: '',
    district: '',
    zipCode: '',
    phone: ''
  });

  const handleAddressSelect = (address: Address) => {
    setSelectedAddress(address);
  };

  const handleNewAddressSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Burada normalde API'ye yeni adres kaydedilecek
    setShowAddNewAddress(false);
    setSelectedAddress(newAddress);
  };

  const handlePaymentSubmit = () => {
    if (selectedAddress) {
      onComplete(selectedAddress);
    }
  };

  const renderAddressStep = () => (
    <div>
      <h4 className="mb-4">Teslimat Adresi</h4>
      
      {!showAddNewAddress && (
        <>
          <Row className="mb-3">
            {addresses.map((address) => (
              <Col md={6} key={address.id} className="mb-3">
                <Card 
                  className={`h-100 ${selectedAddress?.id === address.id ? 'border-primary' : ''}`}
                  onClick={() => handleAddressSelect(address)}
                  style={{ cursor: 'pointer' }}
                >
                  <Card.Body>
                    <Card.Title>{address.title}</Card.Title>
                    <Card.Text>
                      {address.fullName}<br />
                      {address.addressLine}<br />
                      {address.district} / {address.city}<br />
                      {address.phone}
                    </Card.Text>
                  </Card.Body>
                </Card>
              </Col>
            ))}
          </Row>
          <Button 
            variant="outline-primary" 
            onClick={() => setShowAddNewAddress(true)}
            className="mb-3"
          >
            + Yeni Adres Ekle
          </Button>
        </>
      )}

      {showAddNewAddress && (
        <Form onSubmit={handleNewAddressSubmit}>
          <Row>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>Adres Başlığı</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.title}
                  onChange={(e) => setNewAddress({...newAddress, title: e.target.value})}
                  required
                />
              </Form.Group>
            </Col>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>Ad Soyad</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.fullName}
                  onChange={(e) => setNewAddress({...newAddress, fullName: e.target.value})}
                  required
                />
              </Form.Group>
            </Col>
          </Row>

          <Form.Group className="mb-3">
            <Form.Label>Adres</Form.Label>
            <Form.Control
              as="textarea"
              rows={3}
              value={newAddress.addressLine}
              onChange={(e) => setNewAddress({...newAddress, addressLine: e.target.value})}
              required
            />
          </Form.Group>

          <Row>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>İl</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.city}
                  onChange={(e) => setNewAddress({...newAddress, city: e.target.value})}
                  required
                />
              </Form.Group>
            </Col>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>İlçe</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.district}
                  onChange={(e) => setNewAddress({...newAddress, district: e.target.value})}
                  required
                />
              </Form.Group>
            </Col>
          </Row>

          <Row>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>Posta Kodu</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.zipCode}
                  onChange={(e) => setNewAddress({...newAddress, zipCode: e.target.value})}
                  required
                />
              </Form.Group>
            </Col>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>Telefon</Form.Label>
                <Form.Control
                  type="tel"
                  value={newAddress.phone}
                  onChange={(e) => setNewAddress({...newAddress, phone: e.target.value})}
                  required
                />
              </Form.Group>
            </Col>
          </Row>

          <div className="d-flex gap-2">
            <Button variant="primary" type="submit">
              Kaydet
            </Button>
            <Button variant="secondary" onClick={() => setShowAddNewAddress(false)}>
              İptal
            </Button>
          </div>
        </Form>
      )}

      {!showAddNewAddress && (
        <div className="mt-3">
          <Button
            variant="primary"
            onClick={() => setStep('payment')}
            disabled={!selectedAddress}
            className="me-2"
          >
            Ödemeye Geç
          </Button>
          <Button variant="secondary" onClick={onCancel}>
            İptal
          </Button>
        </div>
      )}
    </div>
  );

  const renderPaymentStep = () => (
    <div>
      <h4 className="mb-4">Ödeme Bilgileri</h4>
      <Alert variant="info">
        Test amaçlı olarak ödeme entegrasyonu atlanacaktır.
      </Alert>
      <div className="mt-3">
        <Button variant="primary" onClick={handlePaymentSubmit} className="me-2">
          Siparişi Tamamla
        </Button>
        <Button variant="secondary" onClick={() => setStep('address')}>
          Geri Dön
        </Button>
      </div>
    </div>
  );

  return (
    <Container>
      {step === 'address' ? renderAddressStep() : renderPaymentStep()}
    </Container>
  );
};

export default CheckoutSteps;
