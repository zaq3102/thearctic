import * as React from 'react';
import { Link } from 'react-router-dom';
import logo from '../../Assets/thearctic_logo.png';
import '../../Styles/Layout.css';

export default function Header() {
  return (
    <header>
      <nav className="bg-white px-2 sm:px-4 py-2.5 dark:bg-gray-900 fixed w-full z-20 top-0 left-0 border-b border-gray-200 dark:border-gray-600">
        <div className="container flex items-center justify-between mx-auto">
          <Link to="/" className="flex items-center">
            <img src={logo} className="mr-3 h-10" alt="The Arctic Logo" />
            <span className="self-center text-xl font-semibold whitespace-nowrap dark:text-white">The Arctic</span>
          </Link>
          <div className="items-center justify-between w-full md:flex md:w-auto md:order-1" id="navbar-sticky">
            <ul className="flex p-4 mt-4 md:flex-row md:space-x-8 md:mt-0 md:text">
              <li>
                <Link to="game" className="block py-2 pr-4 pl-3 text-black-700">게임 플레이</Link>
              </li>
              <li>
                <Link to="leaderboard" className="block py-2 pr-4 pl-3 text-gray-700">명예의 전당</Link>
              </li>
              <li>
                <Link to="notice" className="block py-2 pr-4 pl-3 text-gray-700">공지사항</Link>
              </li>
              <li>

                <a href="https://forms.gle/c6btR3qxQQwZqgMJA" target='_blank' className="feadback block py-2 pr-4 pl-3 text-gray-700">피드백 보내기</a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </header>
  );
};