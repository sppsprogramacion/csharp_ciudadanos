using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IAuthDao
    {
        Task<HttpResponseMessage> LoginUsuario(string prohibicionVisita);
    }
}
