import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Navbar from './components/Navbar';
import Card from './components/Card';
import SubmitForm from './forms/SubmitForm';

function App() {
  return (
    <div>
      <Navbar/>
      <SubmitForm/>
      <Card/>
    </div>
  );
}

export default App;
