import * as React from "react";
import { Outlet } from "react-router-dom";
import Header from "./Layout/Header";
import Footer from "./Layout/Footer";

export default function Main() {
  return (
    <div className="wrapper ">
      <div className="contentWrapper">
        <Header />
        <main style={{ marginTop: 70 }}>
          <Outlet />
        </main>
      </div>
      <Footer />
    </div>
  );
}
