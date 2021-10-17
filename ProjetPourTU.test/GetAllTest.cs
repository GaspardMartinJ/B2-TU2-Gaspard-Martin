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
    class GetAllTest
    {
        private List<Vehicule> _mesVehicules;
        private VehiculeService vehiculeService;


        [SetUp]
        public void Setup()
        {
            _mesVehicules = new List<Vehicule>();
            this.vehiculeService = new VehiculeService();
        }

        [Test]
        public void getAllTest()
        {
            List<Vehicule> v = vehiculeService.getAll();
            Assert.AreEqual(_mesVehicules, v);
        }
    }
}
