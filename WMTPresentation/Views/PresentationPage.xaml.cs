using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WMTPresentation.Common;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;
using WMTPresentation.Services.Intarfaces;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WMTPresentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PresentationPage : Page
    {
        private readonly IPresentationService _presentationService;
        private readonly IHttpService _httpService;

        string token;

        Presentation presentation;
        List<Presentation> presentations;
        private List<PresentationDto> PresentationsList;

        public PresentationPage()
        {
            this.InitializeComponent();

            _presentationService = NinjectContainer.Resolve<IPresentationService>();
            _httpService = NinjectContainer.Resolve<IHttpService>();

            PresentationsList = _presentationService.Read();
        }

        async private void GetTokenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                token = await _httpService.GetToken(EmailTextBox.Text.ToString(), PasswordTextBox.Text.ToString());
                GetPresentationsListButton.IsEnabled = true;
                GetPresentationByIdButton.IsEnabled = true;

                TokenTextBlock.Text = token;
            }
            catch (Exception ex)
            {
                TokenTextBlock.Text = "Error: " + ex.Message;
            }
        }

        async private void GetPresentationByIdButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //presentation = await _httpService.GetPresentationById("563c8435bb1391f92442e86c", token);
                presentation = await _httpService.GetPresentationById(PresentationIdTextBox.Text, token);

                _presentationService.Create(presentation);
            }
            catch (Exception ex)
            {
                //tokenTextBlock.Text = "Error: " + ex.Message;
            }
        }

        async private void GetPresentationsListButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                presentations = await _httpService.GetPresentations(token);

                _presentationService.CreateList(presentations);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void PresentationListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var presentation = (PresentationDto)e.ClickedItem;

            PresentationDetailsTitleTextBlock.Text = "Details for presentation: " + presentation.Title + " (" + presentation._id + ")";
            PresentationThumbnailTextBlock.Text = "Thumbnail: " + presentation.Thumbnail;
            PresentationChaptersCountTextBlock.Text = "Presentation has " + presentation.ChaptersCount+ " chapter(s)"; 

        }
    }
}
