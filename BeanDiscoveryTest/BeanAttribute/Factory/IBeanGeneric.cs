namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    interface IBeanGeneric<T> where T : class
    {
        string WhoAmI();
    }
}
