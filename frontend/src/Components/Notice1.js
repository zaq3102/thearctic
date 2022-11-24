import React from "react";

export default function Notice1(props) {
  const changePage = () => {
    if (props.isLoaded) {
      props.clickedGame();
    } else {
      props.clickedLoading();
    }
  };

  return (
    <div className="notice">
      <h1 className="mb-4 text-4xl font-extrabold tracking-tight leading-none text-gray-900 md:text-5xl lg:text-6xl dark:text-white text-center">
        공지사항
      </h1>
      <button
        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded game-button"
        onClick={changePage}
      >
        게임 하러가기
      </button>
      <div className="notice-content">
        <p className="mb-6 text-lg font-normal text-black-500 lg:text-xl sm:px-16 xl:px-48 dark:text-black-400">
          새로운 기능 및 버그 수정 내용이 업로드될 예정입니다.
        </p>
        <div className="version sm:px-16 xl:px-48">
          <p className="mb-6 text-base font-normal text-black-500 lg:text-base dark:text-black-400">
            버전 0.1.0
          </p>
          <ul class="space-y-1 list-disc list-inside text-gray-500 dark:text-gray-400">
            <li>
              낚시 게임의 물고기 획득 확률 조정 및 UI의 개선이 이루어졌습니다.
            </li>
            <li>
              Space Bar 버튼을 통해 영상을 Skip할 수 있는 기능이 추가되었습니다.
            </li>
            <li>퀘스트 안내 UI가 추가되었습니다.</li>
            <li>게임 UI 설명이 추가되었습니다.</li>
            <li>
              스피드런 예시 영상
              <video className="first-video" width="480" height="255" controls>
                <source
                  src="https://s3.us-west-2.amazonaws.com/secure.notion-static.com/b8902982-f26c-400a-872f-9b617f54f6e3/%EC%B5%9C%EA%B3%A0%EA%B8%B0%EB%A1%9D.mp4?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=AKIAT73L2G45EIPT3X45%2F20221121%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20221121T072831Z&X-Amz-Expires=86400&X-Amz-Signature=6cfaa0e1edbb6f4059c29536dbae3fb6bb21e0ba7a92c9ee7669bf117b8a40e2&X-Amz-SignedHeaders=host&response-content-disposition=filename%3D%22%25EC%25B5%259C%25EA%25B3%25A0%25EA%25B8%25B0%25EB%25A1%259D.mp4%22&x-id=GetObject"
                  type="video/mp4"
                />
              </video>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
}
