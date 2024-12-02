namespace DH01EventManager
{
    public class EquipmentObject
    {
        //attributes - feel free to change
        private int equipmentID;
        private string equipmentName;
        private string equipmentType;
        private int equipmentQuantity;

        public EquipmentObject(int ID, string name, string type, int quantity)
        {
            this.equipmentID = ID;
            this.equipmentName = name; 
            this.equipmentType = type;
            this.equipmentQuantity = quantity;
        } //contrsuctor 

        
        //gettters

        public int getEquipmentID() { return this.equipmentID; }
        public string getEquipmentName() { return this.equipmentName; }

        public string getEquipmentType() { return this.equipmentType; }
        public int getEquipmentQuantity() { return this.equipmentQuantity; }


        //setters
        public void setEquipmentID(int id) { this.equipmentID = id; }
        public void setEquipmentName(String name) { this.equipmentName = name; }
        public void setEquipmentType(String type) { this.equipmentType = type; }
        public void setEquipmentQuantity(int quantity) { this.equipmentQuantity = quantity; }
    }
}