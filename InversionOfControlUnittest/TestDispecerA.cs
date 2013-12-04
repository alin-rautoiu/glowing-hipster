using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using InversionOfControlExemple;

namespace InversionOfControlUnittest
{
    [TestClass]
    public class TestDispecerA
    {
        [TestMethod]
        public void GivenDispeceratWhenCallAddPersonThenTheMethodAddFromISursaDeDateIsCalled()
        {
            //arrange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var dispA = new DispecerA(sursaDeDateMock.Object);

            //act
            dispA.AddPerson();

            //assert
            sursaDeDateMock.Verify(v => v.add(It.IsAny<Persoana>()), Times.Exactly(1));
        }
    }
}