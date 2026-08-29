using System;
using System.Collections.Generic;

namespace YesDhobi.Api.Models.DTOs
{
    public class CatalogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ServiceDto : CatalogDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal DefaultPrice { get; set; }
    }

    public class EquipmentDto : CatalogDto
    {
        public string Description { get; set; }
    }

    public class ServiceZoneDto
    {
        public int Id { get; set; }
        public string ZoneName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class WorkingDayDto
    {
        public int Id { get; set; }
        public string DayName { get; set; }
        public string DayCode { get; set; }
    }
}
