using System;
using DotNetCore.CAP.Diagnostics;

namespace OpenTracing.Contrib.CAP
{
    public class CapDiagnosticOptions
    {
        public const string DefaultComponent = "CAP";

        private string _componentName = DefaultComponent;
        private Func<BrokerEventData, string> _operationNameResolver;

        /// <summary>
        /// Allows changing the "component" tag of created spans.
        /// </summary>
        public string ComponentName
        {
            get => _componentName;
            set => _componentName = value ?? throw new ArgumentNullException(nameof(ComponentName));
        }

        /// <summary>
        /// A delegates that defines on what requests tracing headerses are propagated.
        /// </summary>
        public Func<BrokerEventData, bool> InjectEnabled { get; set; }

        public Action<ISpan, BrokerEventData> OnRequest { get; set; }

        /// <summary>
        /// A delegate that returns the OpenTracing "operation name" for the given command.
        /// </summary>
        public Func<BrokerEventData, string> OperationNameResolver
        {
            get
            {
                if (_operationNameResolver == null)
                {
                    // Default value may not be set in the constructor because this would fail
                    // if the target application does not reference EFCore.
                    _operationNameResolver = (data) => "EventBus " + data.BrokerTopicName;
                }
                return _operationNameResolver;
            }
            set => _operationNameResolver = value ?? throw new ArgumentNullException(nameof(OperationNameResolver));
        }
    }
}
