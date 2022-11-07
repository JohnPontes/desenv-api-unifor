using Microsoft.EntityFrameworkCore;

namespace playlistsAPI.Model
{
    public class PlaylistContext : DbContext
    {
        public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Playlist> Playlists { get; set; }
    }
}
