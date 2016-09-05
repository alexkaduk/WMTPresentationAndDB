using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WMTPresentation.Common;
using WMTPresentation.Services.Dto;
using WMTPresentation.Services.Intarfaces;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WMTPresentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChapterPage : Page
    {
        private readonly IChapterService _chapterService;

        private List<ChapterDto> ChaptersList;

        public ChapterPage()
        {
            this.InitializeComponent();

            _chapterService = NinjectContainer.Resolve<IChapterService>();

            ChaptersList = _chapterService.Read();
        }
    }
}
