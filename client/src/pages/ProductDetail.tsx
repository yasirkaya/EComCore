import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { productService } from '../services/product.service';
import { Product } from '../types/product';
import { Container, Row, Col, Image, Button } from 'react-bootstrap';

const ProductDetail: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [product, setProduct] = useState<Product | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchProduct = async () => {
            try {
                if (id) {
                    const data = await productService.getProductById(parseInt(id));
                    setProduct(data);
                }
            } catch (error) {
                console.error('Error fetching product:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchProduct();
    }, [id]);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (!product) {
        return <div>Product not found</div>;
    }

    return (
        <Container className="py-5">
            <Row>
                <Col md={6}>
                    <Image src={product.imageUrl} alt={product.name} fluid />
                </Col>
                <Col md={6}>
                    <h1>{product.name}</h1>
                    <p className="text-muted">{product.categoryId}</p>
                    <h2 className="text-primary">${product.price}</h2>
                    <p>{product.description}</p>
                    <div className="d-grid gap-2">
                        <Button variant="primary" size="lg">
                            Add to Cart
                        </Button>
                    </div>
                </Col>
            </Row>
        </Container>
    );
};

export default ProductDetail;
