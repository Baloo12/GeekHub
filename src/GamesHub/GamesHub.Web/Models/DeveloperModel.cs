using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesHub.Web.Models
{
    public class DeveloperModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<GameModel> Games { get; set; }
    }
}
