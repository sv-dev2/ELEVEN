using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Model
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string formName { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string WindowState { get; set; }
        public string formUniqueName { get; set; }
        public int WorkspaceId { get; set; }

    }

    public class WorkspaceModel
    {
        public int Id { get; set; }
        public string WorkspaceName { get; set; }
    }
}
