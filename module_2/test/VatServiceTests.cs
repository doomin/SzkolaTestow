using NUnit.Framework;
using System;
using FluentAssertions;
using Moq;

namespace szkola_testow {
    public class VatServiceTests {

        private VatService vatService;
        private Mock<IVatProvider> mockVatProvider;
        
        [SetUp]
        public void PrepareVatService(){
           mockVatProvider = new Mock<IVatProvider>();
           vatService = new VatService(mockVatProvider.Object); 
        }

        [Category("module2")]
        [TestCase(20.00, TestName="Should return gross price of a product for default VAT - 23%")]
        public void ShouldReturnProductGrossPriceForDefaultVat(decimal price){
            
            //given           
            mockVatProvider.Setup(x => x.GetDefaultVat()).Returns(0.23M);                                      
            Product product = GenerateProductwithPriceAndType(price, "clothes");

            //when
            decimal result = vatService.GetGrossPriceForDefaultVat(product);

            //then
            result.Should().Be(24.60M);
        }


        [Category("module2")]
        [TestCase(0.08, 10.00, "clothes", TestName="Should return gross price of a product for provided VAT - 8%")]
        public void ShouldReturnProductGrossPriceForProvidedVat(decimal vat, decimal price, string productType){
            //given
            mockVatProvider.Setup(x => x.GetVatForType(productType)).Returns(vat);           
            Product product = GenerateProductwithPriceAndType(price, productType);

            //when
            decimal result = vatService.GetGrossPrice(product.NetPrice, productType);

            //then
            result.Should().Be(10.80M);
        }

        
        [Category("module2")]
        [TestCase(1.2, 10.00, "clothes", TestName="Should throw exception when provided VAT is too high")]
        public void ShouldThrowExceptionWhenVatTooHigh(decimal vat, decimal price, string productType){
            //given
            mockVatProvider.Setup(x => x.GetVatForType(productType)).Returns(vat);
            Product product = GenerateProductwithPriceAndType(price, productType);

            //when
            
            //then
            Action act = () => {
                vatService.GetGrossPrice(product.NetPrice, productType);
                };

            act.Should().Throw<Exception>()                    
                    .WithMessage("VAT needs to be lower!");

        }

        [Category("module2")]
        [TestCase(-2.3, 10.00, "clothes",TestName="Should throw exception when provided VAT is below 0")]
        public void ShouldThrowExceptionWhenVatBelowZero(decimal vat, decimal price, string productType){
            //given
            mockVatProvider.Setup(x => x.GetVatForType(productType)).Returns(vat);
            Product product = GenerateProductwithPriceAndType(price, productType);

            //when
            
            //then
            Action act = () => {
                vatService.GetGrossPrice(product.NetPrice, productType);
                };

            act.Should().Throw<Exception>()                    
                    .WithMessage("VAT cannot be a negative numer!");

        }

        [Category("module2")]
        [TestCase(0, 10.00, "clothes", TestName="Should return net price of a product when VAT provided is 0%")]
        public void ShouldReturnProductNetPriceForProvidedVat(decimal vat, decimal price, string productType){
            //given
            mockVatProvider.Setup(x => x.GetVatForType(productType)).Returns(vat);             
            Product product = GenerateProductwithPriceAndType(price, productType);

            //when
            decimal result = vatService.GetGrossPrice(product.NetPrice, productType);

            //then
            result.Should().Be(price);
        }

        private Product GenerateProductwithPriceAndType(decimal price, string productType){
            var rnd = new Random();
            int id = rnd.Next(); 
            
            Product product = new Product(id, price, productType);
            product.NetPrice = price;
            return product;
        }
    }
}

