
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Professional.Coding.Farm.Domain.TodoManagement;

namespace Professional.Coding.Farm.Infrastructure.TodoManagement
{
    public class TodoListMap : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.ToTable("TodoLists");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Version).IsRowVersion();

            builder.HasMany(x => x.TodoItems)
                .WithOne(x => x.TodoList)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(b => b.Colour)
                            .Property(c => c.Code).HasColumnName("Colour");
        }
    }
}
