package com.ssafy.thearctic.api.response;

import com.ssafy.thearctic.db.entity.RankInfo;
import lombok.Data;

@Data
public class RankInfoRes {
    String nickName;
    String time;
    boolean isMe;

    public static RankInfoRes of(RankInfo rankInfo, boolean isMe) {
        RankInfoRes res = new RankInfoRes();
        res.setNickName(rankInfo.getNickName());
        int minutes = (int)rankInfo.getTime()/60;
        int seconds = (int)rankInfo.getTime()%60;
        res.setTime(String.format("%02d:%02d",minutes,seconds));
        res.setMe(isMe);
        return res;
    }
}
