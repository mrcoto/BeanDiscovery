﻿using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Data;
using MrCoto.BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace MrCoto.BeanDiscoveryTest.Data
{
    public class BeanDataTest
    {
        [Fact]
        public void Test_Should_Give_Correct_BeanData_Values()
        {
            var beanData = new BeanData(typeof(BeanScoped));
            Assert.Equal(typeof(BeanScoped), beanData.TBean);
            Assert.Equal(ScopeType.SCOPED, beanData.Scope);
            Assert.Equal("Primary", beanData.BeanName);
        }


    }
}
