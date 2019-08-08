namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    public class Tests
    {
        private Phone phone;
        [SetUp]
        public void Setup()
        {
            string make = "MadeTEST";
            string model = "ModelTEST";

            this.phone = new Phone(make, model);


            string name = "ContactName";
            string number = "ContactNumber";
            this.phone.AddContact(name, number);
        }
        [Test]
        public void Constructor_NOTReturnNullableObject()
        {
            string model = "Model";
            string made = "philips";
            Phone test = new Phone(model, made);
            Assert.IsNotNull(test);
        }
        [Test]
        public void Constructor_Model_NullValue_Throw_ArgumentException()
        {
            string model = string.Empty;
            string made = "philips";

            Assert.Throws<ArgumentException>(() =>  new Phone(model, made));
        }
        [Test]
        public void Constructor_Make_NullValue_Throw_ArgumentException()
        {
            string model = "TEST";
            string make = string.Empty;

            Assert.Throws<ArgumentException>(() => new Phone(model, make));
        }
        [Test]
        public void Property_Make_ReturnCorrectValue()
        {
            string expected = "MadeTEST";
       
            Assert.AreEqual(expected,this.phone.Make);
        }
        [Test]
        public void Property_Model_ReturnCorrectValue()
        {
            string expected = "ModelTEST";

            Assert.AreEqual(expected, this.phone.Model);
        }
        [Test]
        public void Property_Count_ReturnCorrectValue()
        {
            int expected = 1;

            Assert.AreEqual(expected, this.phone.Count);
        }
        [Test]
        public void Property_Count_AfterAdd_ReturnCorrectValue()
        {
            int expected = 2;

            string name = "ContactNameAdd";
            string number = "ContactNumberAdd";
            this.phone.AddContact(name, number);

            Assert.AreEqual(expected, this.phone.Count);
        }
        [Test]
        public void Add__WorkingCorrectValue()
        {
            int expected = 2;

            string name = "ContactNameAdd";
            string number = "ContactNumberAdd";
            this.phone.AddContact(name, number);

            Assert.AreEqual(expected, this.phone.Count);
        }
        [Test]
        public void Add__SameName_Throw_InvalidOperationException()
        { 
            string name = "ContactName";
            string number = "ContactNumberAdd";
          
            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact(name, number));
        }
        [Test]
        public void Call__NoExistingName_Throw_InvalidOperationException()
        {
            string name = "NoExistingName";

            Assert.Throws<InvalidOperationException>(() => this.phone.Call(name));
        }
        [Test]
        public void Call__WorkingCorrectly()
        {
            string expectResult= $"Calling ContactName - ContactNumber...";

            string name = "ContactName";
            string actual = this.phone.Call(name);

            Assert.AreEqual(expectResult, actual);
        }
    }
}