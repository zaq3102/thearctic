package com.ssafy.thearctic.config;

import com.mongodb.ConnectionString;
import com.mongodb.MongoClientSettings;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoClients;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.mongodb.config.AbstractMongoClientConfiguration;

@Configuration
public class MongoConfig extends AbstractMongoClientConfiguration {

    @Value("${spring.data.mongodb.uri}")
    private String mongoDbURI;

    @Value("${spring.data.mongodb.database}")
    private String mongoDbDatabase;

    @Override
    protected String getDatabaseName() {
        return mongoDbDatabase;
    }

    @Override
    public MongoClient mongoClient() {
        final ConnectionString connectionString = new ConnectionString(mongoDbURI);
        final MongoClientSettings mongoClientSettings = MongoClientSettings.builder()
                .applyConnectionString(connectionString)
                .build();
        return MongoClients.create(mongoClientSettings);
    }
}
