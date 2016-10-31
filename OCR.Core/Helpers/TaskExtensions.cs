using System.Threading.Tasks;

namespace OCR.Core.Helpers
{
    public static class TaskExtensions
    {
        public static readonly Task CompletedTask = Task.FromResult(false);
    }
}