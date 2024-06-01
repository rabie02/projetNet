import React from "react";
import Products from "./products";
import Footer from './Footer';

const Home = () => {
  return (
  
    <div className="hero">
      <div className="card text-bg-dark border-0">
        <img src="\assets\back-home-1.png" className="card-img" alt="Background"  height="550px"/>
        <div className="card-img-overlay  d-flex flex-column justify-content-center">
            <div className="containre"></div>
          <h5 className="card-title display-3 fw-bolder mb-0">Nouvelle Arrivage</h5>
          <p className="card-text lead fs-2">
          Arrivage Frais - Parcourez nos Nouveautés

          </p>
        </div>
      </div>
      <Products/>
      <Footer/>
    </div>
  );
};

export default Home;
