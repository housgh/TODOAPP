import React, {useEffect} from 'react';
import './App.css';
import {authService} from "./services/auth-service";
import {Routes, Route, BrowserRouter} from "react-router-dom"
import {Home} from "./views/home";
import {Login} from "./views/login";
import axios from "axios";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path={"/"} element={<Home/>}/>
          <Route path={"/home"} element={<Home/>}/>
          <Route path={"/login"} element={<Login/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
