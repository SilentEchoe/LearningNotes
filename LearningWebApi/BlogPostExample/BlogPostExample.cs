using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPostExample
{
    [TestFixture, Explicit, Category("Integration")]
    public class BlogPostExample
    {
        [SetUp]
        public void OnBeforeEachTest()
        {
            redis.FlushAll();
            InsertTestData();
        }
    }
}
