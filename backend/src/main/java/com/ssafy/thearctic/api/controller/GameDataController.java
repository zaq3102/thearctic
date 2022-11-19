package com.ssafy.thearctic.api.controller;

import com.ssafy.thearctic.api.request.UserReq;
import com.ssafy.thearctic.api.response.UserRes;
import com.ssafy.thearctic.api.service.GameDataService;
import com.ssafy.thearctic.common.model.response.BaseResponseBody;
import com.ssafy.thearctic.db.entity.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/gamedata")
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class GameDataController {
    @Autowired
    private GameDataService gameDataService;

    @PostMapping(value="/save")
    public ResponseEntity<?> saveData(@RequestBody UserReq user) {
        try {
            System.out.println("called by unity!!!!");
//            System.out.println(user);
//            User user = new User("happy");
            System.out.println("user: " + user.getName() + ", " + user.getAge());
            gameDataService.save(user);
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
            User user = gameDataService.load();
            return ResponseEntity.status(200).body(UserRes.of(200, "Success", user));
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return ResponseEntity.status(500).body(
                    BaseResponseBody.of(500, "게임 데이터 로드 실패")
            );
        }
    }
}
