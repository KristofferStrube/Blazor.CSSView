using KristofferStrube.Blazor.WebIDL;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.CSSView;

public class Element : BaseJSWrapper
{
    public static async Task<Element> CreateAsync(IJSRuntime jSRuntime, ElementReference elementReference)
    {
        await using IJSObjectReference helper = await jSRuntime.GetHelperAsync();
        IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("getValueOf", elementReference);
        return new(jSRuntime, jSInstance, new() { DisposesJSReference = true });
    }

    protected Element(IJSRuntime jSRuntime, IJSObjectReference jSReference, CreationOptions options) : base(jSRuntime, jSReference, options)
    {
    }

    /// <summary>
    /// Returns a new <see cref="DOMRect"/> that describes the smallest rectangle representing the element.
    /// </summary>
    /// <remarks>
    /// If the element is not displayed this method will return a new <see cref="DOMRect"/> with all zero-values.
    /// </remarks>
    public async Task<DOMRect> GetBoundingClientRectAsync()
    {
        return await JSReference.InvokeAsync<DOMRect>("getBoundingClientRect");
    }

    /// <summary>
    /// Gets the distance that the elements which this element resides in, has been scrolled.
    /// </summary>
    public async Task<double> GetScrollTop()
    {
        IJSObjectReference helper = await helperTask.Value;
        return await helper.InvokeAsync<double>("getAttribute", JSReference, "scrollTop");
    }
}
