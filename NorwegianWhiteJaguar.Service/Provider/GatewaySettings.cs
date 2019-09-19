using Conditions;
using NorwegianWhiteJaguar.Interface.Provider;

namespace NorwegianWhiteJaguar.Service.Provider
{
    public class GatewaySettings : IGatewaySettings
    {
        public GatewaySettings(string baseUri)
        {
            Condition.Requires(baseUri, nameof(baseUri)).IsNotNullOrEmpty();

            BaseUri = baseUri;
        }

        public string BaseUri { get; }
    }
}
