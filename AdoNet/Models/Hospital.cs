using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public class Hospital
    {
        public int HOSPITAL_COD { get; set; }
        public String NOMBRE { get; set; }
        public String DIRECCION { get; set; }
        public String TELEFONO { get; set; }
        public int NUM_CAMA { get; set; }
    }
}
