namespace DH01EventManager
{
    public class StaffObject
    {
        //attributes - feel free to change
        private Int32 staffID;
        private String staffName; //might be unneccessary
        private String staffType;
        private String[] workableEvents; //maybe certain staff can only work certain events?

        public StaffObject(Int32 ID, String name, String type, String[] workable)
        {
            this.staffID = ID;
            this.staffName = name;
            this.staffType = type;
            this.workableEvents = workable;
        } //contrsuctor 


        //gettters


        public Int32 getStaffID() { return this.staffID; }
        public String getStaffName() { return this.staffName; }

        public String getStaffType() { return this.staffType; }
        public String[] GetWorkableEvents() { return this.workableEvents; }
        

        //setters
        public void setStaffID(Int32 id) { this.staffID = id; }

        public void setStaffName(String name) { this.staffName = name; }
        public void setStaffType(String type) { this.staffType = type; }

        public void setWorkableEvents(String[] workable) { this.workableEvents = workable; }

   
    }
}