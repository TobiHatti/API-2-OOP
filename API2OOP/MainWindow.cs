using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API2OOP
{
    public partial class MainWindow : Form
    {
        private string ApiResponse = null;
        private dynamic ApiResult = null;

        private string regexMatchGroupElement = @"(\s+| ?)""[A-Za-z0-9:/._-]+""(\s+| ?):(\s+| ?)(""[A-Za-z0-9ÄäÖöÜüß!§$%&/()=?`°^´+*#'~_.:,;_<>|@€µ\{\}\[\]\\\s\-]+""|[0-9.]+|[A-Za-z.]+)(,| ?)";
        private string regexMatchGroupStart = @"(\s+| ?)""[A-Za-z0-9:/._-]+""(\s+| ?):(\s+| ?){";
        private string regexMatchArrayStart = @"(\s+| ?)""[A-Za-z0-9:/._-]+""(\s+| ?):(\s+| ?)\[";
        private string regexArrayGroupStart = @"(\s+| ?){";
        private string regexMatchGroupEnd   = @"(\s+| ?)}(,| ?)";
        private string regexMatchArrayEnd   = @"(\s+| ?)\](,| ?)";

        private string regexFindGroupName = @"""[A-Za-z0-9:/._-]+""";
        private string regexFindElementName = @"""[A-Za-z0-9:/._-]+"":";

        private string languageDynamicType = "dynamic";
        private string classDelimiter = ".";
        private char arrayOpenBracket = '[';
        private char arrayCloseBracket = ']';

        public MainWindow()
        {
            InitializeComponent();
            cbxLanguage.SelectedIndex = 0;
        }

        private void btnLoadApi_Click(object sender, EventArgs e)
        {
            LoadApi();
        }

        private void txbApiUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) LoadApi();
        }

        

        private void lbxApiResult_SelectedValueChanged(object sender, EventArgs e)
        {
            if(lbxApiResult.SelectedValue != null)
                txbCSObject.Text = lbxApiResult.SelectedValue.ToString();
        }

        private void cbxLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(cbxLanguage.SelectedIndex)
            {
                case 0:
                    arrayOpenBracket = '[';
                    arrayCloseBracket = ']';
                    classDelimiter = ".";
                    break;
                case 1:
                    arrayOpenBracket = '(';
                    arrayCloseBracket = ')';
                    classDelimiter = ".";
                    break;
                case 2:
                    arrayOpenBracket = '[';
                    arrayCloseBracket = ']';
                    classDelimiter = "->";
                    break;
            }

            if(ApiResponse != null)
                FillApiListing();
        }

        private void chbShowLangType_CheckedChanged(object sender, EventArgs e)
        {
            if (ApiResponse != null)
                FillApiListing();
        }

        private void btnCopyResult2Clipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txbCSObject.Text);
        }


        private void LoadApi()
        {
            try
            { 
                Uri uriResult;
                bool isValidUrl = Uri.TryCreate(txbApiUrl.Text, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (isValidUrl)
                {
                    if (string.IsNullOrEmpty(txbPost1Key.Text) && string.IsNullOrEmpty(txbPost2Key.Text) && string.IsNullOrEmpty(txbPost3Key.Text))
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            ApiResponse = webClient.DownloadString(txbApiUrl.Text);
                        }
                    }
                    else
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            NameValueCollection postAttributes = new NameValueCollection();

                            if (!string.IsNullOrEmpty(txbPost1Key.Text)) postAttributes.Add(txbPost1Key.Text, txbPost1Value.Text);
                            if (!string.IsNullOrEmpty(txbPost2Key.Text)) postAttributes.Add(txbPost2Key.Text, txbPost2Value.Text);
                            if (!string.IsNullOrEmpty(txbPost3Key.Text)) postAttributes.Add(txbPost3Key.Text, txbPost3Value.Text);

                            ApiResponse = Encoding.UTF8.GetString(webClient.UploadValues(txbApiUrl.Text, postAttributes));
                        }
                    }

                    ApiResult = JsonConvert.DeserializeObject(ApiResponse);

                    FillApiListing();
                }
                else
                {
                    MessageBox.Show("Please enter a valid URL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The API could not be loaded or failed to parse.Please verify that the APIs URL is valid and the output is in a standard JSON format.", "Could not load API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FillApiListing()
        {
            try
            {
                string apiString = ApiResult.ToString();
                string[] apiLines = Regex.Split(apiString, "\r\n|\r|\n");

                List<ApiElement> apiElements = new List<ApiElement>();

                lbxApiResult.DataSource = null;
                lbxApiResult.DisplayMember = null;
                lbxApiResult.ValueMember = null;
                lbxApiResult.Items.Clear();


                DataTable apiData = new DataTable("ApiData");

                apiData.Columns.Add("Display", typeof(string));
                apiData.Columns.Add("CSFormat", typeof(string));


                bool firstLine = true;
                foreach (string line in apiLines)
                {
                    if (firstLine)
                    {
                        if (line.StartsWith("{")) apiElements.Add(new ApiElement("api"));
                        if (line.StartsWith("[")) apiElements.Add(new ApiElement("api", true));
                    }
                    firstLine = false;

                    string tmp;

                    // Match Group Start "...": {
                    if (Regex.IsMatch(line, regexMatchGroupStart))
                    {
                        tmp = Regex.Match(line, regexFindGroupName).Value.TrimStart('"').TrimEnd('"');

                        apiElements.Add(new ApiElement(tmp));
                    }
                    // Match Array Start "...": [
                    else if (Regex.IsMatch(line, regexMatchArrayStart))
                    {
                        tmp = Regex.Match(line, regexFindGroupName).Value.TrimStart('"').TrimEnd('"');

                        apiElements.Add(new ApiElement(tmp, true, 0));
                    }
                    // Match ArrayGroup-Start {
                    else if (Regex.IsMatch(line, regexArrayGroupStart))
                    {
                        // No special action needed
                    }
                    // Match Group-End }
                    else if (Regex.IsMatch(line, regexMatchGroupEnd))
                    {
                        if (!apiElements[apiElements.Count - 1].IsArray) apiElements.RemoveAt(apiElements.Count - 1);
                        else apiElements[apiElements.Count - 1].ArrayIndex++;
                    }
                    // Match Array-End ]
                    else if (Regex.IsMatch(line, regexMatchArrayEnd))
                    {
                        apiElements.RemoveAt(apiElements.Count - 1);
                    }

                    apiData.Rows.Add(line, ParseCurrentLine(line, apiElements));
                }

                lbxApiResult.DataSource = apiData;
                lbxApiResult.DisplayMember = apiData.Columns[0].ColumnName;
                lbxApiResult.ValueMember = apiData.Columns[1].ColumnName;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while trying to parse the API. Please check the API-Source and try again","Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private string ParseCurrentLine(string pLine, List<ApiElement> pApiElementList)
        {
            string outText = "";

            foreach (ApiElement element in pApiElementList)
            {
                if (element.IsArray) outText += element.GroupName + arrayOpenBracket + element.ArrayIndex + arrayCloseBracket + classDelimiter;
                else outText += element.GroupName + classDelimiter;


            }

            // Match elements "...":"..."
            if (Regex.IsMatch(pLine, regexMatchGroupElement))
            {
                // Get name of the element
                outText += Regex.Match(pLine, regexFindElementName).Value.TrimStart('"').TrimEnd(':', '"');
            }
            // Match Group Start "...": { or Match Array Start "...": [
            else if (Regex.IsMatch(pLine, regexMatchGroupStart) || Regex.IsMatch(pLine, regexMatchArrayStart))
            {
                // Remove the last "." from the string, return only the array
                outText = outText.Substring(0, outText.Length - 1);
            }
            // Match ArrayGroup-Start { or Match Group-End } or Match Array-End ]
            else if (Regex.IsMatch(pLine, regexArrayGroupStart) || Regex.IsMatch(pLine, regexMatchGroupEnd) || Regex.IsMatch(pLine, regexMatchArrayEnd))
            {
                // Invalid Line
                outText = "";
            }

            return outText;
        }

        public class ApiElement
        {
            public string GroupName { get; set; } = "";
            public bool IsArray { get; set; } = false;
            public int ArrayIndex { get; set; } = 0;

            public ApiElement(string pGroupName, bool pIsArray = false, int pArrayIndex = 0)
            {
                GroupName = pGroupName;
                IsArray = pIsArray;
                ArrayIndex = pArrayIndex;
            }
        }

        private void btnOpenExample_Click(object sender, EventArgs e)
        {
            LanguageExample langExamp = new LanguageExample();
            langExamp.ShowDialog();
        }

        private void txbCSObject_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
                FindElement();
        }

        private void btnFindElement_Click(object sender, EventArgs e)
        {
            FindElement();
        }

        private void FindElement()
        {
            bool elementFound = false;


            for (int i = 0; i < lbxApiResult.Items.Count; i++)
            {
                if ((lbxApiResult.Items[i] as DataRowView).Row[1].ToString() == txbCSObject.Text)
                {
                    lbxApiResult.SelectedIndex = i;
                    elementFound = true;
                }
            }

            if (!elementFound)
            {
                MessageBox.Show("The entered item could not be found in the current API-Listing.", "Element not found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
