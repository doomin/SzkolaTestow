using System;
using System.Globalization;

namespace szkola_testow {

    public class VatService {
        decimal vatValue;

        public VatService(){
            this.vatValue = 0.23M;
        }

        public decimal GetGrossPriceForDefaultVat(Product product) {
            return GetGrossPrice(product.GetNetPrice(), vatValue);
        }

        public decimal GetGrossPrice(decimal netPrice, decimal vatValue){
                int SetPrecisiton = 4;
                return Math.Round(netPrice + (netPrice * vatValue),SetPrecisiton);
        }
    }
}