using KristofferStrube.Blazor.WebIDL;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.CSSView;

/// <summary>
/// An element is an addressable node that can have attributes, a parent element, and child elements. It will be placed somewhere in the window if it is rendered.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/cssom-view-1/#extension-to-the-element-interface">See the API definition here</see>.</remarks>
public class Element : BaseJSWrapper
{
    /// <summary>
    /// Creates a <see cref="Element"/> from an existing <paramref name="elementReference"/>
    /// </summary>
    /// <param name="jSRuntime"><inheritdoc cref="IJSCreatable{T}.CreateAsync(IJSRuntime, IJSObjectReference)" path="/param[@name='jSRuntime']"/></param>
    /// <param name="elementReference">An element reference to create this <see cref="Element"/> wrapper from.</param>
    /// <returns></returns>
    public static async Task<Element> CreateAsync(IJSRuntime jSRuntime, ElementReference elementReference)
    {
        await using IJSObjectReference helper = await jSRuntime.GetHelperAsync();
        IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("getValueOf", elementReference);
        return new(jSRuntime, jSInstance, new() { DisposesJSReference = true });
    }

    /// <inheritdoc cref="IJSCreatable{T}.CreateAsync(IJSRuntime, IJSObjectReference, CreationOptions)"/>
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
