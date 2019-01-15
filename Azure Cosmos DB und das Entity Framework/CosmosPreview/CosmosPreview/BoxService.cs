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
    /// Kümmert sich um die Beschaffung und Speicherung von Boxen.
    /// </summary>
    class BoxService : BaseService<Box>
    {
        
        public BoxService(SchroedingerContext context): base(context)
        {

        }

        /// <summary>
        /// Liefert eine Box, mit eingeschlossener Katze, anhand der Farbe der Box.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Box> GetBoxByColor(string color)
        {
            Helper.PrintBlock(string.Format("Die Box wird in der Datenbank anhand der Farbe {0} gesucht.", color));

            // Linq Expression zum Suchen der Entität in der Datenbank.
            return Repository.SingleAsync(b => b.Color == color);
        }

        /// <summary>
        /// Liefert eine Box, mit eingeschlossener Katze, anhand der Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Box> GetBoxById(int id)
        {
            Helper.PrintBlock(string.Format("Die Box wird in der Datenbank anhand der Id {0} gesucht.", id.ToString()));

            // Linq Expression zum Suchen der Entität in der Datenbank.
            return Repository.SingleAsync(b => b.BoxId == id);
        }
    }
}
