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
            var personInitializationMock = new Mock<PersonInitialization>();
            var dispA = new DispecerA(sursaDeDateMock.Object, personInitializationMock.Object);

            //act
            dispA.AddPerson();

            //assert
            sursaDeDateMock.Verify(v => v.add(It.IsAny<Persoana>()), Times.Exactly(1));
            personInitializationMock.Verify(v => v.CreatePerson(), Times.Exactly(1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenDispeceratWhenCallAddPersonAndGivenPersonAgeLess18ThenExeptionIsThrown()
        {
            //arrange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitializationMock = new Mock<PersonInitialization>();
            personInitializationMock.Setup(s => s.CreatePerson()).Returns(
                new Persoana()
                {
                    Nume = "Mock",
                    Prenume = "Mock",
                    Varsta = 17
                }
                );

            var dispA = new DispecerA(sursaDeDateMock.Object, personInitializationMock.Object);

            //act
            dispA.AddPerson();

            //assert
            sursaDeDateMock.Verify(v => v.add(It.IsAny<Persoana>()), Times.Exactly(1));
            personInitializationMock.Verify(v => v.CreatePerson(), Times.Exactly(1));
        }
    }
}