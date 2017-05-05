using log4net;

namespace ProjectManager.Common
{
    public class FileLogger
    {
        private static ILog log;

        static FileLogger()
        {
            log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void Info(object message)
        {
            log.Info(message);
        }
                
        public void Error(object message)
        {
            log.Error(message);
        } 
               
        public void Fatal(object message)
        {
            log.Fatal(message);
        }
    }
}
