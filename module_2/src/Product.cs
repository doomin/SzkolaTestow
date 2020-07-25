
namespace szkola_testow {

    public class Product {

        private decimal _netPrice;
        private int _id; 
        private string _type;

        public decimal NetPrice 
        {   
            get { return _netPrice; }
            set { _netPrice = value; }
        }

        public int Id
        { 
            get { return _id;} 
            set { _id = value; }
        }

        public string Type
        { 
             get {return _type;}
             set { _type = value; }
        }

        public Product (int id, decimal netPrice, string type)
        {
            this.Id = _id;
            this.NetPrice = _netPrice;
            this.Type = _type;
        }
    }
}
