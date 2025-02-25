using SLJNUI_DunaVizallas.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_DunaVizallas.Entities.Dto
{
    public class VizallasViewDto
    {
        public string? Month { get; set; }
        public double AverageValue { get; set; }
        public int MinimalValue { get; set; }
        public int MaximalValue { get; set; }

    }
}
