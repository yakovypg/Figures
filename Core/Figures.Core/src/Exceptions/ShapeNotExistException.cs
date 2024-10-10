using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Figures.Core.Exceptions;

[Serializable]
public class ShapeNotExistException : Exception
{
    public ShapeNotExistException() { }

    public ShapeNotExistException(string? message)
        : base(message) { }

    public ShapeNotExistException(string? message, Exception? innerException)
        : base(message, innerException) { }

    public ShapeNotExistException(string? message, string? shapeName)
        : this(message, shapeName, null) { }

    public ShapeNotExistException(
        string? message,
        string? shapeName,
        Exception? innerException)
        : base(message ?? GetDefaultMessage(shapeName), innerException)
    {
        ArgumentNullException.ThrowIfNull(shapeName, nameof(shapeName));
        ShapeName = shapeName;
    }

#if NET8_0_OR_GREATER
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
#endif
    protected ShapeNotExistException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        ArgumentNullException.ThrowIfNull(info, nameof(info));
        info.GetString(nameof(ShapeName));
    }

    public string? ShapeName { get; private set; }

#if NET8_0_OR_GREATER
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
#endif
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        ArgumentNullException.ThrowIfNull(info, nameof(info));

        info.AddValue(nameof(ShapeName), ShapeName, typeof(string));
        base.GetObjectData(info, context);
    }

    private static string GetDefaultMessage(string? shapeName)
    {
        shapeName ??= "Shape";
        return $"{shapeName} with specified parameters doesn't exist.";
    }
}
