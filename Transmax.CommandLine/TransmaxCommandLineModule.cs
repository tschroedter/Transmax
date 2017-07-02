using System.Diagnostics.CodeAnalysis;
using Autofac;
using JetBrains.Annotations;
using Transmax.CommandLine.Interfaces;

namespace Transmax.CommandLine
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TransmaxCommandLineModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType <CommandLineParser>().As <ICommandLineParser>();
        }
    }
}