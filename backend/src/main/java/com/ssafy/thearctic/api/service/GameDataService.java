package com.ssafy.thearctic.api.service;

import com.ssafy.thearctic.common.model.response.util.GetIp;
import com.ssafy.thearctic.db.entity.GameData;
import com.ssafy.thearctic.db.entity.GameDataRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.servlet.http.HttpServletRequest;
import java.net.InetAddress;
import java.net.UnknownHostException;

@Service
public class GameDataService {

    @Autowired
    private GameDataRepository gameDataRepository;

    private GetIp getIp;

    public void save(HttpServletRequest request, GameData gameData){
        gameData.id = getIp.getClientIp(request);
//        gameData.id = getIp.getLocalMacAddress();
        gameDataRepository.save(gameData);
    }

    public GameData load(HttpServletRequest request){
        System.out.println(getIp.getClientIp(request));
        return gameDataRepository.findById(getIp.getClientIp(request)).orElse(null);
//        System.out.println(getIp.getLocalMacAddress());
//        return gameDataRepository.findById(getIp.getLocalMacAddress()).orElse(null);
    }

}
