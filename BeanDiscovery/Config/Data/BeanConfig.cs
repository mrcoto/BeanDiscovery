namespace BeanDiscovery.Config.Data
{
    public class BeanConfig
    {
        public string BeanName { get; protected set; }

        public bool ThrowExceptionIfNotFound { get; protected set; }

        public BeanConfig(string beanName, bool throwIfNotFound = false)
        {
            BeanName = beanName;
            ThrowExceptionIfNotFound = throwIfNotFound;
        }
    }
}
