package com.ssafy.thearctic.api.service;

import com.ssafy.thearctic.api.request.RankInfoReq;
import com.ssafy.thearctic.api.response.RankInfoRes;
import com.ssafy.thearctic.common.model.response.util.GetIp;
import com.ssafy.thearctic.db.entity.RankInfo;
import com.ssafy.thearctic.db.entity.RankInfoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.servlet.http.HttpServletRequest;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

@Service
public class RankService {

    @Autowired
    private RankInfoRepository rankInfoRepository;

    private GetIp getIp;

    public void addRanking(HttpServletRequest request, RankInfoReq rankInfoReq){
        RankInfo rankInfo = new RankInfo(getIp.getClientIp(request), rankInfoReq.getNickName(), Float.parseFloat(rankInfoReq.getTime()));
        rankInfoRepository.save(rankInfo);
    }

    public List<RankInfoRes> getRanking(HttpServletRequest request){
        List<RankInfo> rankInfoList = rankInfoRepository.findAll();
        rankInfoList.sort(new Comparator<RankInfo>() {
            @Override
            public int compare(RankInfo o1, RankInfo o2) {
                return (int)(o1.getTime() - o2.getTime());
            }
        });
        List<RankInfoRes> rankInfoResList = new ArrayList<>();
        for(RankInfo rankInfo : rankInfoList){
            RankInfoRes res = RankInfoRes.of(rankInfo, rankInfo.getIp().equals(getIp.getClientIp(request)));
            rankInfoResList.add(res);
        }

        return rankInfoResList;
    }
}
