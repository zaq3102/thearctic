import * as React from "react";
import { Route, Routes } from "react-router-dom";
import Game from "../Components/Game";
import Notice from "../Components/Notice";
import Leaderboard from "../Components/Leaderboard";
import Notice1 from "../Components/Notice1";
import NoticeDetail from "../Components/NoticeDetail";

export default function All() {
  return (
    <Routes>
      <Route path="game" element={<Game />} />
      <Route path="notice" element={<Notice />} />
      <Route path="leaderboard" element={<Leaderboard />} />
      <Route path="test" element={<Notice1 />} />
      <Route path="notice/:idx" element={<NoticeDetail />} />
    </Routes>
  );
}
