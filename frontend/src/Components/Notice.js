import React from "react";
import { Link } from "react-router-dom";

export default function Notice() {
  return (
    <div className="leaderboard-page">
      {/* <h1 className="mb-4 text-3xl font-extrabold text-gray-900 dark:text-white md:text-5xl lg:text-5xl">
          <span className="text-transparent bg-clip-text bg-gradient-to-r to-emerald-600 from-sky-400 ">
            공지사항
          </span>
        </h1> */}
      <h1 className="mb-10 text-3xl font-extrabold text-gray-900 dark:text-white md:text-5xl lg:text-4xl">
        공지사항
      </h1>
      <div className="leaderboard max-w-full">
        <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
          <thead className="text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th
                scope="col"
                className="py-5 px-6 text-base"
                style={{ width: "5vw" }}
              >
                No
              </th>
              <th scope="col" className="py-3 px-6 text-base">
                제목
              </th>
              <th scope="col" className="py-3 px-6 text-base">
                등록일
              </th>
            </tr>
          </thead>
          <tbody>
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
              <th
                scope="row"
                className="py-4 px-6 font-medium text-blue-800 whitespace-nowrap dark:text-white"
              >
                참고
              </th>
              <td className="py-4 px-6 font-medium text-blue-800 whitespace-nowrap dark:text-white">
                <Link to="0">The Arctic 홍보 영상</Link>
              </td>
              <td className="py-4 px-6 font-medium text-blue-800 whitespace-nowrap dark:text-white">
                2022. 11. 21
              </td>
            </tr>
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
              <th
                scope="row"
                className="py-4 px-6 font-medium text-blue-800 whitespace-nowrap dark:text-white"
              >
                참고
              </th>
              <td className="py-4 px-6 font-medium text-blue-800 whitespace-nowrap dark:text-white">
                <Link to="1">스피드런 예시 영상</Link>
              </td>
              <td className="py-4 px-6 font-medium text-blue-800 whitespace-nowrap dark:text-white">
                2022. 11. 21
              </td>
            </tr>
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
              <th
                scope="row"
                className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white"
              >
                2
              </th>
              <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                <Link to="3">2022년 11월 22일 릴리즈 공지</Link>
              </td>
              <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                2022. 11. 22
              </td>
            </tr>
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
              <th
                scope="row"
                className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white"
              >
                1
              </th>
              <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                <Link to="2">2022년 11월 21일 릴리즈 공지</Link>
              </td>
              <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                2022. 11. 21
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
}
