using Microsoft.Extensions.Options;

namespace Blog.Core.Helpers.Abstract
{
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
    }
}
