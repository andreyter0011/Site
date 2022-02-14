using Site.Domain.Entities;
using Site.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace Site.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<TextField> GetTextFields()
        {
            return context.textFields;
        }
        public TextField GetTextFieldByID(Guid id)
        {
            return context.textFields.FirstOrDefault(x => x.ID == id);
        }
        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.textFields.FirstOrDefault(x =>x.CodeWord == codeWord);
        }
        public void SaveTextField(TextField entity)
        {
            if (entity.ID == default)
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           context.SaveChanges();
        }
        public void DeleteTextField(Guid id)
        {
            context.textFields.Remove(new TextField() { ID = id });
            context.SaveChanges();
        }
    }
}
