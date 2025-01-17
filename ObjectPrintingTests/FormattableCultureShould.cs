﻿using System.Globalization;

namespace ObjectPrintingTests
{
    public class FormattableCultureShould
    {
        private string printedString;
        private static CultureInfo ruCultureInfo = new("ru");
        private static CultureInfo enCultureInfo = new("en");
        private static CultureInfo euCultureInfo = new("eu");
        private static DateTime time = new(2022, 11, 29, 13, 34, 56);

        [SetUp]
        public void SetUp()
        {
            printedString = null;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
                Console.WriteLine(printedString);
        }

        [Test]
        public void ChangeNumberFormat_WhenCurrentCultureIsRU()
        {
            var printer = ObjectPrinter.For<double>();
            printer.Printing<double>().UsingWithFormatting(ruCultureInfo);
            printedString = printer.PrintToString(1.2);
            printedString.Should().Contain(",");
        }

        [Test]
        public void ChangeNumberFormat_WhenCurrentCultureIsUs()
        {
            var printer = ObjectPrinter.For<double>();
            printer.Printing<double>().UsingWithFormatting(enCultureInfo);
            printedString = printer.PrintToString(1.2);
            printedString.Should().Contain(".");
        }

        [Test]
        public void ChangeDateFormat_WhenCurrentCultureIsEU()
        {
            var printer = ObjectPrinter.For<DateTime>();
            printer.Printing<DateTime>().UsingWithFormatting(euCultureInfo);
            printedString = printer.PrintToString(time);
            printedString.Should().Contain("2022/11/29 13:34:56");
        }

        [Test]
        public void ChangeDateFormat_WhenCurrentCultureIsUS()
        {
            var printer = ObjectPrinter.For<DateTime>();
            printer.Printing<DateTime>().UsingWithFormatting(enCultureInfo);
            printedString = printer.PrintToString(time);
            printedString.Should().Contain("11/29/2022 1:34:56 PM");
        }

        [Test]
        public void ChangeDateFormat_WhenCurrentCultureIsRU()
        {
            var printer = ObjectPrinter.For<DateTime>();
            printer.Printing<DateTime>().UsingWithFormatting(ruCultureInfo);
            printedString = printer.PrintToString(time);
            printedString.Should().Contain("29.11.2022 13:34:56");
        }
    }
}
