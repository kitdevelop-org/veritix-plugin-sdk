namespace Veritix.Plugin.SDK.Localization;

/// <summary>
/// Provee acceso a la linguística regional y personalizada dentro de un plugin.
/// </summary>
public interface IVtxLocalizer
{
    /// <summary>
    /// Traduce una clave usando el locale del tenant actual, con soporte para 
    /// regionalismos y personalización del cliente.
    /// </summary>
    string this[string key] { get; }

    /// <summary>
    /// Traduce una clave con formato de parámetros.
    /// </summary>
    string T(string key, params object[] args);

    /// <summary>
    /// Devuelve el código de cultura activo (ej: es-DO).
    /// </summary>
    string CurrentLocale { get; }
}
