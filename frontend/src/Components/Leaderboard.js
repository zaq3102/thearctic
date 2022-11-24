import React, { useState, useEffect } from "react";
import axios from "axios";
import me from "../Assets/me.png";
import trophy1 from "../Assets/trophy1.png";
import trophy2 from "../Assets/trophy2.png";
import trophy3 from "../Assets/trophy3.png";

export default function LeaderBoard(props) {
  const [rankingList, setRankingList] = useState([]);
  const [myRank, setMyRank] = useState([false, false, false]);
  const [rankingListTop3, setRankingListTop3] = useState([]);

  const getRankings = async () => {
    try {
      const response = await axios.get("https://thearctic.site:8081/rank");
      const rankings = response.data;
      let isMe = [];
      for (let i = 0; i < rankings.length; i++) {
        if (rankings[i].me) {
          isMe.push(true);
        } else {
          isMe.push(false);
        }
      }
      setMyRank(isMe);
      setRankingListTop3(rankings.slice(0, 3));
      setRankingList(rankings.slice(3, rankings.length));
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    getRankings();
  }, []);

  return (
    <div className="leaderboard-page">
      <div className="ranking-page-top">
        {/* <h1 className="mb-4 text-3xl font-extrabold text-gray-900 dark:text-white md:text-5xl lg:text-5xl">
          <span className="text-transparent bg-clip-text bg-gradient-to-r to-emerald-600 from-sky-400 ">
            명예의 전당
          </span>
        </h1> */}
        <h1 className="mb-10 text-3xl font-extrabold text-gray-900 dark:text-black md:text-5xl lg:text-4xl">
          명예의 전당
        </h1>
      </div>
      <div className="ranking-top-3">
        <div className="second">
          {myRank[1] ? <img className="me-icon" src={me} alt="me" /> : <></>}
          <div className="text-xl">{rankingListTop3[1]?.nickName}</div>
          <div className="text-base">{rankingListTop3[1]?.time}</div>
          <img className="trophy2" src={trophy2} alt="trophy-second" />
        </div>
        <div className="first">
          {myRank[0] ? <img className="me-icon" src={me} alt="me" /> : <></>}
          <div className="text-xl ranking-name">
            {rankingListTop3[0]?.nickName}
          </div>
          <div className="text-base">{rankingListTop3[0]?.time}</div>
          <img className="trophy1" src={trophy1} alt="trophy-first" />
        </div>
        <div className="third">
          {myRank[2] ? <img className="me-icon" src={me} alt="me" /> : <></>}
          <div className="text-xl">{rankingListTop3[2]?.nickName}</div>
          <div className="text-base">{rankingListTop3[2]?.time}</div>
          <img className="trophy3" src={trophy3} alt="trophy-third" />
        </div>
      </div>
      <div className="leaderboard">
        {rankingList.map((rank, idx) => (
          <li className={`${rank.me ? "is-me" : ""} ranking-list`} key={idx}>
            <div className="pl-10 text-l">{idx + 4}등</div>
            <div className="text-lg ranking-name">{rank.nickName}</div>{" "}
            <div className="pr-10 text-m">{rank.time}</div>
          </li>
        ))}
      </div>
    </div>
  );
}
