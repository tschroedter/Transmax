using System.Diagnostics.CodeAnalysis;
using Autofac;
using JetBrains.Annotations;
using Transmax.Common.Interfaces;

namespace Transmax.Common
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TransmaxCommonModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransmaxLogger>().As<ITransmaxLogger>();
            builder.RegisterType<TransmaxConsole>().As<ITransmaxConsole>();
        }
    }
}