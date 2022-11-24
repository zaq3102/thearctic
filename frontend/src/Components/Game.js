import "../Styles/App.css";
import React, { useEffect, useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";
import FullScreen from "../Assets/fullscreen.png";
import Loading from "../Assets/Loading.gif";

export default function Game() {
  const [LoadingStyle, setLoadingStyle] = useState({ display: "block" });
  const [UnityStyle, setUnityStyle] = useState({ display: "none" });

  const { unityProvider, isLoaded, requestFullscreen, loadingProgression, UNSAFE__detachAndUnloadImmediate: detachAndUnloadImmediate } =
    useUnityContext({
      loaderUrl: "Build/TheArcticBuild.loader.js",
      dataUrl: "Build/TheArcticBuild.data",
      frameworkUrl: "Build/TheArcticBuild.framework.js",
      codeUrl: "Build/TheArcticBuild.wasm",
    });

  useEffect(() => {
    if (isLoaded) {
      let timer = setTimeout(() => {
        setLoadingStyle({ display: "none" });
        setUnityStyle({ display: "block" });
      }, 3000);
      return async () => {
        clearTimeout(timer);
        detachAndUnloadImmediate();
      };
    }
  }, [isLoaded]);

  return (
    <div>
      <div style={LoadingStyle}>
        <LoadingComponent
          loadingProgression={loadingProgression}
        />
      </div>
      <div style={UnityStyle}>
        {" "}
        <UnityComponent
          unityProvider={unityProvider}
          requestFullscreen={requestFullscreen}
        />
      </div>
    </div>
  );
}

function LoadingComponent(props) {
  return (
    <div className="arrange-center-game">
      <img
        src={Loading}
        alt="loading-gif"
        style={{ width: '120vh', height: '67.5vh', marginBottom: "1vh" }} />
      <div className="bg-gray-600 rounded-full" style={{ width: "50vw" }}>
        <div
          className="bg-[#101B48] text-xl font-medium text-blue-100 text-center p-0.5 leading-none rounded-full"
          style={{ width: Math.round(props.loadingProgression * 50) + "vw" }}
        >
          {Math.round(props.loadingProgression * 100)}%
        </div>
      </div>
    </div>
  );
}

function UnityComponent(props) {
  const handleClickEnterFullscreen = () => {
    props.requestFullscreen(true);
  };
  return (
    <div className="arrange-center-game">
      <Unity
        style={{ width: '120vh', height: '67.5vh' }}
        unityProvider={props.unityProvider}
      />
      <button onClick={handleClickEnterFullscreen} className="fullscreen-btn">
        <img src={FullScreen} style={{ width: "3vw" }} alt="fullscreen-button"></img>
      </button>
    </div>
  );
}
