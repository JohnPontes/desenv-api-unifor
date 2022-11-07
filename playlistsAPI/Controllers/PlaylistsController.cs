using Microsoft.AspNetCore.Mvc;
using playlistsAPI.Model;
using playlistsAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace playlistsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepository;
        public PlaylistsController(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Playlist>> GetPlaylists()
        {
            return await _playlistRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Playlist> GetPlaylists(int id)
        {
            return await _playlistRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylists([FromBody] Playlist playlist)
        {
            var newPlaylist = await _playlistRepository.Create(playlist);
            return CreatedAtAction(nameof(GetPlaylists), new { id = newPlaylist.Id }, newPlaylist);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var playlistToDelete = await _playlistRepository.Get(id);
            if (playlistToDelete == null)
                return NotFound();

            await _playlistRepository.Delete(playlistToDelete.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> PutPlaylists(int id, [FromBody] Playlist playlist)
        {
            if (id != playlist.Id)
                return BadRequest();

            await _playlistRepository.Update(playlist);
            return NoContent();
        }
    }
}
