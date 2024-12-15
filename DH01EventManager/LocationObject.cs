namespace DH01EventManager
{
    public class LocationObject
    {
        private Int32 locationID;
        private String locationName;
        private String locationAddress;
        private Int32 locationCapacity;

        public LocationObject(Int32 locationID, String locationName, String locationAddress, Int32 locationCapacity)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.locationAddress = locationAddress;
            this.locationCapacity = locationCapacity;
        }

        public Int32 getLocationID() { return locationID; } 
        public String getLocationName() { return locationName;}
        public String getLocationAddress() { return locationAddress;}
        public Int32 getLocationCapacity() {  return locationCapacity;}

        public void setLocationID(Int32 locationID) {  this.locationID = locationID; }
        public void setLocationName(String locationName) {  this.locationName = locationName; }
        public void setLocationAddress(String locationAddress) { this.locationAddress = locationAddress; }
        public void setLoctionCapacity(Int32 locationCapacity) { this.locationCapacity = locationCapacity; }

        public String toString()
        {
            return String.Concat("Location: ",this.locationName,"\nID = ",this.locationID,"\nAddress = ",this.locationAddress,"\nCapacity = ",this.locationCapacity);
        }

        public List<LocationObject> objListBuilder(List<String> loc,List<LocationObject> locOb)
        {
            foreach (String s in loc)
            {
                locOb.Add(DBAbstractionLayer.getLocationByName(s)); //gets the locationObject for each item in the list by their name
            }
            return locOb;
        }
           
    }
}