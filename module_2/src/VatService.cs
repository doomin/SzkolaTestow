using System;
using System.Globalization;

namespace szkola_testow {

    public class VatService {
        decimal vatValue;

        public VatService(){
            this.vatValue = 0.23M;
        }

        public decimal GetGrossPriceForDefaultVat(Product product) {
            return GetGrossPrice(product.NetPrice, vatValue);
        }

        public decimal GetGrossPrice(decimal netprice, decimal vatValue){
                int SetPrecision = 4;
                return Math.Round(netprice * (1 + vatValue),SetPrecision);
        }
    }
}