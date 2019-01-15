using CosmosPreview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosPreview
{
    /// <summary>
    /// Kümmert sich um die Beschaffung und Speicherung von Katzen.
    /// </summary>
    class CatService : BaseService<Cat>
    {
        public CatService(SchroedingerContext context) : base(context)
        {

        }

        /// <summary>
        /// Liefert eine Katze und die Box, in der sie eingeschlossen ist, anhand der Id der Katze.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Cat> GetCatById(int id)
        {
            Helper.PrintBlock(string.Format("Die Katze wird in der Datenbank anhand der Id {0} gesucht.", id.ToString()));

            // Linq Expression zum Suchen der Entität in der Datenbank.
            return Repository.SingleAsync(b => b.CatId == id);
        }

        /// <summary>
        /// Liefert eine Katze und die Box, in der sie eingeschlossen ist, anhand des Namens der Katze.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<Cat> GetCatByName(string name)
        {
            Helper.PrintBlock(string.Format("Die Katze wird in der Datenbank anhand des Namens {0} gesucht.", name));

            // Linq Expression zum Suchen der Entität in der Datenbank.
            return Repository.SingleAsync(b => b.Name == name);
        }



    }
}
