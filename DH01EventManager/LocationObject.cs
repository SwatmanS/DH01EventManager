namespace DH01EventManager
{
    public class LocationObject
    {
        //attributes
        private Int32 locationID;
        private String locationName;
        private String locationType;
        private Int32 locationCapacity;

        public LocationObject(Int32 locationID, String locationName, String locationType, Int32 locationCapacity)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.locationType = locationType;
            this.locationCapacity = locationCapacity;
        } //constructor

        //getters

        public Int32 GetLocationID() { return this.locationID; }
        public String GetLocationName() {return this.locationName; }  

        public String GetLocationType() { return this.locationType;}

        public Int32 GetLocationCapacity() { return this.locationCapacity;}

        //setters

        public void SetLocationID(Int32 locationID) { this.locationID = locationID; }
        public void SetLocationName(String locationName) { this.locationName = locationName; }  

        public void SetLocationType(String locationType) { this.locationType = locationType; }

        public void SetLocationCapacity(Int32 locationCapacity) { this.locationCapacity = locationCapacity; }

    }
}