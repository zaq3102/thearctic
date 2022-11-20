package com.ssafy.thearctic.api.service;

import com.ssafy.thearctic.common.model.response.util.GetIp;
import com.ssafy.thearctic.db.entity.GameData;
import com.ssafy.thearctic.db.entity.GameDataRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.net.InetAddress;
import java.net.UnknownHostException;

@Service
public class GameDataService {

    @Autowired
    private GameDataRepository gameDataRepository;

    private GetIp getIp;

    public void save(GameData gameData){
        gameData.id = getIp.getServerIp();
        gameDataRepository.save(gameData);
    }

    public GameData load(){
        return gameDataRepository.findById(getIp.getServerIp()).orElse(null);
    }

}
