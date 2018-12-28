using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pusher.Data.DomainModels;

namespace Pusher.Data.Configs
{
    public class UserDetailConfig : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }

}
