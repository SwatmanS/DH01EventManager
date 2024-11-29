namespace DH01EventManager
{
    public class LocationObject
    {
        //attributes
        private int locationID;
        private string locationName;
        private string locationType;
        private int locationCapacity;

        public LocationObject(int locationID, string locationName, string locationType, int locationCapacity)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.locationType = locationType;
            this.locationCapacity = locationCapacity;
        } //constructor

        //getters

        public int GetLocationID() { return this.locationID; }
        public string GetLocationName() {return this.locationName; }  

        public string GetLocationType() { return this.locationType;}

        public int GetLocationCapacity() { return this.locationCapacity;}

        //setters

        public void SetLocationID(int locationID) { this.locationID = locationID; }
        public void SetLocationName(string locationName) { this.locationName = locationName; }  

        public void SetLocationType(string locationType) { this.locationType = locationType; }

        public void SetLocationCapacity(int locationCapacity) { this.locationCapacity = locationCapacity; }

    }
}