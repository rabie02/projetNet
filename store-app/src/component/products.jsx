import React, { useState, useEffect } from "react";
import Skeleton from "react-loading-skeleton";
import { NavLink } from "react-router-dom";

const Products = () => {
  const [data, setData] = useState([]);
  const [filter, setFilter] = useState([]);
  const [loading, setLoading] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState('All');

  useEffect(() => {
    let componentMounted = true;

    const fetchData = async () => {
      try {
        setLoading(true);
        const response = await fetch(`https://localhost:44328/api/Product?category=${selectedCategory}`);
        const result = await response.json();

        if (componentMounted) {
          setData(result);
          // Assurez-vous que result est un tableau avant de mettre à jour filter
          setFilter(Array.isArray(result) ? result : []);
          setLoading(false);
        }
      } catch (error) {
        console.error("Error fetching data:", error);
        setLoading(false);
      }
    };

    fetchData();

    return () => {
      componentMounted = false;
    };
  }, [selectedCategory]); // Ajoutez selectedCategory comme dépendance

  const filterProduct = (category) => {
    setSelectedCategory(category);
  };

  const LoadingComponent = () => {
    return (
      <>
        <div className="col-md-3">
          <Skeleton height={350}/>
        </div>
        <div className="col-md-3">
          <Skeleton height={350}/>
        </div>
        <div className="col-md-3">
          <Skeleton height={350}/>
        </div>
        <div className="col-md-3">
          <Skeleton height={350}/>
        </div>
      </>
    );
  };

  const showProduct = () => {
    return (
      <>
        <div className="buttons d-flex justify-content-center mb-5 pb-5">
          <div className="button btn btn-outline-dark me-2" onClick={() => setFilter(data)}>All</div>
          <div className="button btn btn-outline-dark me-2" onClick={() => filterProduct('Adults')}>Adults</div>
          <div className="button btn btn-outline-dark me-2" onClick={() => filterProduct('Enfants')}>Enfants</div>
          <div className="button btn btn-outline-dark me-2" onClick={() => filterProduct('Price')}>Price</div>
          <div className="button btn btn-outline-dark me-2" onClick={() => filterProduct('Type')}>Type</div>
        </div>
        {filter.map((product) => (
          <div key={product.id_product} className="col-md-3 mb-4">
            <div className="card h-100 text-center p-4 " key={product.id_product}>
              <img src={`/assets/${product.photo}`} className="card-img-top" alt={product.nom_produit} height="250px" />
              <div className="card-body">
                <h5 className="card-title mb-0">{product.nom_produit.substring(0, 12)}...</h5>
                <p className="card-text lead fw-bold">${product.prix}</p>
                <NavLink to={`/products/${product.id_product}`} className="btn btn-outline-dark" >
                  Buy Now
                </NavLink>
              </div>
            </div>
          </div>
        ))}
      </>
    );
  };

  return (
    <div>
      <div className="container my-5 py-5">
        <div className="row">
          <div className="col-12 mb-5">
            <h1 className="display-6 fw-bolder text-center">Latest Product</h1>
            <hr />
          </div>
        </div>
        <div className="row justify-content-center">
          {loading ? <LoadingComponent /> : showProduct()}
        </div>
      </div>
    </div>
  );
};


export default Products;
