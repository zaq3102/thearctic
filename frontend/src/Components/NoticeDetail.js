import React from "react";
import { useParams } from 'react-router-dom';

export default function NoticeDetail() {
  const { idx } = useParams();
  return (
    <div>
      {idx === 1 ? <div>
        공지1
      </div> : <div>공지2</div>}
    </div>
  )
}