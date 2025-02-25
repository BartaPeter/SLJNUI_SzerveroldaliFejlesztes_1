using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SLJNUI_DunaVizallas.Entities.Dto
{
    public class VizallasCreateUpdateDto
    {
        public string? Date { get; set; }
        public int Value { get; set; }
        public DateTime GetParsedDate()
        {
            if (!DateTime.TryParseExact(Date, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new FormatException("Hibás dátum formátum!");
            }
            return parsedDate.Date;
        }
    }
}
