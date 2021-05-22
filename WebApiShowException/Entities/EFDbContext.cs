using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShowException.Entities.Identities;

namespace WebApiShowException.Entities
{
    public class EFDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>,
        AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public EFDbContext(DbContextOptions opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRoles => {
                userRoles.HasKey(primaryKeys => new { primaryKeys.RoleId, primaryKeys.UserId });

                userRoles.HasOne(virtualElementForEntityWithCollection => virtualElementForEntityWithCollection.Role)
                .WithMany(virtualCollectionWithEntityToEntity => virtualCollectionWithEntityToEntity.UserRoles)
                .HasForeignKey(intColumnWithForeignKeySettings => intColumnWithForeignKeySettings.RoleId)
                .IsRequired();

                userRoles.HasOne(virtualElementForEntityWithCollection => virtualElementForEntityWithCollection.User)
                .WithMany(virtualCollectionWithEntityToEntity => virtualCollectionWithEntityToEntity.UserRoles)
                .HasForeignKey(intColumnWithForeignKeySettings=> intColumnWithForeignKeySettings.UserId)
                .IsRequired();
            });
        }

        public DbSet<AppCar> Cars { get; set; }
    }
}
