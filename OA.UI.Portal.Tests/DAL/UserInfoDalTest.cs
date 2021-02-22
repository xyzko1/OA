using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OA.EFDAL;
using OA.Model;
using System.Linq;

namespace OA.UI.Portal.Tests.DAL
{
    /// <summary>
    /// UserInfoDalTest 的摘要说明
    /// </summary>
    [TestClass]
    public class UserInfoDalTest
    {
        public UserInfoDalTest()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetUsers()
        {
            //
            // TODO:  在此处添加测试逻辑
            //
            //测试  获取数据的方法
            UserInfoDal dal = new UserInfoDal();
            //单元测试必须自己处理数据，不能依赖第三方数据。如果依赖数据那么先自己创建数据，测试完成后清除
            for (int i = 0; i < 10; i++)
            {
                dal.Add(new UserInfo() {
                    UName= i + "号"
                });
            }
            //IQueryable<UserInfo> temp =dal.GetUsers(u=>u.UName.Contains("号"));
            IQueryable<UserInfo> temp = dal.GetEntities(u => u.UName.Contains("号"));
            //断言
            Assert.AreEqual(true, temp.Count()> 10);//前面参数为期望值，后面为实际值
           
        }
    }
}
