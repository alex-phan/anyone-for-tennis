USE [TennisMemberShip];

CREATE TABLE Coaches (
    CoachId INT PRIMARY KEY IDENTITY ,
    FirstName VARCHAR(50) ,
    LastName VARCHAR(50) ,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Biography TEXT ,
	LoginStatus BIT DEFAULT (0)
);

CREATE TABLE Members (
    MemberId INT PRIMARY KEY IDENTITY ,
    FirstName VARCHAR(50) ,
    LastName VARCHAR(50) ,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
	LoginStatus BIT DEFAULT (0)
);

CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) ,
    LastName VARCHAR(50) ,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
	LoginStatus BIT DEFAULT (0)
);

CREATE TABLE Schedules (
    ScheduleId INT PRIMARY KEY IDENTITY ,
    EventName VARCHAR(100) NOT NULL,
    Date DATETIME NOT NULL,
    Location VARCHAR(100) NOT NULL,
    CoachId INT NOT NULL,
	MemberId INT,
    FOREIGN KEY (CoachId) REFERENCES Coaches (CoachId),
	FOREIGN KEY (MemberId) REFERENCES Members (MemberId)
);

CREATE TABLE Enrollments (
	EnrollId INT IDENTITY PRIMARY KEY,
	ScheduleId INT NOT NULL,
	MemberId INT NOT NULL,
	FOREIGN KEY (ScheduleId) REFERENCES Schedules(ScheduleId),
	FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
);

INSERT INTO Admins (FirstName, LastName, Email, PasswordHash)
VALUES ('Admin', 'User', 'admin@example.com', '1234567890');


INSERT INTO Members (FirstName, LastName, Email, PasswordHash)
VALUES
    ('John', 'Doe', 'john@example.com', 'hashed_password_1'),
    ('Jane', 'Smith', 'jane@example.com', 'hashed_password_2'),
    ('Bob', 'Johnson', 'bob@example.com', 'hashed_password_3'),
    ('Alice', 'Brown', 'alice@example.com', 'hashed_password_4'),
    ('Eva', 'Wilson', 'eva@example.com', 'hashed_password_5');



INSERT INTO Coaches (FirstName, LastName, Email, PasswordHash, Biography)
VALUES
    ('Coach', 'A', 'coachA@example.com', 'hashed_password_6', 'Experienced coach with a focus on strength training.'),
    ('Coach', 'B', 'coachB@example.com', 'hashed_password_7', 'Certified yoga instructor specializing in flexibility and mindfulness.'),
    ('Coach', 'C', 'coachC@example.com', 'hashed_password_8', 'Professional personal trainer with a passion for nutrition.'),
    ('Coach', 'D', 'coachD@example.com', 'hashed_password_9', 'Experienced martial arts instructor with a black belt.'),
    ('Coach', 'E', 'coachE@example.com', 'hashed_password_10', 'Certified spin class instructor and fitness enthusiast.');


INSERT INTO Schedules (EventName, Date, Location, CoachId, MemberId)
VALUES
    ('Yoga Class', '2023-10-15', 'Yoga Studio A', 2, 1),  
    ('Strength Training', '2023-10-18', 'Gym X', 1, 2),    
    ('Nutrition Workshop', '2023-10-20', 'Community Center', 3, 3),  
    ('Martial Arts Class', '2023-10-22', 'Dojo Z', 4, 4),  
    ('Spin Class', '2023-10-25', 'Fitness Center Y', 5, 5);  

-- Insert data into Enrollments
INSERT INTO Enrollments (ScheduleId, MemberId)
VALUES
    (1, 1),  -- Yoga Class, Member 1
    (2, 2),  -- Strength Training, Member 2
    (3, 3),  -- Nutrition Workshop, Member 3
    (4, 4),  -- Martial Arts Class, Member 4
    (5, 5);  -- Spin Class, Member 5

  