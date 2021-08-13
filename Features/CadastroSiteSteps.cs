using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;

namespace ProjetoAutomacao.Features
{
    [Binding]
    public class CadastroSiteSteps
    {
        IWebDriver driver = new ChromeDriver("D:\\Downloads\\chromedriver_win32");

        [Given(@"que estou na pagina de Cadastro com um ""(.*)"" valido")]
        public void DadoQueEstouNaPaginaDeCadastroComUmValido(string p0)
        {
            
            //Navega para a tela de Autenticação
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

            Thread.Sleep(5000);

            //Encontra o camnpo Email
            IWebElement campo_email = driver.FindElement(By.Id("email_create"));

            //Digita o email válido
            campo_email.SendKeys(p0);
           
            //Encontra o botão [Crie sua conta aqui] e clica
            IWebElement crie_conta = driver.FindElement(By.Id("SubmitCreate"));
            crie_conta.Click();

            Thread.Sleep(5000);
        }
        
        [When(@"informar os dados do usuario")]
        public void QuandoInformarOsDadosDoUsuario()
        {

            Thread.Sleep(5000);

            //Encontra os campos dados do usuário            
            var txtNome = driver.FindElement(By.Name("customer_firstname"));
            var txtSobrenome = driver.FindElement(By.Name("customer_lastname"));
            var txtSenha = driver.FindElement(By.Name("passwd"));
            var txtEndereco = driver.FindElement(By.Id("address1"));
            var txtCidade = driver.FindElement(By.Id("city"));            
            var txtCep = driver.FindElement(By.Id("postcode"));         
            var txtCelular = driver.FindElement(By.Id("phone_mobile"));

            //Preenche dados no formulário de cadastro 
            txtNome.SendKeys("Robert");
            txtSobrenome.SendKeys("Duncan");
            txtSenha.SendKeys("Teste@1234");
            txtEndereco.SendKeys("2077 Poling Farm Road");
            txtCidade.SendKeys("YUBA CITY");


            //Selecionar lista suspensa de Estados
            IWebElement ListaEstados = driver.FindElement(By.Name("id_state"));
            SelectElement SelectEstado = new SelectElement(ListaEstados);

            Thread.Sleep(3000);

            SelectEstado.SelectByText("California");

            Thread.Sleep(3000);
           
            //Preenche cep
            txtCep.SendKeys("95992");


            //Seleciona lista de suspensa de Paises
            IWebElement ListaPaises = driver.FindElement(By.Name("id_state"));
            SelectElement SelectPais = new SelectElement(ListaPaises);

            Thread.Sleep(3000);

            SelectEstado.SelectByText("California");

            Thread.Sleep(3000);            

            //Preenche numero celular
            txtCelular.SendKeys("562-577-7763");
        }

        [When(@"clicar no botao Registro")]
        public void QuandoClicarNoBotaoRegistro()
        {
           
            //Encontra o botão [Registro] e clica
            IWebElement btn_registro = driver.FindElement(By.Id("submitAccount"));
            btn_registro.Click();

            Thread.Sleep(5000);

        }
        
        [Then(@"o usuario deve ser redirecionado para pagina My Account")]
        public void EntaoOUsuarioDeveSerRedirecionadoParaPaginaMyAccount()
        {

            String textoElement = driver.FindElement(By.Id("my-account")).Text;          
            
            Assert.AreEqual("My Account", textoElement, "Página My Account não encontrada");           
                        
        }

    }
}
