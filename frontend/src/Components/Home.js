import * as React from "react";
import { Link } from "react-router-dom";
import ArcticMain from "../Assets/3d_arctic.png";
import SadPolarBear from "../Assets/sad_polarbear.png";

export default function Home() {
  return (
    <div
      className="bg-gradient-to-b to-[#D2E1FF] from-white"
      style={{ minHeight: "85vh" }}
    >
      {/* <img className="arctic-main" src={ArcticMain} alt="arctic-main" style={{ height: 590 }} /> */}
      {/* <img className="arctic-main" src={ArcticMain} alt="arctic-main" style={{ height: 500 }} /> */}
      <div></div>
      <div className="pt-20 flex justify-center">
        <div className="container px-3 mx-auto flex flex-wrap flex-col md:flex-row items-center justify-center">
          {/* <div className="w-full md:w-1/10">s</div> */}
          <div className="flex flex-col w-full md:w-2/5 justify-center items-start text-center md:text-left">
            {/* <p className="uppercase tracking-loose w-full">
              What business are you?
            </p> */}
            <h1 className="my-4 text-4xl font-bold leading-tight">
              Play The Arctic, <br />
              Save The Arctic
            </h1>
            <p className="leading-normal text-l mb-8">
              멀게만 느껴지는 환경 문제, The Arctic을 플레이하고 함께
              해결해봐요!
            </p>
            {/* <button className="mx-auto lg:mx-0 hover:underline bg-white text-gray-800 font-bold my-6 py-4 px-8 border focus:outline-none focus:shadow-outline transform transition hover:scale-105 duration-300 ease-in-out">
              플레이
            </button> */}
            <div className="block py-1 pr-1 pl-1">
              <Link
                to="game"
                className="my-6 py-4 px-8 hover:scale-105 duration-300 ease-in-out inline-block text-m rounded-full text-white mt-4 lg:mt-0 bg-[#101B48]"
              >
                게임 플레이
              </Link>
            </div>
          </div>
          <div className="w-full md:w-2/5 py-6 text-center">
            <img className="w-full z-50 ml-10" src={SadPolarBear} />
          </div>
        </div>
      </div>
    </div>
  );
}
