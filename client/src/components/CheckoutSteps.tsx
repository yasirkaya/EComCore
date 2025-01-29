import React, { useEffect, useState } from "react";
import {
  Container,
  Form,
  Button,
  Card,
  Row,
  Col,
  Alert,
} from "react-bootstrap";
import { useSelector } from "react-redux";
import { addressService } from "services/address.service";
import { orderService } from "services/order.service";
import { RootState } from "store/store";
import { Address, CreateAddress } from "types/address";

// Removed duplicate Address interface

interface CheckoutStepsProps {
  onComplete: (address: Address) => void;
  onCancel: () => void;
}

const CheckoutSteps: React.FC<CheckoutStepsProps> = ({
  onComplete,
  onCancel,
}) => {
  const [step, setStep] = useState<"address" | "payment">("address");
  const [selectedAddress, setSelectedAddress] = useState<Address | null>(null);
  const [showAddNewAddress, setShowAddNewAddress] = useState(false);
  const [addresses, setAddresses] = useState<Address[]>([]);
  const { user } = useSelector((state: RootState) => state.auth);

  const cities = ["İstanbul", "Ankara", "İzmir", "Bursa", "Antalya"];
  const [newAddress, setNewAddress] = useState<CreateAddress>({
    name: "",
    addressLine1: "",
    addressLine2: "",
    city: "",
    postalCode: "",
    userId: parseInt(user?.id || "0"),
  });

  useEffect(() => {
    fetchAddresses();
  }, []);

  const fetchAddresses = async () => {
    if (user && user.id) {
      const data = await addressService.getAddressesByUserId(parseInt(user.id));
      setAddresses(data);
    }
  };

  const handleAddressSelect = (address: Address) => {
    setSelectedAddress(address);
  };

  const handleOrderCreate = async () => {
    if (selectedAddress) {
    }
  };

  const handleNewAddressSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await addressService.createAddress(newAddress);
    setShowAddNewAddress(false);
    fetchAddresses();
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
                  className={`h-100 ${
                    selectedAddress?.id === address.id ? "border-primary" : ""
                  }`}
                  onClick={() => handleAddressSelect(address)}
                  style={{ cursor: "pointer" }}
                >
                  <Card.Body>
                    <Card.Title>{address.name}</Card.Title>
                    <Card.Text>
                      {address.addressLine1}
                      <br />
                      {address.addressLine2}
                      <br />
                      {address.city}
                      <br />
                      {address.postalCode}
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
                <Form.Label>Ad Soyad</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.name}
                  onChange={(e) =>
                    setNewAddress({ ...newAddress, name: e.target.value })
                  }
                  required
                />
              </Form.Group>
            </Col>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>Adres Satırı 1</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.addressLine1}
                  onChange={(e) =>
                    setNewAddress({
                      ...newAddress,
                      addressLine1: e.target.value,
                    })
                  }
                  required
                />
              </Form.Group>
            </Col>
          </Row>

          <Form.Group className="mb-3">
            <Form.Label>Adres Satırı 2</Form.Label>
            <Form.Control
              as="textarea"
              rows={3}
              value={newAddress.addressLine2}
              onChange={(e) =>
                setNewAddress({ ...newAddress, addressLine2: e.target.value })
              }
              required
            />
          </Form.Group>

          <Row>
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>İl</Form.Label>
                <Form.Select
                  value={newAddress.city}
                  onChange={(e) =>
                    setNewAddress({ ...newAddress, city: e.target.value })
                  }
                  required
                >
                  <option value="">Şehir Seçiniz</option>
                  {cities.map((city, index) => (
                    <option key={index} value={city}>
                      {city}
                    </option>
                  ))}
                </Form.Select>
              </Form.Group>
            </Col>
            ;
            <Col md={6}>
              <Form.Group className="mb-3">
                <Form.Label>Posta Kodu</Form.Label>
                <Form.Control
                  type="text"
                  value={newAddress.postalCode}
                  onChange={(e) =>
                    setNewAddress({ ...newAddress, postalCode: e.target.value })
                  }
                  required
                />
              </Form.Group>
            </Col>
          </Row>

          <div className="d-flex gap-2">
            <Button variant="primary" type="submit">
              Kaydet
            </Button>
            <Button
              variant="secondary"
              onClick={() => setShowAddNewAddress(false)}
            >
              İptal
            </Button>
          </div>
        </Form>
      )}

      {!showAddNewAddress && (
        <div className="mt-3">
          <Button
            variant="primary"
            onClick={() => setStep("payment")}
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
        <Button
          variant="primary"
          onClick={handlePaymentSubmit}
          className="me-2"
        >
          Siparişi Tamamla
        </Button>
        <Button variant="secondary" onClick={() => setStep("address")}>
          Geri Dön
        </Button>
      </div>
    </div>
  );

  return (
    <Container>
      {step === "address" ? renderAddressStep() : renderPaymentStep()}
    </Container>
  );
};

export default CheckoutSteps;
