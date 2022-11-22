import '../Styles/App.css';
import React, { useEffect, useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";
import FullScreen from '../Assets/fullscreen.png';
import Loading from '../Assets/Loading.gif';
import Leaderboard from './Leaderboard';
import Notice from '../Components/Notice';


export default function Game() {
  const [LoadingStyle, setLoadingStyle] = useState({ display: 'block' });
  const [UnityStyle, setUnityStyle] = useState({ display: 'none' });
  const [RankingStyle, setRankingStyle] = useState({ display: 'none' });
  const [NoticeStyle, setNoticeStyle] = useState({ display: 'none' });


  const { unityProvider, isLoaded, requestFullscreen, loadingProgression } = useUnityContext({
    loaderUrl: "Build/TheArcticUpgrade1.loader.js",
    dataUrl: "Build/TheArcticUpgrade1.data",
    frameworkUrl: "Build/TheArcticUpgrade1.framework.js",
    codeUrl: "Build/TheArcticUpgrade1.wasm",
  });

  useEffect(() => {
    if (isLoaded) {
      let timer = setTimeout(() => {
        setRankingStyle({ display: 'none' });
        setLoadingStyle({ display: 'none' });
        setUnityStyle({ display: 'block' });
        setNoticeStyle({ display: 'none' });
      }, 3000);
      return () => { clearTimeout(timer); }
    }
  }, [isLoaded]);

  const clickedLeaderBoard = () => {
    setLoadingStyle({ display: 'none' });
    setUnityStyle({ display: 'none' });
    setRankingStyle({ display: 'block' });
    setNoticeStyle({ display: 'none' });
  }

  const clickedGame = () => {
    setLoadingStyle({ display: 'none' });
    setUnityStyle({ display: 'block' });
    setRankingStyle({ display: 'none' });
    setNoticeStyle({ display: 'none' });
  }

  const clickedLoading = () => {
    setLoadingStyle({ display: 'block' });
    setUnityStyle({ display: 'none' });
    setRankingStyle({ display: 'none' });
    setNoticeStyle({ display: 'none' });
  }

  const clickedNotice = () => {
    setLoadingStyle({ display: 'none' });
    setUnityStyle({ display: 'none' });
    setRankingStyle({ display: 'none' });
    setNoticeStyle({ display: 'block' });
  }

  return (
    <div>
      <div style={LoadingStyle}><LoadingComponent loadingProgression={loadingProgression} RankingClicked={clickedLeaderBoard} NoticeClicked={clickedNotice} /></div>
      <div style={UnityStyle}> <UnityComponent unityProvider={unityProvider} requestFullscreen={requestFullscreen} RankingClicked={clickedLeaderBoard} NoticeClicked={clickedNotice} /></div>
      <div style={RankingStyle}><Leaderboard clickedGame={clickedGame} clickedLoading={clickedLoading} isLoaded={isLoaded} /></div>
      <div style={NoticeStyle}><Notice clickedGame={clickedGame} clickedLoading={clickedLoading} isLoaded={isLoaded} /></div>
    </div>
  );
};

function LoadingComponent(props) {
  return (
    <div className="arrange-center">
      <img src={Loading} alt="loading-gif" style={{ width: 800, height: 450, marginBottom: '1vh' }}></img>
      <div className="bg-gray-600 rounded-full" style={{ width: '50vw' }}>
        <div className="bg-blue-600 text-xl font-medium text-blue-100 text-center p-0.5 leading-none rounded-full" style={{ width: Math.round(props.loadingProgression * 50) + 'vw' }}>{Math.round(props.loadingProgression * 100)}%</div>
      </div>
    </div >
  );
};

function UnityComponent(props) {
  const handleClickEnterFullscreen = () => {
    props.requestFullscreen(true);
  }
  return (
    <div className="arrange-center">
      <Unity
        style={{ width: 1000, height: 562.50 }}
        unityProvider={props.unityProvider} />
      <div className='arrange-buttons'>
        <button onClick={handleClickEnterFullscreen}><img src={FullScreen} style={{ width: '3vw' }}></img></button>
      </div>
    </div>
  );
};
