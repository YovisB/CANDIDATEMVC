using System;
using System.Collections.Generic;

namespace MVCCANDIDATE.Models;

public partial class Candidate
{
    public int Idcandidate { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string Email { get; set; } = null!;

    public DateTime InsertDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<Candidateexperience> Candidateexperiences { get; set; } = new List<Candidateexperience>();
}
