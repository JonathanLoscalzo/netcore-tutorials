using System.Threading.Tasks;

namespace Csharp7_features.Features
{
    ///     Returning a Task object from async methods can introduce performance bottlenecks in certain paths. Task is a
    /// reference type, so using it means allocating an object. In cases where a method declared with the async modifier
    /// returns a cached result, or completes synchronously, the extra allocations can become a significant time cost in
    /// performance critical sections of code. It can become very costly if those allocations occur in tight loops
    /// Suerte de Wrapper para agregar comportamiento de Task a una variable simple
    public class ValueTaskFeature
    {
        /// The new language feature means that async methods may return other types in addition to Task , Task<T> and
        /// void . The returned type must still satisfy the async pattern, meaning a GetAwaiter method must be accessible. As
        /// one concrete example, the ValueTask type has been added to the .NET framework to make use of this new
        /// language feature:
        public async ValueTask<int> Func()
        {
            // simulate async work:
            await Task.Delay(100);
            return 5;
        }

        ///         A simple optimization would be to use ValueTask in places where Task would be used before. However, if you
        /// want to perform extra optimizations by hand, you can cache results from async work and reuse the result in
        /// subsequent calls. The ValueTask struct has a constructor with a Task parameter so that you can construct a
        /// ValueTask from the return value of any existing async method:
        public ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }
        private bool cache = false;
        private int cacheResult;
        private async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }
    }
}