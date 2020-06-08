<img align="right" width="80" height="80" data-rmimg src="https://endev.at/content/projects/API-2-OOP/API2OOP_Logo_128.png">

# API-2-OOP

[![GitHub](https://img.shields.io/github/license/TobiHatti/API-2-OOP)](https://opensource.org/licenses/GPL-3.0)
[![GitHub Release Date](https://img.shields.io/github/release-date/TobiHatti/API-2-OOP)](https://github.com/TobiHatti/API-2-OOP/releases)
[![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/TobiHatti/API-2-OOP?include_prereleases)](https://github.com/TobiHatti/API-2-OOP/releases)
[![GitHub last commit](https://img.shields.io/github/last-commit/TobiHatti/API-2-OOP)](https://github.com/TobiHatti/API-2-OOP/commits/master)
[![GitHub issues](https://img.shields.io/github/issues-raw/TobiHatti/API-2-OOP)](https://github.com/TobiHatti/API-2-OOP/issues)
[![GitHub language count](https://img.shields.io/github/languages/count/TobiHatti/API-2-OOP)](https://github.com/TobiHatti/API-2-OOP)

![image](https://endev.at/content/projects/API-2-OOP/API2OOP_Banner_1080.png)

The API-2-OOP-Tool provides a simple way to convert lines from an API to programing-friendly-formated statements to speed up development of API-based programs.
Available as Winforms-Program as well as UWP-App (Windows-App)

![image](https://endev.at/content/projects/API-2-OOP/projectImages/API2OOP_Sample.png)

```json
{
	"status":"success",
	"data":[
	{
		"id":"1",
		"employee_name":"Tiger Nixon",
		"employee_salary":"320800",
		"employee_age":"61"
		,"profile_image":""
	},
	{
		"id":"2",
		"employee_name":"Garrett Winters",
```

A single line from the API-Example above, when selected, gets converted into the following:

```csharp
// C#
string name = apiResult.data[0].employee_name;
```
You can pick from several common languages. The output adapts to whichever language is selected:

```vbnet
' VB .NET
Dim name As String = apiResult.data(0).employee_name
```
```php
// PHP
$name = apiResult->data[0]->employee_name;
```
```python
# Python
name = apiResult.data[0].employee_name
```

## Downloads: 

WinForms-Edition: [see releases](https://github.com/TobiHatti/API-2-OOP/releases)

UWP-Versions / Windows App: Download from Microsoft-Store (Pending...)
