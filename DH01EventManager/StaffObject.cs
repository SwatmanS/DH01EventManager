using System.Security.Policy;

namespace DH01EventManager
{
    public class StaffObject
    {
        private Int32 staffID;
        private String forename;
        private String surname;
        private String staffPhoneNo;
        private String staffPosition;

        public StaffObject(int staffID, String forename, String surname, String staffPhoneNo, String staffPosition)
        {
            this.staffID = staffID;
            this.forename = forename;
            this.surname = surname;
            this.staffPhoneNo = staffPhoneNo; 
            this.staffPosition = staffPosition;
        }

        public Int32 getStaffID() {  return this.staffID; }
        public String getForename() { return this.forename; }
        public String getSurname() { return this.surname;}
        public String getStaffPhoneNo() {  return this.staffPhoneNo;}
        public String getStaffPosition() { return this.staffPosition; }

        public String getStaffFullName() { return String.Concat(this.forename, " ", this.surname); }

        public void setStaffID(Int32 id) { this.staffID = id; }
        public void setForname(String forename) {  this.forename = forename; }
        public void setSurname(String surname) { this.surname = surname; }
        public void setStaffPhoneNo(String phone) { this.staffPhoneNo = phone; }
        public void setStaffPosition(String position) {  this.staffPosition = position; }

        public String toString() 
        {
            return String.Concat("Staff ID: ", this.staffID,"\nFull Name: ",this.forename, " ", this.surname,"\nPhone Number: ",this.staffPhoneNo,"\nPosition: ",this.staffPosition);
        }

        public List <StaffObject>? listToObject(List <String> source)
        {
            //in addEvents, the names are stored as one string instead of two separate ones which are needed for the getStaffByName method
            //below code fixes this
            List<StaffObject> staffOb = new List<StaffObject>();
            foreach (String sourceItem in source)
            {
                String[] split = sourceItem.Split(' '); //splits each item in the source staff list (which would be the checked staff) based on a blank space
                String first = split[0]; //saves first item in split array as forename
                String second = split[1]; //savees second item in split array as surname
                StaffObject staff = DBAbstractionLayer.getStaffByName(first, second); //runs getStaffByName, creating the relevant staff object
                staffOb.Add(staff); //adds to object list
            }
            return staffOb;
        }
    }
}