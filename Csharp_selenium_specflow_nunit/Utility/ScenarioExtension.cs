using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace Csharp_selenium_specflow_nunit.Utility
{
    public static class ScenarioExtension
    {
        // Here is a method to create a Scenario passing the type of Step
        private static ExtentTest CreateScenario(ExtentTest extent, StepDefinitionType stepDefinitionType)
        {
            // SpecFlow allows us to get the name of the Step using ScenarioStepContext.Current
            var scenarioStepContext = ScenarioStepContext.Current.StepInfo.Text;

            switch (stepDefinitionType)
            {
                case StepDefinitionType.Given:
                    return extent.CreateNode<Given>(scenarioStepContext); // Rebuild the node for Given

                case StepDefinitionType.Then:
                    return extent.CreateNode<Then>(scenarioStepContext); // Rebuild the node for Then

                case StepDefinitionType.When:
                    return extent.CreateNode<When>(scenarioStepContext); // Rebuild the node for When
                default:
                    throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null);
            }
        }

        // Here is a method to create a new one for failure or error
        private static void CreateScenarioFailOrError(ExtentTest extent, StepDefinitionType stepDefinitionType, String pathScreenshot)
        {
            var scenarioStepContext = ScenarioStepContext.Current.StepInfo.Text;
            var error = ScenarioContext.Current.TestError;

            // If there is no exception then get the error message from ScenarioContext.Current
            if (error.InnerException == null)
            {
                CreateScenario(extent, stepDefinitionType).Error(error.Message).AddScreenCaptureFromPath(pathScreenshot, scenarioStepContext);
            }
            else
            {
                // Otherwise creates a failure passing the exception
                CreateScenario(extent, stepDefinitionType).Fail(error.InnerException).AddScreenCaptureFromPath(pathScreenshot, scenarioStepContext);
            }
        }

        // The methods below just made the calls for Given, When and Then
        public static void StepDefinitionGiven(this ExtentTest extent, String pathScreenshot)
        {
            if (ScenarioContext.Current.TestError == null)
                CreateScenario(extent, StepDefinitionType.Given);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.Given, pathScreenshot);
        }

        public static void StepDefinitionWhen(this ExtentTest extent, String pathScreenshot)
        {
            if (ScenarioContext.Current.TestError == null)
                CreateScenario(extent, StepDefinitionType.When);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.When, pathScreenshot);
        }

        public static void StepDefinitionThen(this ExtentTest extent, String pathScreenshot)
        {
            if (ScenarioContext.Current.TestError == null)
                CreateScenario(extent, StepDefinitionType.Then);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.Then, pathScreenshot);
        }
    }
}