using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace API2OOP_UWP
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string ApiResponse = null;
        private dynamic ApiResult = null;

        private string regexMatchGroupElement = @"(\s+| ?)""[A-Za-z0-9:/._-]+""(\s+| ?):(\s+| ?)(""[A-Za-z0-9ÄäÖöÜüß!§$%&/()=?`°^´+*#'~_.:,;_<>|@€µ\{\}\[\]\\\s\-]+""|[0-9.]+|[A-Za-z.]+)(,| ?)";
        private string regexMatchGroupStart = @"(\s+| ?)""[A-Za-z0-9:/._-]+""(\s+| ?):(\s+| ?){";
        private string regexMatchArrayStart = @"(\s+| ?)""[A-Za-z0-9:/._-]+""(\s+| ?):(\s+| ?)\[";
        private string regexArrayGroupStart = @"(\s+| ?){";
        private string regexMatchGroupEnd = @"(\s+| ?)}(,| ?)";
        private string regexMatchArrayEnd = @"(\s+| ?)\](,| ?)";

        private string regexFindGroupName = @"""[A-Za-z0-9:/._-]+""";
        private string regexFindElementName = @"""[A-Za-z0-9:/._-]+"":";

        private string classDelimiter = ".";
        private char arrayOpenBracket = '[';
        private char arrayCloseBracket = ']';


        public List<ApiDataV2> ApiData = new List<ApiDataV2>();

        public struct ApiDataV2
        {
            public string ActualLine { get; set; }
            public string SimplifiedLine { get; set; }

            public ApiDataV2(string pActualLine, string pSimplifiedLine)
            {
                ActualLine = pActualLine;
                SimplifiedLine = pSimplifiedLine;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView appView = ApplicationView.GetForCurrentView();
            appView.Title = "API-2-OOP Parser";
        }

        private void btnLoadApi_Click(object sender, RoutedEventArgs e)
        {
            LoadApi();
        }


        private async void LoadApi()
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
                    MessageDialog dialog = new MessageDialog("Please enter a valid URL, eg.: https://www.example.com/api/", "No valid URL");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("The API could not be loaded or failed to parse. Please verify that the APIs URL is valid and the output is in a standard JSON format.", "Could not load API");
                await dialog.ShowAsync();
            }
        }

        private async void FillApiListing()
        {
            try
            { 
                string apiString = ApiResult.ToString();
                string[] apiLines = Regex.Split(apiString, "\r\n|\r|\n");

                List<ApiElement> apiElements = new List<ApiElement>();

                lbxApiResult.ItemsSource = null;
                lbxApiResult.DisplayMemberPath = "";
                lbxApiResult.SelectedValuePath = "";
                lbxApiResult.Items.Clear();

                ApiData = new List<ApiDataV2>();

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

                    ApiData.Add(new ApiDataV2(line, ParseCurrentLine(line, apiElements)));
                }

                lbxApiResult.ItemsSource = ApiData;
                lbxApiResult.DisplayMemberPath = "ActualLine";
                lbxApiResult.SelectedValuePath = "SimplifiedLine";
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("An error occured while trying to parse the API. Please check the API-Source and try again", "Parsing Error");
                await dialog.ShowAsync();
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

        private void btnCopyResult2Clipboard_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dp = new DataPackage();
            dp.SetText(txbCSObject.Text);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dp);

        }

        private void txbApiUrl_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) LoadApi();
        }

        private void lbxApiResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxApiResult.SelectedValue != null)
            {
                txbCSObject.Text = lbxApiResult.SelectedValue.ToString();
                txbLineNumber.Text = Convert.ToString(lbxApiResult.SelectedIndex + 1);
            }
        }

        private void cbxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbxLanguage.SelectedIndex)
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

            if (ApiResponse != null)
                FillApiListing();
        }

        private void btnFindEntry_Click(object sender, RoutedEventArgs e)
        {
            FindElement();
        }

        private void txbCSObject_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                FindElement();
        }

        private async void FindElement()
        {
            bool elementFound = false;

            for (int i = 0; i < ApiData.Count; i++)
            {
                if (ApiData[i].SimplifiedLine == txbCSObject.Text)
                {
                    lbxApiResult.SelectedIndex = i;
                    lbxApiResult.ScrollIntoView(lbxApiResult.SelectedItem);
                    elementFound = true;
                }
            }

            if(!elementFound)
            {
                MessageDialog dialog = new MessageDialog("The entered item could not be found in the current API-Listing.", "Element not found!");
                await dialog.ShowAsync();
            }
        }

        private async void FindLineNumber()
        {
            if(Regex.IsMatch(txbLineNumber.Text, "^[0-9]+") && Convert.ToInt32(txbLineNumber.Text) <= lbxApiResult.Items.Count && Convert.ToInt32(txbLineNumber.Text) > 0)
            {
                lbxApiResult.SelectedIndex = Convert.ToInt32(txbLineNumber.Text) - 1;
                lbxApiResult.ScrollIntoView(lbxApiResult.SelectedItem);
            }
            else
            {
                MessageDialog dialog = new MessageDialog($"The line-number is either not valid, or out of range. Accepted values range from 0-{lbxApiResult.Items.Count}.", "No such line-number");
                await dialog.ShowAsync();
            }
        }

        private void btnFindLineNo_Click(object sender, RoutedEventArgs e)
        {
            FindLineNumber();
        }

        private void txbLineNumber_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                FindLineNumber();
        }
    }
}
