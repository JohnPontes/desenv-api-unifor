using Microsoft.EntityFrameworkCore;
using playlistsAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace playlistsAPI.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        public readonly PlaylistContext _context;
        public PlaylistRepository(PlaylistContext context)
        {
            _context = context;
        }
        public async Task<Playlist> Create(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return playlist;
        }

        public async Task Delete(int id)
        {
            var playlistToDelete = await _context.Playlists.FindAsync(id);
            _context.Playlists.Remove(playlistToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Playlist>> Get()
        {
           return await _context.Playlists.ToListAsync();
        }

        public async Task<Playlist> Get(int id)
        {
            return await _context.Playlists.FindAsync(id);
        }

        public async Task Update(Playlist playlist)
        {
            _context.Entry(playlist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
