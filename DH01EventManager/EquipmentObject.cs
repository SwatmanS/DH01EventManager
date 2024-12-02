namespace DH01EventManager
{
    public class EquipmentObject
    {
        //attributes - feel free to change
        private Int32 equipmentID;
        private String equipmentName;
        private String equipmentType;
        private Int32 equipmentQuantity;

        public EquipmentObject(Int32 ID, String name, String type, Int32 quantity)
        {
            this.equipmentID = ID;
            this.equipmentName = name; 
            this.equipmentType = type;
            this.equipmentQuantity = quantity;
        } //contrsuctor 

        
        //gettters
        public Int32 getEquipmentID() { return this.equipmentID; }
        public String getEquipmentName() { return this.equipmentName; }

        public String getEquipmentType() { return this.equipmentType; }
        public Int32 getEquipmentQuantity() { return this.equipmentQuantity; }


        //setters
        public void setEquipmentID(Int32 id) { this.equipmentID = id; }
        public void setEquipmentName(String name) { this.equipmentName = name; }
        public void setEquipmentType(String type) { this.equipmentType = type; }
        public void setEquipmentQuantity(Int32 quantity) { this.equipmentQuantity = quantity; }
    }
}