using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using Absolute_Cinema_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Absolute_Cinema_Backend.Dto
{
    public class QueryDto
    {
        [FromQuery(Name = "startdate")]
        public DateTime? StartDate { get; set; }
        [FromQuery(Name = "enddate")]
        public DateTime? EndDate { get; set; }
        [FromQuery(Name = "sessiontypes")]
        public List<string>? SessionTypes { get; set; }
        [FromQuery(Name = "languages")]
        public List<string>? Languages { get; set; }
        [FromQuery(Name = "subtitles")]
        public List<string>? Subtitles { get; set; }
        [FromQuery(Name = "genres")]
        public List<string>? Genres { get; set; }
        [FromQuery(Name = "resolutions")]
        public List<string>? Resolutions { get; set; }
        public QueryDto() 
        {
        }
        public QueryDto(DateTime? startDate, DateTime? endDate, List<string>? sessionTypes, List<string>? languages, List<string>? subtitles, List<string>? genres, List<string>? resolutions)
        {
            StartDate = startDate;
            EndDate = endDate;
            SessionTypes = sessionTypes;
            Languages = languages;
            Subtitles = subtitles;
            Genres = genres;
            Resolutions = resolutions;
        }
    }
}
