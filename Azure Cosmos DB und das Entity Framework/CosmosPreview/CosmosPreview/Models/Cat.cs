using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosPreview.Models
{
    /// <summary>
    /// Katzen-Entität
    /// </summary>
    class Cat
    {
        public int CatId { get; set; }

        public string Name { get; set; }
        public bool IsAlive { get; set; }

        public int BoxId { get; set; }
        
        /// <summary>
        /// Navigationseigenschaft
        /// </summary>
        public Box Box { get; set; }
    }
}
