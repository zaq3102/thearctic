package com.ssafy.thearctic.db.entity;

import lombok.Getter;
import lombok.Setter;
import nonapi.io.github.classgraph.json.Id;
import org.springframework.data.annotation.TypeAlias;

import java.time.LocalDateTime;

@Getter
@Setter
@TypeAlias("rank")
public class RankInfo {
    @Id
    public String id;

    public String ip;
    public String nickName;
    public float time;
    public LocalDateTime date;

    public RankInfo(String ip, String nickName, float time){
        this.ip = ip;;
        this.nickName = nickName;
        this.time = time;
        this.date = LocalDateTime.now();
    }
}
