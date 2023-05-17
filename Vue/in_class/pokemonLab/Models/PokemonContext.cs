using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace pokemonLab.Models
{
    public partial class PokemonContext : DbContext
    {
        public PokemonContext()
        {
        }

        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_BIN");

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.ToTable("Pokemon");

                entity.Property(e => e.Attack).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Defanse).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Hp).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NickName).HasMaxLength(200);

                entity.Property(e => e.SpAttack).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SpDefense).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Speed).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasData(
                    new Pokemon() { Id = 1, Name = "妙蛙種子", NickName = "哇草", Hp = 45, Attack = 49, Defanse = 49, SpAttack = 65, SpDefense = 65, Speed = 45, Type = "種子寶可夢", Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/detail/001.png" },
                    new Pokemon() { Id = 2, Name = "妙蛙草", NickName = "哇草哇草", Hp = 60, Attack = 62, Defanse = 63, SpAttack = 80, SpDefense = 80, Speed = 60, Type = "種子寶可夢", Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/detail/002.png" },
                    new Pokemon() { Id = 8, Name = "皮卡丘", NickName = "皮皮", Hp = 35, Attack = 55, Defanse = 40, SpAttack = 55, SpDefense = 50, Speed = 90, Type = "鼠寶可夢", Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/detail/025.png" }
                );
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
