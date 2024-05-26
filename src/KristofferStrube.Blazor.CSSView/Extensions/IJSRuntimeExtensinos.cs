using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.CSSView;

internal static class IJSRuntimeExtensions
{
    internal static async Task<IJSObjectReference> GetHelperAsync(this IJSRuntime jSRuntime)
    {
        return await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/KristofferStrube.Blazor.CSSView/KristofferStrube.Blazor.CSSView.js");
    }
}