package com.ssafy.thearctic.db.entity;

import lombok.Getter;
import lombok.Setter;
import nonapi.io.github.classgraph.json.Id;
import org.springframework.data.annotation.TypeAlias;

@Getter
@Setter
@TypeAlias("data")
public class User {
    @Id
    public String id;
    public String name;
    public int age;

    public User() {}

    public User(String name, int age) {
        this.name = name;
        this.age = age;
    }

}
