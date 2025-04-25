// bu sınıf veritabanında ProductCategory tablosunu temsil etmektedir. eğer bu tablo manuel olarak yazılmasa bile zaten ef core otomatik oluşturur many to many ilişkisinden dolayı.
// fakat eğer bu tabloya ver eklemek istiyosak veya farklı manipülasyonlar yapmak isityosan (data seed gibi) manuel olarak uygulama tarafında bu sınıfı oluşturmamız gerekir. junk tablo olarak da adlandırılır.
namespace DataLayer.Concrete
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
      
        public int CategoryId { get; set; }
       
    }
}
