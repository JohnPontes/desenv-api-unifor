using playlistsAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace playlistsAPI.Repositories
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> Get();
        Task<Playlist> Get(int id);
        Task<Playlist> Create(Playlist playlist);
        Task Update(Playlist playlist);
        Task Delete(int Id);
    }
}
