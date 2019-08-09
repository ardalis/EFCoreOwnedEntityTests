using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EFOwnedEntities
{
    public class IntegrationTests
    {
        public const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFOwnedEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private MyDbContext _dbContext;

        public IntegrationTests()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);

            _dbContext = new MyDbContext(builder.Options);
            _dbContext.Database.Migrate();
        }

        [Fact(Skip ="Only run this manually to seed the database")] 
        public void Seed()
        {
            var owner = new Owner { Name = "Steve" };
            _dbContext.Owners.Add(owner);
            _dbContext.SaveChanges();

            var monster = new Monster
            {
                Color = "Blue",
                Name = "Cramer",
                Limbs = new List<Limb>() { new Limb
                    {
                        Covering = "Fur",
                        Length = 2
                    }, new Limb
                    {
                        Covering = "Scales",
                        Length = 5
                    },
                },
                Owners = new List<Owner>() { owner}
            };
            _dbContext.Monsters.Add(monster);
            _dbContext.SaveChanges();
        }

        [Fact]
        public void GetMonsterPopulatesLimbs()
        {
            var monster = _dbContext.Monsters.FirstOrDefault();

            Assert.NotNull(monster.Limbs);
            Assert.Equal(2, monster.Limbs.Count);
        }

        [Fact]
        public void GetMonsterPopulatesLimbsWithInclude()
        {
            var monster = _dbContext.Monsters
                .Include(m => m.Limbs)
                .FirstOrDefault();

            Assert.NotNull(monster.Limbs);
            Assert.Equal(2, monster.Limbs.Count);

        }

        [Fact]
        public void GetMonsterDoesNotPopulatesOwners()
        {
            var monster = _dbContext.Monsters.FirstOrDefault();

            Assert.Null(monster.Owners);
        }

        [Fact]
        public void GetMonsterPopulatesOwnersWithInclude()
        {
            var monster = _dbContext.Monsters
                .Include(m => m.Owners)
                .FirstOrDefault();

            Assert.NotNull(monster.Owners);
            Assert.Single(monster.Owners);
        }
    }
}
