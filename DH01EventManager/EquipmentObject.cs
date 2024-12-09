namespace DH01EventManager
{
    public class EquipmentObject
    {
        //attributes - feel free to change
        private Int32 equipmentID;
        private String equipmentName;
        private String equipmentDesc;
        private Int32 equipmentQuantity;

        public EquipmentObject(Int32 ID, String name, String description)
        {
            this.equipmentID = ID;
            this.equipmentName = name; 
            this.equipmentDesc = description;
        } //contrsuctor 

        
        //gettters

        public Int32 getEquipmentID() { return this.equipmentID; }
        public String getEquipmentName() { return this.equipmentName; }

        public String getEquipmentDesc() { return this.equipmentDesc; }


        //setters
        public void setEquipmentID(Int32 id) { this.equipmentID = id; }
        public void setEquipmentName(String name) { this.equipmentName = name; }
        public void setEquipmentType(String type) { this.equipmentDesc = type; }

        public String toString() 
        {
            return String.Concat("Equipment: ", this.equipmentName, "\nID = ", this.equipmentID, "\nType = ", this.equipmentDesc, "\nQuantity = ", this.equipmentQuantity);
        }
    }
}