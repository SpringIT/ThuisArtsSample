using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;

namespace ThuisArtsSample
{
    public interface IThuisArtsApi
    {

        [Post("/user/login")]
        Task<Response<object>> Login([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> data);

        [Get("/rest/session/token")]
        Task<string> GetToken();

        [Header("X-CSRF-Token")]
        string Token { get; set; }

        [Get("/api/getSubjects")]
        Task<ThuisArtsSubjectResult> GetSubjects([Query] string _format);
    }
}