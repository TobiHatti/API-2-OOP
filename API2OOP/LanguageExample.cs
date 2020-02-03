using Highlight;
using Highlight.Engines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API2OOP
{
    public partial class LanguageExample : Form
    {
        private Dictionary<string, string> languageExamples = new Dictionary<string, string>();
        
        public LanguageExample()
        {
            InitializeComponent();
            LoadExamples();
            FillLanguageSelection();

            /*
                C++
                C
                Java
                JavaScript
                PHP
                Python
             */
        }

        private void btnCloseExample_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCopyExample_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(webLanguageExample.Document.Body.InnerText.ToString());
        }

        private void FillLanguageSelection()
        {
            foreach (KeyValuePair<string, string> entry in languageExamples)
                cbxExampleLanguage.Items.Add(entry.Key);
        }

        private void LoadExamples()
        {
            var csharpCode =
@"// Language: C#

string apiResponse;

// Get API-Response by GET
using (WebClient webClient = new WebClient())
{
    apiResponse = webClient.DownloadString(""http://..."");
}

// Get API-Response by POST
using (WebClient webClient = new WebClient())
{
    NameValueCollection postAttributes = new NameValueCollection();
    postAttributes.Add(""username"", ""TomJohn322"");
    postAttributes.Add(""password"", ""Apple9!"");
    apiResponse = Encoding.UTF8.GetString(webClient.UploadValues(""http://..."", postAttributes));
}

// Convert API-Response
// Recommended: Install the Newtonsoft.Json NuGet Package
dynamic apiResult = JsonConvert.DeserializeObject(ApiResponse);

// Get line from API
string username = apiResult.data[0].username;
";

            var vbnetCode = 
@"'' Language: VB .NET

Dim apiResponse As String

'' Get API-Response by GET
Using webClient As WebClient = New WebClient()
    apiResponse = webClient.DownloadString(""http://..."")
End Using

'' Get API-Response by POST
Using webClient As WebClient = New WebClient()
    Dim postAttributes As NameValueCollection = New NameValueCollection()
    postAttributes.Add(""username"", ""TomJohn322"")
    postAttributes.Add(""password"", ""Apple9!"")
    apiResponse = Encoding.UTF8.GetString(webClient.UploadValues(""http://...""))
End Using

'' Convert API-Response
'' Recommended: Install the Newtonsoft.Json NuGet Package
Dim apiResult As dynamic = JsonConvert.DeserializeObject(ApiResponse)

'' Get line from API
Dim username As String = apiResult.data(0).username
";

            Highlighter highlighter = new Highlighter(new HtmlEngine());

            languageExamples.Add("C#", highlighter.Highlight("C#", csharpCode));
            languageExamples.Add("VB .NET", highlighter.Highlight("VB.NET", vbnetCode));

        }

        private void cbxExampleLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> entry in languageExamples)
                if (entry.Key == cbxExampleLanguage.SelectedItem.ToString())
                    webLanguageExample.DocumentText = "<pre>" + entry.Value + "</pre>";
        }
    }
}
