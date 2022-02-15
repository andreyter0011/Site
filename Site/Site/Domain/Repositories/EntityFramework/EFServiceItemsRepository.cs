using Site.Domain.Entities;
using Site.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace Site.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.serviceItems;
        }
        public ServiceItem GetServiceItemByID(Guid id)
        {
            return context.serviceItems.FirstOrDefault(x => x.Id == id);
        }
        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteServiceItem(Guid id)
        {
            context.serviceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }
    }
}
