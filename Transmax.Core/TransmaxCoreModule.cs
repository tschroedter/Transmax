using System.Diagnostics.CodeAnalysis;
using Autofac;
using JetBrains.Annotations;
using Transmax.Core.Csv;
using Transmax.Core.Interfaces;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class TransmaxCoreModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType <InputFile>().As <IInputFile>();
            builder.RegisterType <OutputFile>().As <IOutputFile>();
            builder.RegisterType <LinqGrader>().As <IGrader>();
            builder.RegisterType <GradeRunner>().As <IGradeRunner>();
            builder.RegisterType <ApplicationMode>().As <IApplicationMode>();
            builder.RegisterType <TransmaxFile>().As <ITransmaxFile>();
        }
    }
}