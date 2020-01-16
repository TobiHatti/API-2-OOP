# API-2-OOP

![image](https://github.com/TobiHatti/API-2-OOP/blob/master/API2OOP_Sample.PNG)

The API-2-OOP-Tool provides a simple way to convert lines from an API to programing-friendly-formated statements to speed up development of API-based programs.
Available as Winforms-Program as well as UWP-App (Windows-App)

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
		...
```

A single line from the API-Example above, when selected, gets converted into the following:

```csharp
// C#
apiResult.data[0].employee_name
```
You can pick from several common languages. The output adapts to whichever language is selected:

```vbnet
'' VB .NET
apiResult.data(0).employee_name
```
```php
// PHP
apiResult->data[0]->employee_name
```
```python
# Python
apiResult.data[0].employee_name
```
