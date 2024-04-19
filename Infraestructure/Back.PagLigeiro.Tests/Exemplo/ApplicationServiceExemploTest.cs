//using AutoFixture;
//using AutoMapper;
//using Back.PagLigeiro.Application;
//using Back.PagLigeiro.Application.Dtos.Exemplo;
//using Back.PagLigeiro.Domain.Core.Interfaces.Services;
//using Back.PagLigeiro.Domain.Entities.Exemplo;
//using Moq;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Linq;

//namespace Back.PagLigeiro.Tests.Exemplo
//{
//    [TestFixture]
//    class ApplicationServiceExemploTest
//    {

//        private static Fixture _fixture;
//        private Mock<IServiceExemplo> _serviceExemploMoq;
//        private Mock<IMapper> _mapMoq;

//        [SetUp]
//        public void Setup()
//        {
//            _fixture = new Fixture();
//            _serviceExemploMoq = new Mock<IServiceExemplo>();
//            _mapMoq = new Mock<IMapper>();


//        }


//        [Test]
//        public void CriarExemplos()
//        {

//        }

//        [Test]
//        public void EditarExemplos()
//        {

//        }

//        [Test]
//        public void Listar()
//        {
//            var exemplos = _fixture.Build<ExemploEntidade>().CreateMany(3).ToList();
//            var exemplosDto = _fixture.Build<ExemploDto>().CreateMany(3).ToList();

//            _serviceExemploMoq.Setup(x => x.GetAll()).Returns(exemplos);

//            _mapMoq.Setup(x => x.Map<List<ExemploDto>>(exemplos)).Returns(exemplosDto);
//            var appServiceProduto = new ApplicationServiceExemplo(_serviceExemploMoq.Object, _mapMoq.Object);

//            var result = appServiceProduto.GetAll();

//            Assert.IsNotNull(result);
//            Assert.AreEqual(3, result.Count);
//        }

//        [Test]
//        public void Excluir()
//        {

//        }
//    }
//}
