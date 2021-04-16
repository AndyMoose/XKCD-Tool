using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XKCDLibrary.Commands;
using XKCDLibrary.Models;
using XKCDLibrary.Queries;

namespace XKCDUI
{
    public partial class SavedComicsForm : Form
    {
        private readonly IMediator _mediator;
        private readonly MainForm _mainForm;
        private ToolTip _toolTip;

        public SavedComicsForm(IMediator mediator, MainForm mainForm)
        {
            InitializeComponent();
            _toolTip = new ToolTip();
            _mediator = mediator;
            _mainForm = mainForm;
        }

        public BindingList<ComicModel> comicListBindingSource = new();

        private async void SavedComicsForm_Load(object sender, EventArgs e)
        {
            var list = await _mediator.Send(new DBGetAllSavedComicsQuery());
            comicListBindingSource = new BindingList<ComicModel>(list);
            await BindComicList();
        }

        private Task BindComicList()
        {
            SavedComicBox.Image = null;
            ComicList.ClearSelected();
            ComicList.DataSource = null;
            ComicList.DataSource = comicListBindingSource;
            ComicList.DisplayMember = "Title";
            return Task.CompletedTask;
        }

        private async void ComicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedImage = ComicList.SelectedItem;
            if(selectedImage != null)
                await UpdatePictureBoxImage((ComicModel)selectedImage);
        }

        private async Task UpdatePictureBoxImage(ComicModel comic)
        {
            SavedComicBox.WaitOnLoad = false;
            await Task.Run(() => SavedComicBox.LoadAsync(comic.Img));
        }

        public Task AddToComicList(ComicModel comic)
        {
            comicListBindingSource.Add(comic);
            return Task.CompletedTask;
        }

        private async Task DeleteFromComicList(ComicModel comic)
        {
            await Task.Run(() =>
            {
                foreach (ComicModel item in comicListBindingSource)
                {
                    if (item.Num == comic.Num)
                    {
                        comicListBindingSource.Remove(item);
                        break;
                    }  
                }
            });
            await BindComicList();
        }

        private async void SavedComicsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            await _mainForm.EnableSearchButton();
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ComicList.SelectedItem != null)
            {
                var comic = await _mediator.Send(new DBDeleteComicCommand((ComicModel)ComicList.SelectedItem));
                await DeleteFromComicList(comic);
            }  
        }

        private void SavedComicBox_MouseHover(object sender, EventArgs e)
        {
            if (ComicList.SelectedItem != null)
            {
                ComicModel comic = (ComicModel)ComicList.SelectedItem;
                _toolTip.SetToolTip(SavedComicBox, comic.Alt);
            }
        }
    }
}
