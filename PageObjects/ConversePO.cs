using GRUPOSYM_ProjetoConverse.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace GRUPOSYM_ProjetoConverse.PageObjects
{
    public class ConversePO
    {
        private IWebDriver driver;
        private By byBtnColeta;
        //private By byBtnHorario;
        //private By byBtnOrcamento;
        private By byInputTexto;
        private By byBtnSendTexto;
        private By byInputMasked;
        private By byBtnSendMasked;
        private By byFileInput;
        private By byBtnSendForm;
        private By byInputDate;
        private By byBtnParticular;
        private By byGuiasFileInput;
        private By byInputEstado;
        private By byBtnObsSim;
        private By byBtnCheckWhatsApp;
        private By byBtnFinish;

        public ConversePO(IWebDriver driver)
        {
            this.driver = driver;
            byBtnColeta = By.XPath("//button[1]/span");
            //byBtnHorario = By.XPath("//button[2]/span");
            //byBtnOrcamento = By.XPath("//button[3]/span");
            byInputTexto = By.Id("inputTexto");
            byBtnSendTexto = By.XPath("//*[@id='sendMessage']/span/i");
            byInputMasked = By.Id("inputMasked");
            byBtnSendMasked = By.XPath("//*[@id='btnSendMasked']/span/i");
            byFileInput = By.Id("input-59");
            byBtnSendForm = By.XPath("//div[2]/button/span/i");
            byInputDate = By.XPath("//div[2]/div/div/input");
            byBtnParticular = By.Id("btnParticular");
            byGuiasFileInput = By.Id("input-98");
            byInputEstado = By.Id("input-126");
            byBtnObsSim = By.Id("btnObsSim");
            byBtnCheckWhatsApp = By.XPath("//footer/form/div[2]/div[1]/div/div[1]/div/div[1]/div/div");
            byBtnFinish = By.Id("btnFinish");
        }

        public void Visitar()
        {
            //Visita a página do Autolac Converse e aguarda até que o título contenha o nome desejado.

            driver.Navigate().GoToUrl("https://homolog.converse.autolac.com.br/?laboratorio=12978557000180");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(drv => driver.Title.Contains("Autolac Converse"));
        }

        public void AgendarColeta()
        {
            //Passa por todo o fluxo de agenda de coleta com sucesso. 
            //Utiliza CFP aleatório para gerar nova coleta.

            var cpfAleatorio = new CpfHelper();
            string cpf = cpfAleatorio.GerarCpf();

            driver.FindElement(byBtnColeta).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.Until(drv => driver.PageSource.Contains("Ah, e sem abreviações, viu?"));
            driver.FindElement(byInputTexto).SendKeys("Teste");
            driver.FindElement(byBtnSendTexto).Click();
            wait.Until(drv => driver.PageSource.Contains("você me informe o seu CPF"));
            driver.FindElement(byInputMasked).SendKeys(cpf);
            driver.FindElement(byBtnSendMasked).Click();
            wait.Until(drv => driver.PageSource.Contains("Agora preciso do seu e-mail"));
            driver.FindElement(byInputTexto).SendKeys("teste@teste.com");
            driver.FindElement(byBtnSendTexto).Click();
            wait.Until(drv => driver.PageSource.Contains("Tem gente que não gosta de e-mails"));
            driver.FindElement(byInputMasked).SendKeys("51999999999");
            driver.FindElement(byBtnSendMasked).Click();
            wait.Until(drv => driver.PageSource.Contains("Agora, preciso que você tire uma foto"));
            driver.FindElement(byFileInput).SendKeys(@"C:\Imagens\test1.jpg");
            Thread.Sleep(2000);
            driver.FindElement(byFileInput).SendKeys(@"C:\Imagens\test2.png");
            Thread.Sleep(1000);
            driver.FindElement(byBtnSendForm).Click();
            wait.Until(drv => driver.PageSource.Contains("Agora me diga, quando você gostaria"));
            driver.FindElement(byInputDate).Click();
            driver.FindElement(byInputDate).SendKeys(DateTime.Now.AddDays(1).ToString("ddMMyyyy"));
            driver.FindElement(byBtnSendForm).Click();
            wait.Until(drv => driver.PageSource.Contains("Qual o melhor horário para você?"));
            driver.FindElement(byBtnSendForm).Click();
            wait.Until(drv => driver.PageSource.Contains("Você realizará os exames através de um convênio?"));
            driver.FindElement(byBtnParticular).Click();
            wait.Until(drv => driver.PageSource.Contains("Preciso saber quais exames você pretende realizar"));
            driver.FindElement(byGuiasFileInput).SendKeys(@"C:\Imagens\exame1.png");
            Thread.Sleep(2000);
            driver.FindElement(byGuiasFileInput).SendKeys(@"C:\Imagens\exame2.jpg");
            Thread.Sleep(1000);
            driver.FindElement(byGuiasFileInput).SendKeys(@"C:\Imagens\exame3.png");
            Thread.Sleep(1000);
            driver.FindElement(byBtnSendForm).Click();
            wait.Until(drv => driver.PageSource.Contains("CEP"));
            driver.FindElement(byInputMasked).SendKeys("88040420");
            driver.FindElement(byBtnSendMasked).Click();
            wait.Until(drv => driver.PageSource.Contains("Qual o logradouro do local onde você mora?"));
            driver.FindElement(byInputTexto).SendKeys("Teste");
            driver.FindElement(byBtnSendTexto).Click();
            wait.Until(drv => driver.PageSource.Contains("Qual o número e complemento"));
            driver.FindElement(byInputTexto).SendKeys("Teste");
            driver.FindElement(byBtnSendTexto).Click();
            wait.Until(drv => driver.PageSource.Contains("Qual é o seu bairro?"));
            driver.FindElement(byInputTexto).SendKeys("Teste");
            driver.FindElement(byBtnSendTexto).Click();
            wait.Until(drv => driver.PageSource.Contains("Qual é a sua cidade?"));
            driver.FindElement(byInputTexto).SendKeys("Teste");
            driver.FindElement(byBtnSendTexto).Click();
            wait.Until(drv => driver.PageSource.Contains("Qual é o seu estado?"));
            driver.FindElement(byInputEstado).SendKeys("SC");
            driver.FindElement(byInputEstado).SendKeys(Keys.Enter);
            driver.FindElement(byBtnSendForm).Click();
            wait.Until(drv => driver.PageSource.Contains("Deseja acrescentar alguma observação"));
            driver.FindElement(byBtnObsSim).Click();
            wait.Until(drv => driver.PageSource.Contains("Ok! Digite abaixo todas as observações que desejar."));
            driver.FindElement(byInputTexto).SendKeys("Testando observação.");
            driver.FindElement(byBtnSendTexto).Click();
            wait.Until(drv => driver.PageSource.Contains("Como você gostaria de ser contactado pelo nosso laboratório?"));
            driver.FindElement(byBtnCheckWhatsApp).Click();
            Thread.Sleep(500);
            driver.FindElement(byBtnFinish).Click();
            wait.Until(drv => driver.PageSource.Contains("Em breve um de nossos atendentes"));            
        }

        public void AgendarHorario()
        {
            //Não implementado pois troquei de projeto na empresa.
        }
    }
}
