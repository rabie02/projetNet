
import React, { useState, useEffect } from "react";
import { useDispatch } from 'react-redux';
import { addCart } from "../redux/action";
import { NavLink, useParams } from "react-router-dom";
import Skeleton from "react-loading-skeleton";

const Product = () => {
    const { id_product } = useParams();
    const [product, setProduct] = useState({});
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const dispatch = useDispatch();
  
    const addProduct = (product) => {
        dispatch(addCart(product));
      };

    
  
    useEffect(() => {
      const getProduct = async () => {
        try {
          setLoading(true);
          const response = await fetch(
            `https://localhost:44328/api/Product/${id_product}`
          );
  
          if (!response.ok) {
            throw new Error(`Error fetching product: ${response.statusText}`);
          }
  
          const data = await response.json();
          setProduct(data);
        } catch (error) {
          setError(error.message);
        } finally {
          setLoading(false);
        }
      };
  
      getProduct();
    }, [id_product]);

  const Loading = () => (
    <div>
      <div className="col-md-6">
        <Skeleton height={400} />
      </div>
      <div className="col-md-6" style={{ lineHeight: 2 }}>
        <Skeleton height={50} width={300} />
        <Skeleton height={75} />
        <Skeleton height={25} width={150} />
        <Skeleton height={50} />
        <Skeleton height={150} />
        <Skeleton height={50} width={100} />
        <Skeleton height={50} width={100} style={{ marginLeft: 6 }} />
      </div>
    </div>
  );

  const showError = () => <div>Error loading product: {error}</div>;

  const showProduct = () => (
    <div className="row">
      <div className="col-md-6">
        <img
          src={`/assets/${product.photo}`}
          alt={product.nom_produit}
          height="400px"
          width="400px"
        />
      </div>
      <div className="col-md-6">
        <h4 className="text-uppercase text-black-50">{product.category}</h4>
        <h1 className="display-5">{product.nom_produit}</h1>
        <p className="lead fw-bolder">
          Ratting {product.rating && product.rating.rate}
          <i className="fa fa-star"></i>
        </p>
        <h3 className="display-6 fw-bold my-4">$ {product.prix}</h3>
        <p className="lead">{product.description}</p>
        <button className="btn btn-outline-dark px-4 py-2" 
        onClick={() => addProduct(product)}
        >
          {" "}
          Add to Cart
        </button>
        <NavLink to="/cart" className="btn btn-dark ms-2 px-3 py-2">
          Go to Cart
        </NavLink>
      </div>
    </div>
  );

  return (
    <div className="container py-5">
      <div className="row py-4">
        {loading ? <Loading /> : error ? showError() : showProduct()}
      </div>
    </div>
  );
};

export default Product;