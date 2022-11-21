import React, { useState, useEffect } from "react";
import axios from 'axios';
import me from './me.png';
import trophy1 from './trophy1.png';
import trophy2 from './trophy2.png';
import trophy3 from './trophy3.png';


export default function LeaderBoard(props) {
  const [rankingClicked, setRankingClicked] = useState(false);
  const [rankingList, setRankingList] = useState([]);
  const [myRank, setMyRank] = useState([false, false, false]);
  const [rankingListTop3, setRankingListTop3] = useState([{ nickName: '첫', time: '00:00:01' }, { nickName: '두', time: '00:00:02' }, { nickName: '셋', time: '00:00:03' }]);
  const [leftTime, setLeftTime] = useState(60);

  const getRankings = async () => {
    try {
      const response = await axios.get('https://thearctic.site:8081/rank');
      const rankings = response.data;
      let isMe = [];
      for (let i = 0; i < rankings.length; i++) {
        if (rankings[i].me) {
          isMe.push(true);
        }
        else {
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

  const rankingRefresh = () => {
    getRankings();
    setRankingClicked(true);
    let time = 60;
    let timer1 = setTimeout(() => {
      setRankingClicked(false);
      clearTimeout(timer1); clearInterval(timer2); setLeftTime(60);
    }, 60000);
    let timer2 = setInterval(() => {
      time -= 1;
      setLeftTime(time);
    }, 1000);
  }

  const changePage = () => {
    if (props.isLoaded) {
      props.clickedGame();
    }
    else {
      props.clickedLoading();
    }
  }

  return (
    <div className="leaderboard-page">
      <div className="ranking-page-top">
        <h1 className="mb-4 text-3xl font-extrabold text-gray-900 dark:text-white md:text-5xl lg:text-6xl"><span className="text-transparent bg-clip-text bg-gradient-to-r to-emerald-600 from-sky-400 ">Leaderboard</span></h1>
        <div className="ranking-buttons">
          <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded game-button" onClick={changePage}>
            게임 하러가기
          </button>
          {rankingClicked ?
            <button className="bg-blue-500 text-white font-bold py-2 px-4 rounded opacity-50 cursor-not-allowed refresh-button refresh-button-clicked">
              {leftTime}초
            </button> :
            <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded refresh-button" onClick={rankingRefresh}>
              새로고침
            </button>
          }
        </div>
      </div>
      <div className="ranking-top-3">
        <div className="second">
          {myRank[1] ?
            <img className="me-icon" src={me} alt="me" /> : <></>
          }
          <div className="text-2xl">{rankingListTop3[1].nickName}</div><div className="text-base">{rankingListTop3[1].time}</div>
          <img className="trophy2" src={trophy2} alt="trophy-second" />
        </div>
        <div className="first">
          {myRank[0] ?
            <img className="me-icon" src={me} alt="me" /> : <></>
          }
          <div className="text-2xl ranking-name">{rankingListTop3[0].nickName}</div><div className="text-base">{rankingListTop3[0].time}</div>
          <img className="trophy1" src={trophy1} alt="trophy-first" />
        </div>
        <div className="third">
          {myRank[2] ?
            <img className="me-icon" src={me} alt="me" /> : <></>
          }
          <div className="text-2xl">{rankingListTop3[2].nickName}</div><div className="text-base">{rankingListTop3[2].time}</div>
          <img className="trophy3" src={trophy3} alt="trophy-third" />
        </div>
      </div>
      <div className="leaderboard">
        {rankingList.map((rank, idx) => (
          <li className={`${rank.me ? "is-me" : ""} ranking-list`} key={idx}><div className="text-lg">{idx + 4}등</div><div className="text-2xl ranking-name">{rank.nickName}</div> <div>{rank.time}</div></li>
        ))}
      </div>
    </div>
  )
}
