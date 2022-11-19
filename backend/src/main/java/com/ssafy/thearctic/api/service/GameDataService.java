package com.ssafy.thearctic.api.service;

import com.ssafy.thearctic.api.request.UserReq;
import com.ssafy.thearctic.common.model.response.BaseResponseBody;
import com.ssafy.thearctic.db.entity.User;
import com.ssafy.thearctic.db.entity.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@Service
public class GameDataService {

    @Autowired
    private UserRepository userRepository;

    public void save(UserReq userReq){
        User user = new User(userReq.getName(), userReq.getAge());
        userRepository.insert(user);
    }

    public User load(){
        return userRepository.findByName("happy");
    }

}
