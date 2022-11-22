import * as React from 'react';
import ArcticMain from '../Assets/ArcticMain.png';

export default function Home() {
  return (
    <div>
      <img className="arctic-main" src={ArcticMain} alt="arctic-main" style={{ height: 590 }} />
      {/* <img className="arctic-main" src={ArcticMain} alt="arctic-main" style={{ height: 500 }} /> */}
      컨텐츠
    </div>
  );
};
