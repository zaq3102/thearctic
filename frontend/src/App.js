import * as React from 'react';
import { Route, Routes } from 'react-router-dom';
import Home from './Components/Home';
import Main from './Components/Main';
import All from './Routes/All';

const App = () => {
  return (
    <Routes>
      <Route element={<Main />}>
        <Route index element={<Home />} />
        <Route path="/*" element={<All />} />
      </Route>
    </Routes>
  );
};

export default App;
