using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailerPark.Core.Models;

public class Movie
{
    [Key]
    public string? imdbID { get; set; }
    public string? Title { get; set; } = "";
    public string? TitleNormalized => Title?.ToUpper();
    public string? Year { get; set; }
    public float? Rated { get; set; }
    public DateTime? Released { get; set; } = DateTime.Now;
    public string? RuntimeMin { get; set; }
    public string? Genre { get; set; }
    public Person? Director { get; set; }
    public Person? Writer { get; set; }
    public List<Person>? Actors { get; set; }
    public string? Plot { get; set; }
    public string? LanguageISO { get; set; }
    public string? CountryISO { get; set; }
    public string? Awards { get; set; }
    public string? Poster { get; set; }
    //public List<Rating>? Ratings { get; set; }
    public string? Metascore { get; set; }
    public string? imdbRating { get; set; }
    public int? imdbVotes { get; set; }
    public string? Type { get; set; }
    public string? DVD { get; set; }
    //public string? BoxOffice { get; set; }
    public string? Production { get; set; }
    public string? Website { get; set; }
    public string? Response { get; set; }
}
