using GRUPOSYM_ProjetoConverse.Fixtures;
using GRUPOSYM_ProjetoConverse.PageObjects;
using OpenQA.Selenium;
using System;
using Xunit;

namespace GRUPOSYM_ProjetoConverse
{
    [Collection ("Chrome Driver")]
    public class AutolacConverse
    {
        private IWebDriver driver;

        public AutolacConverse(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void EfetuaAgendamentoDeColetaDomiciliar()
        {
            //arrange
            var conversePO = new ConversePO(driver);
            conversePO.Visitar();

            //act
            conversePO.AgendarColeta();

            //assert
            Assert.Contains("Em breve um de nossos atendentes entrará em contato", driver.PageSource);
        }

        //[Fact]
        //public void EfetuaAgendamentoDeHorario()
        //{
        //    //arrange
        //    var conversePO = new ConversePO(driver);
        //    conversePO.Visitar();

        //    //act
        //    conversePO.AgendarHorario();

        //    //assert

        //}

        //[Fact]
        //public void EfetuaSolicitacaoDeOrcamento()
        //{
        //    //arrange

        //    //act

        //    //assert

        //}
    }
}
