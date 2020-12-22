
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Professional.Coding.Farm.Domain.TodoManagement;

namespace Professional.Coding.Farm.Infrastructure.TodoManagement
{
    public class TodoItemMap : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");

            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.TodoList);
        }
    }
}
