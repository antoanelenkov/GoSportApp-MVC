using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Services.Contracts
{
    public interface IMessageService
    {
        bool UpdateById(int id, string content);

        bool DeleteById(int id);
    }
}
