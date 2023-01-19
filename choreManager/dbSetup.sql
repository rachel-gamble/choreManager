CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS chores(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        task VARCHAR(255) NOT NULL,
        coverImg VARCHAR(255) NOT NULL DEFAULT 'https://images.unsplash.com/photo-1484887603430-371459454eed?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1156&q=80',
        minutes DOUBLE NOT NULL,
        completed BOOLEAN NOT NULL DEFAULT false,
        archived BOOLEAN NOT NULL DEFAULT false,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    chores (
        task,
        0 / 0: TechnomancyDb / 0: TechnomancyDb / 0: tables / 0: accounts `coverImg`,
        minutes,
        completed,
        archived,
        `creatorId`
    )
VALUES (
        "Sweep the kitchen, halls, and bathrooms",
        'https://images.unsplash.com/photo-1585933646706-7b629be871aa?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1171&q=80',
        30,
        false,
        false,
        63991276 ace206a2788fca7d
    );