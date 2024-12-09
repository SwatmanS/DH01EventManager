DROP TABLE IF EXISTS ROSE_Login;
DROP TABLE IF EXISTS ROSE_Staff;
DROP TABLE IF EXISTS ROSE_AssignStaff;
DROP TABLE IF EXISTS ROSE_Location;
DROP TABLE IF EXISTS ROSE_Event;
DROP TABLE IF EXISTS ROSE_PastEvents;
DROP TABLE IF EXISTS ROSE_UpcomingEvents;
DROP TABLE IF EXISTS ROSE_EquipmentAssign;
DROP TABLE IF EXISTS ROSE_Equipment;
	   
CREATE TABLE IF NOT EXISTS ROSE_Login(
	Login_ID INTEGER(32),
	Staff_ID INTEGER(32),
	Login_Password CHAR(23),
	PRIMARY KEY(Login_ID),
	FOREIGN KEY(Staff_ID) REFERENCES  ROSE_Staff (Staff_ID)
	);
	   
CREATE TABLE IF NOT EXISTS ROSE_Staff(
    Staff_ID INTEGER(32),
	Staff_Fname TEXT,
	Staff_Lname TEXT,
	Staff_position TEXT,
	Staff_PhoneNumber TEXT,
	PRIMARY KEY(Staff_ID)
	);
	
CREATE TABLE IF NOT EXISTS ROSE_AssignStaff(
    AssignStaff_ID INTEGER(32),
	Staff_ID INTEGER(32),
	Event_ID INTEGER(32),
	PRIMARY KEY(AssignStaff_ID),
	FOREIGN KEY (Staff_ID) REFERENCES  ROSE_Staff (Staff_ID)
	FOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID) 
	);
	
	   
CREATE TABLE IF NOT EXISTS ROSE_Location(
	Location_ID INTEGER(32),
	Location_Name CHAR(6),
	Location_Address CHAR(6),
	Location_Capacity INTEGER(32),
	PRIMARY KEY(Location_ID)
	);
	   
CREATE TABLE IF NOT EXISTS ROSE_Event(
	Event_ID INTEGER(32),
	Location_ID INTEGER(32),
	Staff_ID INTEGER(32),
	Event_Name TEXT,
	Event_Date CHAR(23),
	Event_Capacity INTEGER(32),
	Event_Duration INTEGER(32),
	PRIMARY KEY(Event_ID),
	FOREIGN KEY (Location_ID) REFERENCES  ROSE_Location (Location_ID)
	FOREIGN KEY(Staff_ID) REFERENCES  ROSE_Staff (Staff_ID)                                 
	);


CREATE TABLE IF NOT EXISTS ROSE_PastEvents(
	PastEvent_ID INTEGER(32),
	Event_ID INTEGER(32),
	Actual_Turnout INTEGER,
	PRIMARY KEY(PastEvent_ID),
	FOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID)
	);
	 
CREATE TABLE IF NOT EXISTS ROSE_UpcomingEvents(
	NewEvent_ID INTEGER(32),
	Event_ID INTEGER(32),
	Predicted_Turnout INTEGER(32),
	PRIMARY KEY(NewEvent_ID),
	FOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID)
	);
	   
CREATE TABLE IF NOT EXISTS ROSE_EquipmentAssign(
	EquipmentAssign_ID INTEGER(32),
	Event_ID INTEGER(32),
	Equipment_ID INTEGER(32),
	PRIMARY KEY(EquipmentAssign_ID),
	FOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID)
	FOREIGN KEY(Equipment_ID) REFERENCES  ROSE_Equipment (Equipment_ID)
	);
	   
CREATE TABLE IF NOT EXISTS ROSE_Equipment(
	Equipment_ID INTEGER(32),
	Equipment_Name TEXT,
	Equipment_Description TEXT,
	PRIMARY KEY(Equipment_ID)
	);
	   
INSERT INTO ROSE_Login (Login_ID,Staff_ID,Login_Password ) VALUES  
	(1,1,'Rose1'), 
	(2,2,'Rose2'),
	(3,3,'Rose3'),
	(4,4,'Rose4');

INSERT INTO ROSE_Staff (Staff_ID,Staff_Fname,Staff_Lname,Staff_position,Staff_PhoneNumber) VALUES 
	(1,'George','Harrison','Event lead','07954500477'),
	(2,'John','Lennon','Manager','07954500627'),
	(3,'Paul','Mcartney','Assiant Manager','07954500657'),
	(4,'Richard','Starkey','Lab Tech','07954500677');
	
INSERT INTO ROSE_AssignStaff (AssignStaff_ID,Staff_ID,Event_ID) VALUES 
	(1,1,1),
	(2,2,2),
	(3,3,3),
	(4,4,4);	
	
INSERT INTO ROSE_Location (Location_ID,Location_name,Location_address,Location_Capacity) VALUES 
	(1,'Tynemouth Pool','Tynemouth Surf Cafe',30),
	(2,'Monument','Monument Statue',55),
	(3,'Cullercoats','Cullercoats beach',40),
	(4,'Heaton','Simonside Terrace',50);
	
INSERT INTO ROSE_Event (Event_ID,Location_ID,Staff_ID,Event_Name,Event_Date,Event_Capacity,Event_Duration) VALUES 
	(1,1,1,'Cervical Screenings','09/12/2024 11:40:40',50,60),
	(2,2,2,'Cervical Screenings','09/12/2024 11:40:40',50,60),
	(3,3,3,'Cervical Screenings','09/12/2024 11:40:40',50,60),
	(4,4,4,'Cervical Screenings','09/12/2024 11:40:40',50,60);
	
INSERT INTO ROSE_PastEvents(PastEvent_ID,Event_ID,Actual_Turnout) VALUES 
	(1,1,100),
	(2,2,150),
	(3,3,130),
	(4,4,107);

INSERT INTO ROSE_UpcomingEvents(NewEvent_ID,Event_ID,Predicted_Turnout) VALUES
	(1,1,150),
	(2,2,100),
	(3,3,125),
	(4,4,100);
		

INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES 
	(1,1,100),
	(2,2,100),
	(3,3,100),
	(4,4,100);
	
INSERT INTO ROSE_Equipment(Equipment_ID,Equipment_Name,Equipment _Description) VALUES 
	(1,'Table','Wooden Table for leaflets'),
	(2,'Chair','Chair for sitting on');	
	