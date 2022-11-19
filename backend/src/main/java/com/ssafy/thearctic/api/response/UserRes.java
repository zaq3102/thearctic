package com.ssafy.thearctic.api.response;

import com.ssafy.thearctic.common.model.response.BaseResponseBody;
import com.ssafy.thearctic.db.entity.User;
import lombok.Data;

@Data
public class UserRes extends BaseResponseBody {
    private String name;
    private int age;

    public static UserRes of(Integer statusCode, String message, User user) {
        UserRes res = new UserRes();
        res.setStatusCode(statusCode);
        res.setMessage(message);
        res.setName(user.getName());
        res.setAge(user.getAge());
        return res;
    }
}
