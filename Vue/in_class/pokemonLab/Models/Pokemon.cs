using System;
using System.Collections.Generic;

#nullable disable

namespace pokemonLab.Models
{
    public partial class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public decimal Hp { get; set; }
        public decimal Attack { get; set; }
        public decimal Defanse { get; set; }
        public decimal SpAttack { get; set; }
        public decimal SpDefense { get; set; }
        public decimal Speed { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
    }
}
