import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

export default function NoticeDetail(props) {
  const { idx } = useParams();
  const [noticeList, setNoticeList] = useState([
    {
      title: "스피드런 예시 영상",
      content:
        "<div class='flex justify-center'> <video class='first-video' width='680' height='455' controls><source src='https://s3.us-west-2.amazonaws.com/secure.notion-static.com/b8902982-f26c-400a-872f-9b617f54f6e3/%EC%B5%9C%EA%B3%A0%EA%B8%B0%EB%A1%9D.mp4?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=AKIAT73L2G45EIPT3X45%2F20221121%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20221121T072831Z&X-Amz-Expires=86400&X-Amz-Signature=6cfaa0e1edbb6f4059c29536dbae3fb6bb21e0ba7a92c9ee7669bf117b8a40e2&X-Amz-SignedHeaders=host&response-content-disposition=filename%3D%22%25EC%25B5%259C%25EA%25B3%25A0%25EA%25B8%25B0%25EB%25A1%259D.mp4%22&x-id=GetObject' type='video/mp4'/></video> </div>",
    },
    {
      title: "2022년 11월 21일 릴리즈 공지",
      content:
        "<p class='mb-6 text-lg font-normal text-black-500 lg:text-base dark:text-black-400'>v 1.1.0</p><ul class='text-sm space-y-1 list-disc list-inside text-gray-500 dark:text-gray-400'><li>낚시 게임의 물고기 획득 확률 조정 및 UI의 개선이 이루어졌습니다.</li><li>Space Bar 버튼을 통해 영상을 Skip할 수 있는 기능이 추가되었습니다.</li><li>퀘스트 안내 UI가 추가되었습니다.</li><li>게임 UI 설명이 추가되었습니다.</li><li>스피드런 예시 영상</li></ul>",
    },
    {
      title: "2022년 11월 22일 릴리즈 공지",
      content:
        "<p class='mb-6 text-lg font-normal text-black-500 lg:text-base dark:text-black-400'>v 1.2.0</p><ul class='text-sm space-y-1 list-disc list-inside text-gray-500 dark:text-gray-400'><li>경비곰의 속도를 2배로 높여 긴장감과 게임성을 높였습니다.</li></ul>",
    },
  ]);

  return (
    // <div>
    //   {idx === 1 ? <div>
    //     공지1
    //   </div> : <div>공지2</div>}
    // </div>

    <div className="leaderboard-page">
      <h1 className="mb-10 text-3xl font-extrabold text-gray-900 dark:text-white md:text-5xl lg:text-4xl">
        공지사항
      </h1>
      <div className="leaderboard max-w-full">
        <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
          <thead className="text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="py-5 px-6 text-base">
                {noticeList[idx].title}
              </th>
            </tr>
          </thead>
          <tbody>
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
              <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                <div
                  dangerouslySetInnerHTML={{
                    __html: noticeList[idx].content,
                  }}
                />
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
}
