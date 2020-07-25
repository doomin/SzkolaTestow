
namespace szkola_testow {

    public interface IVatProvider {

            decimal GetDefaultVat();
            decimal GetVatForType(string type);

    }
}