import * as React from 'react';
import { Outlet } from 'react-router-dom';
import Header from './Layout/Header';
import Footer from './Layout/Footer';

export default function Main() {
  return (
    <div>
      <Header />
      <main style={{ marginTop: 90 }}>
        <Outlet />
      </main>
      <Footer />
    </div>
  );
};