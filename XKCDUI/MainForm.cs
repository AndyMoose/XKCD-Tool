using MediatR;
using XKCDLibrary.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XKCDLibrary.Models;
using XKCDLibrary.Queries;
using XKCDLibrary.Commands;

namespace XKCDUI
{
    public partial class MainForm : Form
    {
        private readonly IMediator _mediator;
        private SavedComicsForm _savedComicsForm;
        private ComicModel _currentComic;
        private readonly ToolTip _toolTip;

        public MainForm(IMediator mediator)
        {
            InitializeComponent();
            _toolTip = new ToolTip();
            _mediator = mediator;
            _savedComicsForm = null;
        }

        private async void GetButton_Click(object sender, EventArgs e)
        {
            GetButton.Enabled = false;
            _currentComic = await _mediator.Send(new APIGetMostRecentComicQuery());
            await UpdatePictureBoxImage(_currentComic);
            await EnableAllButGetButton();
        }

        private async Task UpdatePictureBoxImage(ComicModel xkcd)
        {
            ComicBox.WaitOnLoad = false;
            await Task.Run( () => ComicBox.LoadAsync(xkcd.Img) );
            ComicTitle.Text = xkcd.Title;
        }

        private Task EnableAllButtons()
        {
            GetButton.Enabled = true;
            SaveButton.Enabled = true;
            SkipButton.Enabled = true;
            return Task.CompletedTask;
        }

        private Task EnableAllButGetButton()
        {
            SaveButton.Enabled = true;
            SkipButton.Enabled = true;
            return Task.CompletedTask;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;
            var comic = await _mediator.Send(new DBInsertComicCommand(_currentComic));
            await UpdateSavedComicListControls(comic);
        }

        private async Task UpdateSavedComicListControls(ComicModel comic)
        {
            if (_savedComicsForm != null)
                await _savedComicsForm.AddToComicList(comic);
        }

        private async void SkipButton_Click(object sender, EventArgs e)
        {
            SkipButton.Enabled = false;
            SaveButton.Enabled = false;
            await GetRandomComic();
            await EnableAllButtons();
        }

        internal Task EnableSearchButton()
        {
            return Task.FromResult(SearchButton.Enabled = true);
        }

        private async Task GetRandomComic()
        {
            _currentComic = await _mediator.Send(new APIRandomComicQuery());
            await UpdatePictureBoxImage(_currentComic);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchButton.Enabled = false;
            _savedComicsForm = new SavedComicsForm(_mediator, this);
            _savedComicsForm.Show();
        }

        private void ComicBox_MouseHover(object sender, EventArgs e)
        {
            if (ComicBox.Image != null)
                _toolTip.SetToolTip(ComicBox, _currentComic.Alt);
        }
    }
}
