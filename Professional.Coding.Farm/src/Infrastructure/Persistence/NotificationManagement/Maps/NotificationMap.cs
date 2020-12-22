using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Professional.Coding.Farm.Domain.NotificationManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Professional.Coding.Farm.Infrastructure.Persistence.NotificationManagement.Maps
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Version).IsRowVersion();
        }
    }
}
