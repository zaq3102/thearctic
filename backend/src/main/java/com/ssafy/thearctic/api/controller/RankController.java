package com.ssafy.thearctic.api.controller;

import com.ssafy.thearctic.api.request.RankInfoReq;
import com.ssafy.thearctic.api.response.RankInfoRes;
import com.ssafy.thearctic.api.service.RankService;
import com.ssafy.thearctic.common.model.response.BaseResponseBody;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.context.request.RequestContextHolder;
import org.springframework.web.context.request.ServletRequestAttributes;

import javax.servlet.http.HttpServletRequest;
import java.util.List;

@RestController
@RequestMapping("/rank")
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class RankController {
    @Autowired
    private RankService rankService;

    @PostMapping(value="/add")
    public ResponseEntity<?> saveData(@RequestBody RankInfoReq rankInfoReq) {
        try {
            HttpServletRequest request = ((ServletRequestAttributes) RequestContextHolder.currentRequestAttributes()).getRequest();
            rankService.addRanking(request, rankInfoReq);
            return ResponseEntity.status(200).body(BaseResponseBody.of(200, "Success"));
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return ResponseEntity.status(500).body(
                    BaseResponseBody.of(500, "랭킹 등록 실패")
            );
        }
    }

    @GetMapping()
    public ResponseEntity<?> loadData() {
        try {
            HttpServletRequest request = ((ServletRequestAttributes) RequestContextHolder.currentRequestAttributes()).getRequest();
            List<RankInfoRes> rankInfoResList = rankService.getRanking(request);
            return ResponseEntity.status(200).body(rankInfoResList);
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return ResponseEntity.status(500).body(
                    BaseResponseBody.of(500, "게임 데이터 로드 실패")
            );
        }
    }
}
