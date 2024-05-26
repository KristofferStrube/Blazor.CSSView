using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.CSSView;

/// <summary>
/// Represents a rectangle in the current document whose attributes can only be read.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/geometry-1/#domrectreadonly">See the API definition here</see>.</remarks>
public class DOMRectReadOnly
{
    /// <summary>
    /// The horizontal distance between the viewport’s left edge and the rectangle’s origin.
    /// </summary>
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary>
    /// The vertical distance between the viewport’s top edge and the rectangle’s origin.
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }

    /// <summary>
    /// The width of the rectangle. Can be negative.
    /// </summary>
    [JsonPropertyName("width")]
    public double Width { get; set; }

    /// <summary>
    /// The height of the rectangle. Can be negative.
    /// </summary>
    [JsonPropertyName("height")]
    public double Height { get; set; }
}
