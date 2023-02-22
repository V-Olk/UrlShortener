using System.Configuration;

namespace Volkin.UrlRedirector.DataAccess.Common.Exceptions;

[Serializable]
public class ConfigurationMissingException : ConfigurationErrorsException
{
    public ConfigurationMissingException(string message) : base(message)
    {
            
    }
}