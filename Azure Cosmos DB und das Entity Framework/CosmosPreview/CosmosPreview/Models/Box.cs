using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosPreview.Models
{
    /// <summary>
    /// Box-Entität
    /// </summary>
    class Box
    {
        public int BoxId { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// Navigationseigenschaft
        /// </summary>
        public Cat Cat { get; set; }
    }
}
