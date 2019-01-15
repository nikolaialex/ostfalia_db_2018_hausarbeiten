using CosmosPreview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosPreview
{
    class CatService: BaseService<Cat>
    {
        public CatService(SchroedingerContext context) : base(context)
        {

        }

        public Task<Cat> GetCatById(int id)
        {
            Helper.PrintBlock(string.Format("Die Katze wird in der Datenbank anhand der Id {0} gesucht.", id.ToString()));
            return Repository.SingleAsync(b => b.CatId == id);
        }

        public Task<Cat> GetCatByName(string name)
        {
            Helper.PrintBlock(string.Format("Die Katze wird in der Datenbank anhand des Namens {0} gesucht.", name));
            return Repository.SingleAsync(b => b.Name == name);
        }



    }
}
