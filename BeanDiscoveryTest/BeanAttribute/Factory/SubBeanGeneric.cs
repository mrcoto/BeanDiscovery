using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    /**
     * Usually there is a ICrudRepository and a CrudRepository implementation
     * and, for example:
     * ITodoRepository : ICrudRepository
     * {
     * }
     * TodoRepository : CrudRepository&lt;TodoEntity&gt;, ITodoRepository
     * {
     * 
     * }
     * to generate reusable code.
     * This class simulates that.
     * */
    [Bean]
    class SubBeanGeneric : BeanGeneric<BeanScoped>, ISubBeanGeneric
    {
    }
}
