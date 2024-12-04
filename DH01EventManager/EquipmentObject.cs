namespace DH01EventManager
{
    internal class EquipmentObject
    {
        //attributes - feel free to change
        private Int32 equipmentID;
        private String equipmentName;
        private String equipmentDesc;
        private Int32 equipmentQuantity;

        public EquipmentObject(Int32 ID, String name, String description, Int32 quantity)
        {
            this.equipmentID = ID;
            this.equipmentName = name; 
            this.equipmentDesc = description;
            this.equipmentQuantity = quantity;
        } //contrsuctor 

        
        //gettters

        public Int32 getEquipmentID() { return this.equipmentID; }
        public String getEquipmentName() { return this.equipmentName; }

        public String getEquipmentDesc() { return this.equipmentDesc; }
        public Int32 getEquipmentQuantity() { return this.equipmentQuantity; }


        //setters
        public void setEquipmentID(Int32 id) { this.equipmentID = id; }
        public void setEquipmentName(String name) { this.equipmentName = name; }
        public void setEquipmentType(String type) { this.equipmentDesc = type; }
        public void setEquipmentQuantity(Int32 quantity) { this.equipmentQuantity = quantity; }

        public String toString() 
        {
            return String.Concat("Equipment: ", this.equipmentName, "\nID = ", this.equipmentID, "\nType = ", this.equipmentDesc, "\nQuantity = ", this.equipmentQuantity);
        }
    }
}