import './App.css';
import React, { useEffect, useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";
import FullScreen from './fullscreen.png';
import Loading from './Loading.gif';


export default function App() {
  const [LoadingStyle, setLoadingStyle] = useState({ display: 'block' });
  const [UnityStyle, setUnityStyle] = useState({ display: 'none' });


  const { unityProvider, isLoaded, requestFullscreen, loadingProgression } = useUnityContext({
    loaderUrl: "Build/build.loader.js",
    dataUrl: "Build/build.data",
    frameworkUrl: "Build/build.framework.js",
    codeUrl: "Build/build.wasm",
  });

  useEffect(() => {
    if (isLoaded) {
      let timer = setTimeout(() => {
        setLoadingStyle({ display: 'none' });
        setUnityStyle({ display: 'block' });
      }, 3000);
      return () => { clearTimeout(timer); }
    }
  }, [isLoaded]);

  return (
    <div>
      <div style={LoadingStyle}><LoadingComponent loadingProgression={loadingProgression} /></div>
      <div style={UnityStyle}> <UnityComponent unityProvider={unityProvider} requestFullscreen={requestFullscreen} /></div>
    </div>
  );
};

function LoadingComponent(props) {
  return (
    <div className="arrange-center">
      <img src={Loading} style={{ width: '80vw', height: '45vw', marginBottom: '1vh' }}></img>
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
        style={{
          width: '80vw',
          height: '45vw',
        }}
        unityProvider={props.unityProvider} />
      <button className="arrange-fullscreen" onClick={handleClickEnterFullscreen}><img src={FullScreen} style={{ padding: '1vw', width: '5vw' }}></img></button>
    </div>
  );
};
