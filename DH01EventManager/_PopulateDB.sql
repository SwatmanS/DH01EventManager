INSERT INTO ROSE_Login (Login_ID,Staff_ID,User_Name,Login_Password) VALUES  
	(1,1,'User1','Rose1'),
	(2,2,'User2','Rose2'),
	(3,3,'User3','Rose3'),
	(4,4,'User4','Rose4');

INSERT INTO ROSE_Staff (Staff_ID,Staff_Fname,Staff_Lname,Staff_position,Staff_PhoneNumber) VALUES 
	(1, 'Aishah', 'Mayang','Manager','+60 4545 989090'),
	(2, 'Aishah', 'Shah','Manager','+60 4545 989090'),
	(3, 'Alya', 'Tiara','Manager','+60 4545 989090'),
	(4, 'Alya', 'Wira','Volunteer','+60 4545 989090'),
	(5, 'Amani', 'Wati','Volunteer','+60 4545 989090'),
	(6, 'Amani', 'Wira','Volunteer','+60 4545 989090'),
	(7, 'Ammar', 'Raja','Volunteer','+60 4545 989090'),
	(8, 'Arissa', 'Tam','Volunteer','+60 4545 989090'),
	(9, 'Ashraff', 'Tengku','Volunteer','+60 4545 989090'),
	(10, 'Balqis', 'Darma','Volunteer','+60 4545 989090'),
	(11, 'Batrisyia', 'Orked','Volunteer','+60 4545 989090'),
	(12, 'Damia', 'Jehan','Volunteer','+60 4545 989090'),
	(13, 'Damia', 'Mayang' ,'Volunteer','+60 4545 989090'),
	(14, 'Hadif', 'Tuah','Volunteer','+60 4545 989090'),
	(15, 'Hakim', 'Ros','Volunteer','+60 4545 989090'),
	(16, 'Haziq', 'Som','Volunteer','+60 4545 989090'),
	(17, 'Humaira', 'Jehan','Volunteer','+60 4545 989090'),
	(18, 'Irfan', 'Kesuma','Volunteer','+60 4545 989090'),
	(19, 'Keisha', 'Joyo','Volunteer','+60 4545 989090'),
	(20, 'Mia', 'Kiambang','Volunteer','+60 4545 989090'),
	(21, 'Noor', 'Lai','Volunteer','+60 4545 989090'),
	(22, 'Qaisara', 'Mayang','Volunteer','+60 4545 989090'),
	(23, 'Qistina', 'Mirza','Volunteer','+60 4545 989090'),
	(24, 'Rayyan', 'Kesuma','Volunteer','+60 4545 989090'),
	(25, 'Syshmi', 'Megat','Volunteer','+60 4545 989090'),
	(26, 'Zara', 'Shah','Volunteer','+60 4545 989090');

		
INSERT INTO ROSE_Equipment(Equipment_ID,Equipment_Name,Equipment_Description) VALUES 
	(1,'tables','Wooden Table for leaflets'),
	(2,'Chairs','Chair for sitting'),
	(3,'stuff','some generic helpful stuff'),
	(4,'stuff2','some generic helpful stuff'),
	(5,'stuff3','some generic helpful stuff'),
	(6,'stuff4','some generic helpful stuff'),
	(7,'stuff5','some generic helpful stuff'),
	(8,'stuff6','some generic helpful stuff'),
	(9,'stuff7','some generic helpful stuff'),
	(10,'stuff8','some generic helpful stuff'),
	(11,'stuff9','some generic helpful stuff'),
	(12,'stuff10','some generic helpful stuff');
	
INSERT INTO ROSE_Location (Location_ID,Location_name,Location_address,Location_Capacity) VALUES 
	(1,'Bangsar South Medical Clinic','Malaysia',50),
	(2,'Klinik Primary Care 4U','Malaysia',50),
	(3,'BeHealth Clinic','Malaysia',50),
	(4,'Perdana Medical Clinic','Malaysia',50),
	(5,'Klinik Dr.Prevents','Malaysia',50),
	(6,'Medhope Family Clinic','Malaysia',50),
	(7,'Qualitas SV Care Clinic','Malaysia',50),
	(8,'Wellcare Clinic','Malaysia',50),
	(9,'Klinik Mediviron Metropark','Malaysia',50),
	(10,'Klinik Primaria', 'Medizone Family Clinic','Malaysia',50),
	(11,'Klinik Family E-Medic','Malaysia',50),
	(12,'Klinik Careclinics Al-Amin','Malaysia',50),
	(13,'My Family Clinic','Malaysia',50),
	(14,'REN.CLINIC','Malaysia',50),
	(15,'RIIYYAH MEDICAL CLINIC','Malaysia',50),
	(16,'Muthus Clinic and Surgery','Malaysia',50),
	(17,'X Care Clinic','Malaysia',50),
	(18,'Family Clinic Seventeen','Malaysia',50),
	(19,'SV Care Clinic','Malaysia',50),
	(20,'Emerald Clinic Rawang','Malaysia',50),
	(21,'Nlee Family Clinic','Malaysia',50),
	(22,'MCare Clinic','Malaysia',50),
	(23,'TMC Health Centre','Malaysia',50),
	(24,'Clinic Medi-Genesis','Malaysia',50),
	(25,'One Med Clinic','Malaysia',50);

INSERT INTO ROSE_Event (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration) VALUES 
	(1,1,'Cervical Screenings','20/12/2024 11:30:00',60),
	(2,2,'Cervical Screenings','21/12/2024 11:30:00',60),
	(3,1,'Cervical Screenings','22/12/2024 11:30:00',60),
	(4,4,'Cervical Screenings','23/12/2024 11:30:00',60),
	(5,10,'Cervical Screenings','23/12/2024 11:30:00',60),
	(6,10,'Cervical Screenings','16/12/2024 11:30:00',60);

INSERT INTO ROSE_AssignStaff (AssignStaff_ID,Staff_ID,Event_ID) VALUES 
	(1,1,1),
	(2,2,1),
	(3,3,1),
	(4,4,1),
	(5,1,2),
	(6,5,2),
	(7,6,2),
	(8,7,2),
	(9,2,3),
	(10,8,3),
	(11,9,3),
	(12,10,3),
	(13,11,4),
	(14,3,4),
	(15,12,4),
	(16,13,4),
	(17,2,5),
	(18,14,5),
	(19,15,5),
	(20,16,5),
	(21,2,6),
	(22,14,6),
	(23,15,6),
	(24,16,6);

INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES 
	(1,1,1),
	(2,1,2),
	(3,1,3),
	(4,1,4),
	(5,2,1),
	(6,2,2),
	(7,2,6),
	(8,2,7),
	(9,3,1),
	(10,3,2),
	(11,3,7),
	(12,3,4),
	(13,4,7),
	(14,4,2),
	(15,4,4),
	(16,4,9),
	(17,5,1),
	(18,5,10),
	(19,5,3),
	(20,5,8),
	(21,6,1),
	(22,6,10),
	(23,6,3),
	(24,6,8);
	
INSERT INTO ROSE_PastEvents(PastEvent_ID,Event_ID,Actual_Turnout) VALUES 
	(1,6,46);

INSERT INTO ROSE_UpcomingEvents(NewEvent_ID,Event_ID,Predicted_Turnout) VALUES
	(1,1,19),
	(2,2,35),
	(3,3,60),
	(4,20),
	(5,5,46);
		



	
	