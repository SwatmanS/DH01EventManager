INSERT INTO ROSE_Login (Login_ID,Staff_ID,User_Name,Login_Password) VALUES  
	(1,1,'User1','Rose1'),
	(2,2,'User2','Rose2'),
	(3,3,'User3','Rose3'),
	(4,4,'User4','Rose4');

INSERT INTO ROSE_Staff (Staff_ID,Staff_Fname,Staff_Lname,Staff_position,Staff_PhoneNumber) VALUES 
	(1,'George','Harrison','Event leader','07954500477'),
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
	
INSERT INTO ROSE_Event (Event_ID,Location_ID,Event_Name,Event_Date,Event_Capacity,Event_Duration) VALUES 
	(1,1,'Cervical Screenings','09/12/2024 11:40:40',50,60),
	(2,2,'Cervical Screenings','09/12/2024 11:40:40',50,60),
	(3,3,'Cervical Screenings','09/12/2024 11:40:40',50,60),
	(4,4,'Cervical Screenings','09/12/2024 11:40:40',50,60);
	
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
	
INSERT INTO ROSE_Equipment(Equipment_ID,Equipment_Name,Equipment_Description) VALUES 
	(1,'Table','Wooden Table for leaflets'),
	(2,'Chair','Chair for sitting on');	
	
	