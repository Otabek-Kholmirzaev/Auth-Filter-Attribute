﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Api.Entities;

public class UserEntity
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Phone { get; set; }

    public string Key { get; set; }

    [ForeignKey("UserEntityId")]
    public List<ProblemEntity> Problems { get; set; }
}
