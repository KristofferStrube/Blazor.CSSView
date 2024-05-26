using KristofferStrube.Blazor.WebIDL;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.CSSView;

/// <summary>
/// The global object for a browser window with extensions provided from the CSSOM View Module standard.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/cssom-view-1/#extensions-to-the-window-interface">See the API definition here</see>.</remarks>
public class CSSViewWindow : Window.Window
{
    /// <summary>
    /// Creates a new <see cref="CSSViewWindow"/> created from a <see cref="Window.Window"/>.
    /// It uses the same underlying JS reference so if the input <paramref name="window"/> is disposed then this instance created from that should also be disposed. 
    /// </summary>
    /// <param name="window">An existing <see cref="Window.Window"/>.</param>
    public Task<CSSViewWindow> CreateAsync(Window.Window window)
    {
        return Task.FromResult(new CSSViewWindow(window));
    }

    /// <inheritdoc cref="CreateAsync(Window.Window)"/>
    public CSSViewWindow(Window.Window window) : base(window.JSRuntime, window.JSReference, new())
    {
    }

    /// <inheritdoc cref="IJSCreatable{T}.CreateAsync(IJSRuntime, IJSObjectReference, CreationOptions)"/>
    protected CSSViewWindow(IJSRuntime jSRuntime, IJSObjectReference jSReference, CreationOptions options) : base(jSRuntime, jSReference, options)
    {
    }
}
