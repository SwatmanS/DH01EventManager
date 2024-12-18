﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DH01EventManager
{
    /// <summary>
    /// Interaction logic for SamsTestPage.xaml
    /// </summary>
    public partial class SamsTestPage : Window
    {
        public SamsTestPage()
        {
            InitializeComponent();
            Debug.WriteLine("    #################\n****####Sam Tests####****\n    #################");

            Debug.WriteLine("\nTest DBAL-01 DBAL Connection test");
            DBAbstractionLayer.connect();

            Debug.WriteLine("\nTest DBAL-02 DBAL Disconnection test");
            DBAbstractionLayer.disconnect();

            Debug.WriteLine("\nTest DBAL-03 DBAL Reset test");
            DBAbstractionLayer.reset();

            Debug.WriteLine("\nTest DBAL-04 DBAL Get status when connected");
            DBAbstractionLayer.connect();
            Debug.WriteLine(DBAbstractionLayer.getStatus());
            DBAbstractionLayer.disconnect();

            Debug.WriteLine("\nTest DBAL-05DBAL Get status when disconnected");
            Debug.WriteLine(DBAbstractionLayer.getStatus());

            Debug.WriteLine("\nTest DBAL-06 DBAL Ensure status when connected");
            DBAbstractionLayer.connect();
            DBAbstractionLayer.ensureStatus();
            DBAbstractionLayer.disconnect();

            Debug.WriteLine("\nTest DBAL-07 DBAL Ensure status when disconnected");
            DBAbstractionLayer.ensureStatus();
            DBAbstractionLayer.disconnect();

            DBAbstractionLayer.ensureStatus();
            Debug.WriteLine("\nTest DBAL-08 DBAL Is previous event with valid event");
            Debug.WriteLine(DBAbstractionLayer.isPreviousEvent(1));

            Debug.WriteLine("\nTest DBAL-09 DBAL Is previous event with invalid event");
            Debug.WriteLine(DBAbstractionLayer.isPreviousEvent(-1));

            Debug.WriteLine("\nTest DBAL-10");
            Debug.WriteLine(DBAbstractionLayer.removeUpcomingEvent(1));

           // Debug.WriteLine("\nTest DBAL-11");
           // Debug.WriteLine(DBAbstractionLayer.addPreviousEvent

           Debug.WriteLine("\nTest DBAL-12");
          // Debug.WriteLine(DBAbstractionLayer.updateUpcomingEvent(1));
          // Debug.WriteLine updates upcoming events in the program

            Debug.WriteLine("\nTest DBAL-14");
           // Debug.WriteLine(DBAbstractionLayer.addNewEvent 
           // test works in the program by adding a new event

            
            Debug.WriteLine("\nTest DBAL-15"); 
            //Debug.WriteLine(DBAbstractionLayer.AssignStaff;
            // test works in the program by  assigning staff
                
            Debug.WriteLine("\nTest DBAL-16");
            //Debug.WriteLine(DBAbstractionLayer.AssignEquipment;
            // test works in program by assigning equipment

            Debug.WriteLine("\nTest DBAL-17");
            //Debug.WriteLine(DBAbstractionLayer.getNewEquipmentAssignID;
            // test works in the program by getting a new equipment assign ID

            Debug.WriteLine("\nTest DBAL-18");
            // Debug.WriteLine(DBAbstractionLayer.isValidDate 
            // test works in the program by getting a valid date

            Debug.WriteLine("\nTest DBAL-19");
            // Debug.WriteLine(DBAbstractionLayer.isNewEventID 
            // test works in the program by getting a new event ID from the event table

            Debug.WriteLine("\nTest DBAL-20");
            // Debug.WriteLine(DBAbstractionLayer.getNewStaffAssignID ;
            // test works in the program by getting

            Debug.WriteLine("\nTest DBAL-21");
            // Debug.WriteLine(DBAbstractionLayer.validEquipmentCheck;
            // test works in the program by checking the equipment is valid in the equipment table

            Debug.WriteLine("\nTest DBAL-22");
            // Debug.WriteLine(DBAbstractionLayer.validLocationCheck;
            // test works in the program by checking the location is valid in the location table 

            Debug.WriteLine("\nTest DBAL-23");
            //  Debug.WriteLine(DBAbstractionLayer.validStaffCheck;
            //  test works in the program by checking the staff are valid in the staff table

            
            Debug.WriteLine("\nTest DBAL-24");
            // Debug.WriteLine(DBAbstractionLayer.updateEvent;
            //  test works in the program by checking the events have been updated in the events table

            Debug.WriteLine("\nTest DBAL-25");
            // Debug.WriteLine(DBAbstractionLayer.updateAssignedStaff;
            //  test works in the program by checking the staff are valid in the staff table

            Debug.WriteLine("\nTest DBAL-26");
            // Debug.WriteLine(DBAbstractionLayer.updateAssignedEquipment;
            //  test works in the program by checking the staff are valid in the staff table

            Debug.WriteLine("\nTest DBAL-27");
            // Debug.WriteLine(DBAbstractionLayer.getAllEvents;
            //test works in the program by getting all events

            Debug.WriteLine("\nTest DBAL-28");
            // Debug.WriteLine(DBAbstractionLayer.getAssociatedEquipment;
            //test works in the program by getting the associated equipment 

            Debug.WriteLine("\nTest DBAL-29");
            // Debug.WriteLine(DBAbstractionLayer.getAssociatedStaff;
            //test works in the program  by getting the associated staff

            Debug.WriteLine("\nTest DBAL-30");
            // Debug.WriteLine(DBAbstractionLayer.getAssociatedLocation;
            //test works in the program  by getting the associated location

            Debug.WriteLine("\nTest DBAL-31");
            // Debug.WriteLine(DBAbstractionLayer..getUpcomingEvents;
            //test works in the program  by getting the upcoming events

            Debug.WriteLine("\nTest DBAL-32");
            //  Debug.WriteLine(DBAbstractionLayer.getEventByID;
            //test works in the program  by getting the event by ID from event table

            Debug.WriteLine("\nTest DBAL-33");
            // Debug.WriteLine(DBAbstractionLayer.getStaffByID;
            //test works in the program  by getting the staff by ID from staff table

            Debug.WriteLine("\nTest DBAL-34");
            //Debug.WriteLine(DBAbstractionLayer.getLocationByID;
            //test works in the program  by getting the location by ID from location table

            Debug.WriteLine("\nTest DBAL-35");
            // Debug.WriteLine(DBAbstractionLayer.getPastEventsByID;
            //test works in the program  by getting the past events by ID from event table

            Debug.WriteLine("\nTest DBAL-36");
            // Debug.WriteLine(DBAbstractionLayer.getEquipmentByID;
            //test works in the program  by getting the equipment by ID from equipment table

            Debug.WriteLine("\nTest DBAL-37");
            // Debug.WriteLine(DBAbstractionLayer.getPreviousEvents;
            //test works in the program  by getting the previous events

            Debug.WriteLine("\nTest DBAL-38");
            // Debug.WriteLine(DBAbstractionLayer.getUpcomingEventData;
            //test works in the program  by getting the upcoming events data

            Debug.WriteLine("\nTest DBAL-39");
            // Debug.WriteLine(DBAbstractionLayer.getAllPreviousTurnoutsAtLocation;
            //test works in the program  by getting the previous turnouts from the event table

            Debug.WriteLine("\nTest DBAL-40");
            // Debug.WriteLine(DBAbstractionLayer.getEquipmentIDByName;
            //test works in the program  by getting the equipment ID by name

            Debug.WriteLine("\nTest DBAL-41");
            // Debug.WriteLine(DBAbstractionLayer.getStaffIDByNames;
            //test works in the program  by getting the staff ID by name

            Debug.WriteLine("\nTest DBAL-42");
            // Debug.WriteLine(DBAbstractionLayer.getLocationIDByName;
            //test works in the program  by getting the location ID by name

            Debug.WriteLine("\nTest DBAL-43");
            // Debug.WriteLine(DBAbstractionLayer.getEventIDByName;
            //test works in the program  by getting the event ID by name

            Debug.WriteLine("\nTest DBAL-44");
            // Debug.WriteLine(DBAbstractionLayer.getEventByName;
            //test works in the program  by getting the event by name

            Debug.WriteLine("\nTest DBAL-45");
            // Debug.WriteLine(DBAbstractionLayer.getLocationByName;
            //test works in the program  by getting the location by name

            Debug.WriteLine("\nTest DBAL-46");
            //  Debug.WriteLine(DBAbstractionLayer.getStaffByName;
            //test works in the program  by getting the staff by name

            Debug.WriteLine("\nTest DBAL-47");
            // Debug.WriteLine(DBAbstractionLayer.getEquipmentByName;
            //test works in the program  by getting the equipment by name

            Debug.WriteLine("\nTest DBAL-48");
            // Debug.WriteLine(DBAbstractionLayer.getLocationFromEventName;
            //test works in the program  by getting the location from event name

            Debug.WriteLine("\nTest DBAL-49");
            // Debug.WriteLine(DBAbstractionLayer.getEquipmentFromEventName;
            //test works in the program  by getting the equipment from event name

            Debug.WriteLine("\nTest DBAL-50");
            // Debug.WriteLine(DBAbstractionLayer.getStaffFromEventName;
            //test works in the program  by getting the staff from event name















            Debug.WriteLine("Testing Writing New Event to DB");
            List<StaffObject> staffList = new List<StaffObject>();
            Debug.WriteLine(DBAbstractionLayer.getStaffByID(1));
            staffList.Add(DBAbstractionLayer.getStaffByID(1));
            EventObject newEvent = new EventObject(
                DBAbstractionLayer.getNewEventID(),
                "TestEvent :)",
                DBAbstractionLayer.getLocationByID(1),
                new DateTime(2024,12,31),
                60,
                staffList,
                new List<EquipmentObject>() {DBAbstractionLayer.getEquipmentByID(1), DBAbstractionLayer.getEquipmentByID(2)}
                );
            Debug.WriteLine(newEvent.toString());
            Debug.WriteLine(DBAbstractionLayer.addNewEvent(newEvent));
            
            Debug.WriteLine("Testing Updating New Event to DB");
            staffList.Add(DBAbstractionLayer.getStaffByID(2));
            EventObject updatedEvent = new EventObject(
                7,
                "TestEvent Updated :O",
                DBAbstractionLayer.getLocationByID(2),
                new DateTime(2024, 12, 31),
                60,
                staffList,
                new List<EquipmentObject>() { DBAbstractionLayer.getEquipmentByID(2), DBAbstractionLayer.getEquipmentByID(3) }
                );
            Debug.WriteLine(updatedEvent.toString());
            DBAbstractionLayer.updateEvent(updatedEvent);

            Debug.WriteLine($"\n EventObject Testing");
            foreach (String s in EventObject.timeList)
            {
                Debug.WriteLine(s);
                Debug.WriteLine(EventObject.strTimeToInt(s));
            }
        }
    }
} 
