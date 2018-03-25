using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Reflection;

namespace WickedFramework.Logger
{
    /// <summary>
    /// Assembly configurator for Log4Net configuration.
    /// Add [assembly: ApplicationName.Configuration] to startup class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class Configuration : ConfiguratorAttribute
    {
        private const string LogPattern = "%date [%thread] %-5level | %logger - %message%newline";

        public Configuration() : base(0)
        {
        }

        public override void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository)
        {
            var hierarchy = (Hierarchy)targetRepository;
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = LogPattern;
            patternLayout.ActivateOptions();

            var roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = $@"Logs\EventLog_{DateTime.Now.ToString("yyyyMMdd")}.txt";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 10;
            roller.MaximumFileSize = "10MB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Composite;
            roller.StaticLogFileName = false;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            var memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }
    }
}
