using System.Threading.Tasks;
using DotNetDeveloperTest.DTO;

namespace DotNetDeveloperTest.Services
{
    public interface IOrderItemsService
    {
        Task<short> AddAsync(int orderID, OrderItemDTO item);
        OrderItemsDTO Get(int orderID);
    }
}