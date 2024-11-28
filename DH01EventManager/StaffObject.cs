namespace DH01EventManager
{
    public class StaffObject
    {
        //attributes - feel free to change
        private string staffID;
        private string staffName; //might be unneccessary
        private string staffType;
        private string[] workableEvents; //maybe certain staff can only work certain events?

        public StaffObject(string ID, string name, string type, string[] workable)
        {
            this.staffID = ID;
            this.staffName = name;
            this.staffType = type;
            this.workableEvents = workable;
            //i think that maybe staff data would be stored in the database so this information
            //would be pulled from there?
        } //contrsuctor 


        //gettters


        public string getStaffID() { return this.staffID; }
        public string getStaffName() { return this.staffName; }

        public string getStaffType() { return this.staffType; }
        public string[] GetWorkableEvents() { return this.workableEvents; }
        

        //setters
        public void setStaffID(String id) { this.staffID = id; }

        public void setStaffName(String name) { this.staffName = name; }
        public void setStaffType(String type) { this.staffType = type; }

        public void setWorkableEvents(String[] workable) { this.workableEvents = workable; }

   
    }
}