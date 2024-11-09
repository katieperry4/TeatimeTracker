using TeaCapstone.Data;
using TeaCapstone.Models;

namespace TeaCapstone
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            if(!dbContext.TeaType.Any())
            {
                dbContext.TeaType.AddRange(
                    new TeaType {Name = "Black"},
                    new TeaType { Name = "Green"},
                    new TeaType { Name = "Herbal"}
                    );
                dbContext.SaveChanges();
            }
            if(!dbContext.TeaVariety.Any())
            {
                var blackTea = dbContext.TeaType.FirstOrDefault(t => t.Name == "Black");
                var blackTeaId = blackTea.Id;
                var greenTea = dbContext.TeaType.FirstOrDefault(t => t.Name == "Green");
                var greenTeaId = greenTea.Id;
                var herbalTea = dbContext.TeaType.FirstOrDefault(t => t.Name == "Herbal");
                var herbalTeaId = herbalTea.Id;

                dbContext.TeaVariety.AddRange(
                    new TeaVariety { Name = "English Breakfast", CaffeineContent = 55, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Irish Breakfast", CaffeineContent = 65, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Assam", CaffeineContent = 75, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Earl Grey", CaffeineContent = 55, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Chai", CaffeineContent = 60, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Lapsang Souchong", CaffeineContent = 55, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Darjeeling", CaffeineContent = 40, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Pu-Er", CaffeineContent = 50, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "Ceylon", CaffeineContent = 60, TeaType = blackTea, TeaTypeId = blackTeaId},
                    new TeaVariety { Name = "TGFOB", CaffeineContent = 60, TeaType = blackTea, TeaTypeId = blackTeaId},

                    new TeaVariety { Name = "Jasmine", CaffeineContent = 30, TeaType = greenTea, TeaTypeId = greenTeaId},
                    new TeaVariety { Name = "Sencha", CaffeineContent = 40, TeaType = greenTea, TeaTypeId = greenTeaId},
                    new TeaVariety { Name = "Genmaicha", CaffeineContent = 30, TeaType = greenTea, TeaTypeId = greenTeaId},
                    new TeaVariety { Name = "Gyokuro", CaffeineContent = 70, TeaType = greenTea, TeaTypeId = greenTeaId},
                    new TeaVariety { Name = "Matcha", CaffeineContent = 70, TeaType = greenTea, TeaTypeId = greenTeaId},
                    new TeaVariety { Name = "Hojicha", CaffeineContent = 20, TeaType = greenTea, TeaTypeId = greenTeaId},
                    new TeaVariety { Name = "Gunpowder", CaffeineContent = 40, TeaType = greenTea, TeaTypeId = greenTeaId},
                    new TeaVariety { Name = "White", CaffeineContent = 25, TeaType = greenTea, TeaTypeId = greenTeaId},
                    
                    new TeaVariety { Name = "Peppermint", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId},
                    new TeaVariety { Name = "Spearmint", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId},
                    new TeaVariety { Name = "Camomile", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId},
                    new TeaVariety { Name = "Lemon", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId},
                    new TeaVariety { Name = "Ginger", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId},
                    new TeaVariety { Name = "Lemon Ginger", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId},
                    new TeaVariety { Name = "Hibiscus", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId},
                    new TeaVariety { Name = "Rooibos", CaffeineContent = 0, TeaType = herbalTea, TeaTypeId = herbalTeaId}
                    );
            }
            dbContext.SaveChanges();
        }
    }
}
