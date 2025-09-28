using AutoMapper;
using WebApplication3.Models;


namespace WebApplication3
{
    public class Red
    {
        ApplicationContext db;
        public Red(ApplicationContext context)
        {
            db = context;

            Doc doc = new Doc { professtion = "Анестезиолог", Name = "Иван Иванович" };          
            Doc doc1 = new Doc { professtion = "Хирург", Name = "Данил Данилович" };
            Doc doc2 = new Doc { professtion = "Стоматолог", Name = "Максим Максимович" };
            Doc doc3 = new Doc { professtion = "Анестезиолог", Name = "Кирилл Кириллович" };
            Doc doc4 = new Doc { professtion = "Терапевт", Name = "Александр Александрович" };
            Doc doc5 = new Doc { professtion = "Акушер", Name = "Тимофей Тимофеевич" };
            Doc doc6 = new Doc { professtion = "Травматолог", Name = "Артем Артемаович" };
            db.Docs.AddRange(doc, doc1,  doc2, doc3, doc4, doc5, doc6);
            db.SaveChanges();

        }



    }
}
