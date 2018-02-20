<h1>WebDriverTestApplication</h1>
<p>
    This project was created with Visual Studio 2017 Community Edition.
</p>
<p>
    This project will be used to demonstrate <a href="http://www.seleniumhq.org/" target=_blank">Selenium</a> and <a href="https://github.com/2gis/Winium.Desktop" target="_blank">Wininum.Desktop</a> UI tests.
</p> 
<h3>How to use</h3>
<p>
	Build the solution to see the tests in the test explorer.
</p>
<p>
	To run the WebTest_Selenium_TestForm test, first run the CodedUITestApplication.Web without debugging. 
	Next start the test from the Test Explorer window.
</p>
<p>
	To run the WebTest_Selenium_CustomerCreate_PageObject_Example_Test test, first run the CodedUITestApplication.Web without debugging. 
	Next start the test from the Test Explorer window. This is the same test as the WebTest_Selenium_TestForm test but using the page object implementation model.
</p>
<p>
	To run the Test_Windows_Calculator test, make sure that path to calc.exe is vlid for your machine.
	Next start the test from the Test Explorer window. This test was written for the calculator on a Windows 2012 server with english locale and may not work on other locales or with the newer implementation of windows calculator for Windows 10.
</p>
<p>
	To run the Test_WPF_Addition test, make sure to build the CodedUITestApplication.WPF in debug mode. 
	Next run the test from the Test Explorer window.
</p>
<h3>Extra note on running Selenium tests</h3>
<p>
This project uses the files in the Assets folder of the test project. All files in the folder have a build action and get copied to the bin folder where they are referenced from the code or web.config.
When using older MS test frameworks that run in the seperate TestResults/Out folder, you will need to use a TestSettings file to get the Assets folder deployed to that directory.
</p>
<h3>Using the page object model for UI tests</h3>
<p>
The page object model is way to abstract the test framework logic away from your tests. Your test runs on page classes. A screen, page or set of repeating controls (like a repeating menu) in the application are represented by a single "page" class in the test project. 
This abstraction makes sure that when the UI implementation is changed, that you only have to modify the page class for that part of the UI. The use of the page object model will also make your tests more readable and will keep the test code free of the code for the framework used to access the UI.
</p>
<p>
	The WebTest_Selenium_CustomerCreate_PageObject_Example_Test in this project, is an example of the use of the page object pattern.
</p>
<h3>Discovering the control Id values for your windows applications</h3>
<p>
If you do not know the Id of a windows control you can use the inspect.exe tool (<a href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd318521(v=vs.85).aspx" target="_blank">https://msdn.microsoft.com/en-us/library/windows/desktop/dd318521(v=vs.85).aspx</a>).
This tool can be installed via Visual Studio by installing the Windows 10 SDK (10.0.16299.0) for UWP: C#, VB, JS. (version number may vary). The tool will be installed in the default directory: C:\Program Files (x86)\Windows Kits\10\bin\10.0.16299.0\x86\inspect.exe.
</p>
		

