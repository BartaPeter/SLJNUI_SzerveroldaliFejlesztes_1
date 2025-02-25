using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLJNUI_DunaVizallas.Data;
using SLJNUI_DunaVizallas.Entities.Dto;
using SLJNUI_DunaVizallas.Entities.Entity;
using System.Globalization;

namespace SLJNUI_DunaVizallas.EndPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VizallasController
    {
        DunaVizallasContext ctx;
        public VizallasController(DunaVizallasContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<VizallasViewDto> Get()
        {
            var stats = ctx.Vizallas
            .GroupBy(v => new { v.Date.Year, v.Date.Month })
            .Select(g => new
        {
            Year = g.Key.Year,
            Month = g.Key.Month,
            AverageValue = g.Average(v => v.Value),
            MinimalValue = g.Min(v => v.Value),
            MaximalValue = g.Max(v => v.Value)
        })
            .OrderBy(s => s.Year)
            .ThenBy(s => s.Month)
            .ToList();

            var vegleges = stats.Select(s => new VizallasViewDto
            {
                Month = string.Format("{0:D4}.{1:D2}", s.Year, s.Month),
                AverageValue = Math.Round(s.AverageValue, 2),
                MinimalValue = s.MinimalValue,
                MaximalValue = s.MaximalValue
            }).ToList();
            return vegleges;
        }
        [HttpPost]
        public void Post([FromBody]VizallasCreateUpdateDto dto)
        {
            var vizallas = new Vizallas()
            {
                Date = dto.GetParsedDate(),
                Value = dto.Value,
            };

            ctx.Vizallas.Add(vizallas);
            ctx.SaveChanges();

        }
    }
}
