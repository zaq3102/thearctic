import * as React from "react";
import "../../Styles/Layout.css";

export default function Footer() {
  return (
    <footer className="p-4 bg-white rounded-lg shadow md:flex md:items-center md:justify-between md:p-6 dark:bg-gray-800 w-full">
      <span className="text-sm text-gray-500 sm:text-center dark:text-gray-400">
        © SSAFY{" "}
        <span>
          A607™
        </span>
        . All Rights Reserved.
      </span>
      <ul className="flex flex-wrap items-center mt-3 text-sm text-gray-500 dark:text-gray-400 sm:mt-0">
        <li>
          <div className="mr-4 md:mr-6 ">
            About
          </div>
        </li>
        <li>
          <div className="mr-4 md:mr-6">
            Privacy Policy
          </div>
        </li>
        <li>
          <div className="mr-4 md:mr-6 ">
            Licensing
          </div>
        </li>
        <li>
          <div>
            Contact
          </div>
        </li>
      </ul>
    </footer>
  );
}
