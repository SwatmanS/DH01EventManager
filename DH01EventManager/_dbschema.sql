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
	User_Name TEXT,
	Login_Password TEXT,
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
	Event_Name TEXT,
	Event_Date CHAR(23),
	Event_Duration INTEGER(32),
	PRIMARY KEY(Event_ID),
	FOREIGN KEY (Location_ID) REFERENCES  ROSE_Location (Location_ID)                       
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
	   
