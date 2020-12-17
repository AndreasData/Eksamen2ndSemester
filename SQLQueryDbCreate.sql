
CREATE TABLE Request(
     RequestId int IDENTITY (1,1)  NOT NULL PRIMARY KEY,
     RoomId  int FOREIGN KEY (RoomId) REFERENCES Room(RoomId),
     WorkerId int FOREIGN KEY (WorkerId) REFERENCES Worker(WorkerId),
     Requestinfo VARCHAR(50) NOT NULL, 
);

CREATE TABLE Room(
     Room_No   int NOT NULL,
     RoomId  int IDENTITY (1,1) NOT NULL PRIMARY KEY,
     Building_No int  NOT NULL,
     Room_Type  VARCHAR(30)   NOT NULL,
);

CREATE TABLE Worker(
   WorkerId int  IDENTITY (1,1) NOT NULL PRIMARY KEY,
   WorkerName VARCHAR(50) NOT NULL,
   WorkerProf VARCHAR(50) NOT NULL, 
);