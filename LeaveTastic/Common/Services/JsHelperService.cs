using Microsoft.JSInterop;

namespace LeaveTastic.Common.Services
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class JsHelperService : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JsHelperService(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/LeaveTastic.Common/js/HelperScript.js").AsTask());
        }

        /// <summary>
        /// Return the height of element.
        /// </summary>
        /// <param name="elementIdentifier">
        /// The element identifier (e.g. .class, #id, body) of the element whose height we want.
        /// </param>
        /// <returns></returns>
        public async ValueTask<double> GetElementHeight(string elementIdentifier)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>("getElementHeight", elementIdentifier);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}