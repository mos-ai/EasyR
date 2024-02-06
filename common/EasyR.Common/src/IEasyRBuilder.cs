namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// A builder abstraction for configuring EasyR object instances.
/// </summary>
public interface IEasyRBuilder
{
    /// <summary>
    /// Gets the builder service collection.
    /// </summary>
    IServiceCollection Services { get; }
}
