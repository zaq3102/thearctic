package com.ssafy.thearctic.db.entity;

import org.springframework.data.mongodb.repository.MongoRepository;

public interface GameDataRepository extends MongoRepository<GameData, String> {
}
