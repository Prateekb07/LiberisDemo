using LiberisDemo.Helpers;
using TechTalk.SpecFlow;

namespace LiberisDemo.Steps
{
    [Binding]
    public sealed class LiberisSteps
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public LiberisSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        LiberisModule objLiberisModule = new LiberisModule();

        [Given(@"User opens the URL ""(.*)""")]
        public void GivenUserOpensTheURL(string url)
        {
            objLiberisModule.LaunchURL(url);
        }

        [When(@"User clicks on '(.*)' button")]
        public void WhenUserClicksOnButton(string p0)
        {
            objLiberisModule.ClickDemo();
        }

        [Then(@"Verify user is landed on partner page with all types of partners displayed")]
        public void ThenVerifyUserIsLandedOnPartnerPageWithAllTypesOfPartnersDisplayed()
        {
            objLiberisModule.VerifyPartnerPage();
            objLiberisModule.VerifyPartnerSelection();
        }

    }
}
