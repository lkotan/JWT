using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Jwt.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder MapConfiguration(this ModelBuilder mb)
        {
            return mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static ModelBuilder SetDataType(this ModelBuilder mb)
        {
            foreach (var fk in mb.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var property in mb.Model.GetEntityTypes().SelectMany(t => t.GetProperties().OrderBy(x => x.Name)))
            {
                
                if (property.ClrType == typeof(bool))
                {
                    property.SetDefaultValue(false);
                }

                else if (property.ClrType == typeof(DateTime) && !property.IsNullable)
                {
                    property.SetDefaultValueSql("Convert(Date,GetDate())");
                }
                else if (property.ClrType == typeof(TimeSpan))
                {
                    property.SetDefaultValueSql("00:00:00");
                }

                switch (property.Name)
                {
                    case "Email":
                    case "FirstName":
                    case "LastName":
                        property.SetMaxLength(75);
                        break;

                    case "Title":
                    case "Name":
                    case "Description":
                        property.SetMaxLength(100);
                        break;
                }
            }
            return mb;
        }
    }
}
