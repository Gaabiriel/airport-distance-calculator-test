import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import './App.css';

import logo from "./logo.png";
import SearchAirport from './components/search-airport.component';

function App() {
  return (
    <Router>
      <div className="container">

        <nav className="navbar navbar-expand-lg navbar-light bg-light">
          <a className="navbar-brand" href="#">
            <img src={logo} width="30" height="30" />
          </a>

          <Link to="/" className="navbar-brand">Airport Distance Calculator</Link>

          <div className="collapse navbar-collapse">
            <ul className="navbar-nav mr-auto">
              <li className="navbar-item">
                <Link to="/" className="nav-link">Search Airport</Link>
              </li>
            </ul>
          </div>
        </nav>

        <Route path="/" exact component={SearchAirport} />
      </div>

    </Router>
  );
}

export default App;