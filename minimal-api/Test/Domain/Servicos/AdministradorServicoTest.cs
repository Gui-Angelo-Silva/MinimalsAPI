using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private readonly IConfiguration _configuration;

        public AdministradorServicoTest()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _configuration = configurationBuilder;
        }

        [TestMethod]
        public void TestarSalvarAdministrador()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseNpgsql(connectionString)
                .Options;

            // Arrange
            var adm = new Administrador
            {
                Id = 1,
                Email = "test@test.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            // Act
            using (var context = new DbContexto(options))
            {
                context.Administradores.Add(adm);
                context.SaveChanges();
            }

            // Assert
            Assert.AreEqual(1, adm.Id);
            Assert.AreEqual("test@test.com", adm.Email);
            Assert.AreEqual("teste", adm.Senha);
            Assert.AreEqual("Adm", adm.Perfil);
        }
    }
}