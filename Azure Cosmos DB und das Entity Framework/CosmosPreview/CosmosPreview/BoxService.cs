using CosmosPreview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosPreview
{
    class BoxService : BaseService<Box>
    {

        public BoxService(SchroedingerContext context): base(context)
        {

        }

        public Task<Box> GetBoxByColor(string color)
        {
            Helper.PrintBlock(string.Format("Die Box wird in der Datenbank anhand der Farbe {0} gesucht.", color));
            return Repository.SingleAsync(b => b.Color == color);
        }

        public Task<Box> GetBoxById(int id)
        {
            Helper.PrintBlock(string.Format("Die Box wird in der Datenbank anhand der Id {0} gesucht.", id.ToString()));
            return Repository.SingleAsync(b => b.BoxId == id);
        }
    }
}
