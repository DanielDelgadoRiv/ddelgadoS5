using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ddelgadoS5.Models
{
    [Table ("persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
