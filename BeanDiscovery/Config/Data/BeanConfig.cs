using BeanDiscovery.Data.Exceptions;

namespace BeanDiscovery.Config.Data
{
    public class BeanConfig
    {
        public string BeanName { get; protected set; }

        public bool ThrowExceptionIfNotFound { get; protected set; }

        public BeanConfig(string beanName, bool throwIfNotFound = false)
        {
            if (string.IsNullOrWhiteSpace(beanName))
                throw new EmptyBeanNameException();
            BeanName = beanName;
            ThrowExceptionIfNotFound = throwIfNotFound;
        }
    }
}
