package com.ssafy.thearctic.api.controller;

import com.ssafy.thearctic.api.service.GameDataService;
import com.ssafy.thearctic.common.model.response.BaseResponseBody;
import com.ssafy.thearctic.db.entity.GameData;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.context.request.RequestContextHolder;
import org.springframework.web.context.request.ServletRequestAttributes;

import javax.servlet.http.HttpServletRequest;

@RestController
@RequestMapping("/gamedata")
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class GameDataController {
    @Autowired
    private GameDataService gameDataService;

    @PostMapping(value="/save")
    public ResponseEntity<?> saveData(@RequestBody GameData gameData) {
        try {
            HttpServletRequest request = ((ServletRequestAttributes) RequestContextHolder.currentRequestAttributes()).getRequest();
            gameDataService.save(request, gameData);
            return ResponseEntity.status(200).body(BaseResponseBody.of(200, "Success"));
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return ResponseEntity.status(500).body(
                    BaseResponseBody.of(500, "게임 데이터 저장 실패")
            );
        }
    }

    @GetMapping("/load")
    public ResponseEntity<?> loadData() {
        try {
            HttpServletRequest request = ((ServletRequestAttributes) RequestContextHolder.currentRequestAttributes()).getRequest();
            GameData gameData = gameDataService.load(request);
            return ResponseEntity.status(200).body(gameData);
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return ResponseEntity.status(500).body(
                    BaseResponseBody.of(500, "게임 데이터 로드 실패")
            );
        }
    }
}
