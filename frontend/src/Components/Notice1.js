import React from "react";
import { Link } from "react-router-dom";


export default function Notice1() {



  return (
    <div className="relative" style={{ marginTop: 90, marginLeft: 40, marginRight: 40 }}>

      <h1 className="mb-4 text-3xl font-extrabold text-gray-900 dark:text-white md:text-5xl lg:text-6xl"><span className="text-transparent bg-clip-text bg-gradient-to-r to-emerald-600 from-sky-400 ">공지사항</span></h1>
      <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
        <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
          <tr>
            <th scope="col" className="py-3 px-6" style={{ width: '5vw' }}>
              No
            </th>
            <th scope="col" className="py-3 px-6">
              제목
            </th>
            <th scope="col" className="py-3 px-6">
              등록일
            </th>
          </tr>
        </thead>
        <tbody>
          <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
            <th scope="row" className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
              2
            </th>
            <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
              <Link to="2">
                2022년 11월 22일 릴리즈 공지
              </Link>
            </td>
            <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
              2022. 11. 22
            </td>
          </tr>
          <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
            <th scope="row" className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
              1
            </th>
            <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
              <Link to="1">
                2022년 11월 21일 릴리즈 공지
              </Link>
            </td>
            <td className="py-4 px-6 font-medium text-gray-900 whitespace-nowrap dark:text-white">
              2022. 11. 21
            </td>
          </tr>
        </tbody>
      </table>
    </div>)

}