using log4net.Config;
using log4net.Core;
using log4net;
using System.Reflection;
using System.Xml;

namespace ECommerce.API.AppLogger
{
    public class LoggerEcommerce:ILoggerEcommerce
    {
 

        
            //Initialize Built-in-type with User Defined Type
            private readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));

            public LoggerEcommerce()
            {
                try
                {
                    XmlDocument xmlConfigFile = new XmlDocument();

                    using (var fs = File.OpenRead("log4net.config"))
                    {
                        //Loading the configuration file
                        xmlConfigFile.Load(fs);

                        //Creating LogManager repository
                        var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(LogManager));

                        //Creating Configurator
                        XmlConfigurator.Configure(repo, xmlConfigFile["log4net"]);

                        //Leaving Very first message
                        _logger.Info("Log System Initialized");

                    }

                }
                catch (Exception ex)
                {
                    _logger.Error("Error", ex);
                }
            }

            public void RecordLogInformation(string message)
            {
                _logger.Info(message);
            }
        }
    }



