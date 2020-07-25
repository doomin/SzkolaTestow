using System;

namespace szkola_testow {

    public class VatService: IVatProvider{

        private IVatProvider vatProvider; 

        public VatService(IVatProvider vatProvider){
            this.vatProvider = vatProvider;
        }

        public decimal GetGrossPriceForDefaultVat(Product product) {
            return CalculatedGrossPrice(product.NetPrice, vatProvider.GetDefaultVat());
        }

        public decimal GetGrossPrice(decimal netPrice, string productType){
                decimal vatValue = vatProvider.GetVatForType(productType);
                return CalculatedGrossPrice(netPrice, vatValue);

        }

        private decimal CalculatedGrossPrice(decimal netPrice, decimal vatValue)
        {            
                int setPrecision = 4;
                if(vatValue.CompareTo(decimal.One) == 1){
                    throw (new Exception("VAT needs to be lower!"));
                }

                if(vatValue < 0){
                    throw (new Exception("VAT cannot be a negative numer!"));
                }             
                return Math.Round(netPrice * (1 + vatValue),setPrecision);
        }

        decimal IVatProvider.GetDefaultVat()
        {
            return vatProvider.GetDefaultVat();
        }

        public decimal GetVatForType(string type)
        {
            return vatProvider.GetVatForType(type);
        }
    }
}