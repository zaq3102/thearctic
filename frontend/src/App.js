import './App.css';
import React, { useEffect, useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";
import FullScreen from './fullscreen.png';
import Loading from './Loading.gif';
import LeaderBoard from './LeaderBoard';


export default function App() {
  const [LoadingStyle, setLoadingStyle] = useState({ display: 'block' });
  const [UnityStyle, setUnityStyle] = useState({ display: 'none' });
  const [RankingStyle, setRankingStyle] = useState({ display: 'none' });


  const { unityProvider, isLoaded, requestFullscreen, loadingProgression } = useUnityContext({
    loaderUrl: "Build/TheArcticBuild.loader.js",
    dataUrl: "Build/TheArcticBuild.data",
    frameworkUrl: "Build/TheArcticBuild.framework.js",
    codeUrl: "Build/TheArcticBuild.wasm",
  });

  useEffect(() => {
    if (isLoaded) {
      let timer = setTimeout(() => {
        setRankingStyle({ display: 'none' });
        setLoadingStyle({ display: 'none' });
        setUnityStyle({ display: 'block' });
      }, 3000);
      return () => { clearTimeout(timer); }
    }
  }, [isLoaded]);

  const clickedLeaderBoard = () => {
    setLoadingStyle({ display: 'none' });
    setUnityStyle({ display: 'none' });
    setRankingStyle({ display: 'block' });
  }

  const clickedGame = () => {
    setLoadingStyle({ display: 'none' });
    setUnityStyle({ display: 'block' });
    setRankingStyle({ display: 'none' });
  }

  const clickedLoading = () => {
    setLoadingStyle({ display: 'block' });
    setUnityStyle({ display: 'none' });
    setRankingStyle({ display: 'none' });
  }

  return (
    <div>
      <div style={LoadingStyle}><LoadingComponent loadingProgression={loadingProgression} clicked={clickedLeaderBoard} /></div>
      <div style={UnityStyle}> <UnityComponent unityProvider={unityProvider} requestFullscreen={requestFullscreen} clicked={clickedLeaderBoard} /></div>
      <div style={RankingStyle}><LeaderBoard clickedGame={clickedGame} clickedLoading={clickedLoading} isLoaded={isLoaded} /></div>
    </div>
  );
};

function LoadingComponent(props) {
  return (
    <div className="arrange-center">
      <img src={Loading} alt="loading-gif" style={{ width: '80vw', height: '45vw', marginBottom: '1vh' }}></img>
      <div className="bg-gray-600 rounded-full" style={{ width: '50vw', marginBottom: '1vh' }}>
        <div className="bg-blue-600 text-xl font-medium text-blue-100 text-center p-0.5 leading-none rounded-full" style={{ width: Math.round(props.loadingProgression * 50) + 'vw' }}>{Math.round(props.loadingProgression * 100)}%</div>
      </div>
      <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={props.clicked}>
        랭킹 보러가기
      </button>
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
        style={{
          width: '80vw',
          height: '45vw',
        }}
        unityProvider={props.unityProvider} />
      <div className='arrange-buttons'>
        <div className='arrange-buttons-left'>
          <button className="ranking bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={props.clicked}>
            랭킹 보러가기
          </button>
          <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={() => window.open('https://forms.gle/c6btR3qxQQwZqgMJA')}>
            피드백 보내기
          </button>
        </div>
        <button onClick={handleClickEnterFullscreen}><img src={FullScreen} style={{ width: '3vw' }}></img></button>
      </div>
    </div>
  );
};
