import './App.css';
import axios from 'axios'
import {
  Route,
  BrowserRouter,
  Routes,
} from "react-router-dom"
import React from 'react'
import Help from './components/Help';
import Clicker from './components/Clicker';

function App() {
  // const router = createBrowserRouter([
  //   {
  //     path: "/",
  //     element: <Clicker></Clicker>,
  //   },
  //   {
  //     path: "/Help/:smile",
  //     element: <Help></Help>,
  //   },
  // ]);

  axios.interceptors.request.use((config) => {
    config.headers.Authorization = 'smile'
    return config;
  });

  return (
    <React.StrictMode>
      <nav>
        <ul>
          <li>
            <a href={`/`}>Home</a>
          </li>
          <li>
            <a href={`/Help`}>Help null</a>
          </li>
          <li>
            <a href={`/Help/1`}>Help 1</a>
          </li>
        </ul>
      </nav>
      <BrowserRouter>
        <Routes>
          <Route path="/">
            <Route path="/" element={<Clicker />} />
            <Route path="/Help/:smile?" element={<Help />} />
          </Route>
        </Routes>
      </BrowserRouter>

    </React.StrictMode>
  );
}

export default App;
