using MrCoto.BeanDiscovery.Data.Exceptions;

namespace MrCoto.BeanDiscovery.Config.Data
{
    /// <summary>
    /// This class specify how a bean will be resolved,
    /// based on a BeanName.
    /// Also, you can set a exception thrown if no bean is found
    /// </summary>
    public class BeanConfig
    {
        /// <summary>
        /// Name of the bean to be resolved
        /// </summary>
        public string BeanName { get; protected set; }

        /// <summary>
        /// If true, the program should throw an exception
        /// </summary>
        public bool ThrowExceptionIfNotFound { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="beanName">Name or identifier of Bean to be resolved</param>
        /// <param name="throwIfNotFound">Should throw exception if bean resolved not found?</param>
        public BeanConfig(string beanName, bool throwIfNotFound = false)
        {
            if (string.IsNullOrWhiteSpace(beanName))
                throw new EmptyBeanNameException();
            BeanName = beanName;
            ThrowExceptionIfNotFound = throwIfNotFound;
        }
    }
}
