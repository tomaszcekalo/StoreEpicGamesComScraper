// See https://aka.ms/new-console-template for more information

//using Microsoft.Playwright;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

Console.WriteLine("Hello, World!");
var enUrl = "https://store.epicgames.com/en-US/";
var plUrl = "https://store.epicgames.com/pl/";
var plFgUrl = "https://store.epicgames.com/pl/free-games";

//Microsoft.Playwright.Program.Main(new[] { "install" });
//using var playwright = await Playwright.CreateAsync();
//await using var browser = await playwright.Chromium.LaunchAsync();
//var page = await browser.NewPageAsync();
//var response = await page.GotoAsync(plFgUrl);
//var count = await page.Locator("text=Teraz bezpłatnie").CountAsync();

var options = new ChromeOptions();
options.AddArgument("--disable-blink-features=AutomationControlled");
var driver = new ChromeDriver(".", options);
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

//driver.Navigate().GoToUrl(plFgUrl);
//var source = driver.PageSource;
//var titles = driver.FindElements(By.CssSelector("span[data-testid=\"offer-title-info-title\"]"));
//var subtitles = driver.FindElements(By.CssSelector("span[data-testid=\"offer-title-info-subtitle\"]"));
////var items = driver.FindElements(By.CssSelector("div")).Where(x => x.Text.Trim() == "Teraz bezpłatnie").ToList();
//var spans = driver
//    .FindElements(By.CssSelector("span"))
//    .Where(x => x.Text.Contains("Teraz"))
//    //.Where(x=>x.GetShadowRoot().)
//    .ToList();
//var sections = driver.FindElements(By.CssSelector("section"));

driver.Navigate().GoToUrl(plUrl);
var anchors = driver.FindElements(By.CssSelector("div span div div section div div div div a")).ToList();
var nows = anchors
    .Where(x => x.FindElements(By.CssSelector("div div div div div div span")).Any(x => x.Text.Trim().Contains("Teraz")))
    .ToList();
//var freeDiv = driver.FindElements(By.CssSelector("span div"))
//    .Where(x => x.FindElements(By.CssSelector("h2 span")).Where(x => x.Text.Trim() == "Bezpłatne gry").Any())
//    .ToList();
//var freeSection = driver.FindElement(By.CssSelector("section"));
//var spanDivs = driver.FindElements(By.CssSelector("main div div div div span div div"));
//spanDivs.Where(x => x.)
//var withH2Spans = spanDivs.Where(x => x.FindElements(By.CssSelector("h2 span")).Where(x => x.Text.Trim() == "Bezpłatne gry").Any());
var hrefs = nows.Select(x => x.GetAttribute("href")).ToList();
var ariaLabels = nows.Select(x => x.GetAttribute("aria-label")).ToList();
var titles = nows
    //.Select(x => x.FindElements(By.CssSelector("div[data-testid=\"offer-title-info-title\"]")))
    .Select(x => x.FindElements(By.CssSelector("div[data-testid]")))
    .ToList();//nie działa
var subTitles = nows
    .Select(x => x.FindElements(By.CssSelector("div[data-testid=\"offer-title-info-subtitle\"]")))
    .ToList();//nie działa
Console.ReadKey();