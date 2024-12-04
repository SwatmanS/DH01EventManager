using System.Security.Policy;

namespace DH01EventManager
{
    public class StaffObject
    {
        private Int32 staffID;
        private String fName;
        private String sName;
        private String StaffPhone;
        private String staffPosition;

        public StaffObject(int staffID, String fName, String sName, String staffPhone, String\ staffPosition)
        {
            this.staffID = staffID;
            this.fName = fName;
            this.sName = sName;
            StaffPhone = staffPhone;
            this.staffPosition = staffPosition;
        }

        public Int32 getStaffID() {  return this.staffID; }
        public String getfName() { return this.fName; }
        public String getsName() { return this.sName;}
        public String getStaffPhone() {  return this.StaffPhone;}
        public String getStaffPosition() { return this.staffPosition; }

        public String getStaffName() { return String.Concat(this.fName, this.sName); }

        public void setStaffID(Int32 id) { this.staffID = id; }
        public void setfName(String fname) {  this.fName = fname; }
        public void setsName(String sname) { this.sName = sname; }
        public void setStaffPhone(String phone) { this.StaffPhone = phone; }
        public void setStaffPosition(String position) {  this.staffPosition = position; }

        public String toString() 
        {
            return String.Concat("Staff: ", this.staffID,"Name = ",this.sName,this.fName,"\nPhone = ",this.StaffPhone,"\nPosition = ",this.staffPosition);
        }
    }
}