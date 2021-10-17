using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ProjetPourTU.Services;
using ProjetPourTU.Model;
using ProjetPourTU.Services.CustomExceptions;
using Moq;
using System.Linq;

namespace ProjetPourTU.test
{
    class VehiculeServiceTest
    {
        private List<Vehicule> _mesVehicules;
        private VehiculeService vehiculeService;


        [SetUp]
        public void Setup()
        {
            var _mkV = new Mock<VehiculeService>();
            _mkV.Setup(s => s.Save());
            _mkV.Setup(s => s.getAll()).Returns(() => _mesVehicules = new List<Vehicule> {
                new Vehicule() { ID = 1, Immatriculation = "AAA", Nom = "Peugeot 308" },
                new Vehicule() { ID = 2, Immatriculation = "BBB", Nom = "Toyota Aygo" },
                new Vehicule() { ID = 3, Immatriculation = "CCC", Nom = "Renault Clio" }
            });
            this.vehiculeService = _mkV.Object;
        }

        [TestCase(1, "AAA")]
        [TestCase(2, "BBB")]
        [TestCase(3, "CCC")]
        public void getByIdTest(int ID, string excpected)
        {
            Vehicule result = vehiculeService.getByID(ID);
            Assert.AreEqual(excpected, result.Immatriculation);
        }

        [Test]
        public void getByIdInvalidExceptionTest()
        {
            Assert.Throws<InvalidIDException>(() => vehiculeService.getByID(0));
        }

        [Test]
        public void getByIdNotFoundExceptionTest()
        {
            Assert.Throws<VehiculeNotFoundException>(() => vehiculeService.getByID(5));
        }

        [Test]
        public void AddVehiculeTest()
        {
            Vehicule v = new Vehicule() { ID = 4, Immatriculation = "DDD", Nom = "Test" };
            vehiculeService.AddVehicule(v);
            Assert.AreEqual(_mesVehicules[3], v);
        }

        [Test]
        public void AddVehiculeExceptionNullTest()
        {
            Assert.Throws<NullNotAllowedException>(() => vehiculeService.AddVehicule(null));
        }

        [Test]
        public void AddVehiculeExceptionSameIDTest()
        {
            Vehicule v = new Vehicule() { ID = 2, Immatriculation = "DDD", Nom = "Test" };
            Assert.Throws<SameIDExistsException>(() => vehiculeService.AddVehicule(v));
        }

        [Test]
        public void CreerMessagePourUnVehiculeTest()
        {
            Vehicule v = new Vehicule() { ID = 2, Immatriculation = "DDD", Nom = "Test" };
            string m = vehiculeService.CreerMessagePourUnVehicule(v);
            Assert.AreEqual("Véhicule : Test, immatriculation : DDD", m);
        }

        [Test]
        public void CreerMessageTest()
        {
            string m = vehiculeService.CreerMessage();
            Assert.AreEqual("Véhicule : Peugeot 308, immatriculation : AAA\nVéhicule : Toyota Aygo, immatriculation : BBB\nVéhicule : Renault Clio, immatriculation : CCC", m);
        }

        [Test]
        public void searchByIDTest()
        {

            Vehicule result = vehiculeService.searchByID(1);
            Assert.AreEqual(_mesVehicules[0], result);
        }
    }
}
