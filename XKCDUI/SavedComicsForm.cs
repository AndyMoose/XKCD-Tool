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
        private readonly ToolTip _toolTip;

        public SavedComicsForm(IMediator mediator, MainForm mainForm)
        {
            InitializeComponent();
            _toolTip = new ToolTip();
            _mediator = mediator;
            _mainForm = mainForm;
        }

        public BindingList<Comic> comicListBindingSource = new();

        private async void SavedComicsForm_Load(object sender, EventArgs e)
        {
            var list = await _mediator.Send(new DBGetAllSavedComicsQuery());
            comicListBindingSource = new BindingList<Comic>(list);
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
                await UpdatePictureBoxImage((Comic)selectedImage);
        }

        private async Task UpdatePictureBoxImage(Comic comic)
        {
            SavedComicBox.WaitOnLoad = false;
            await Task.Run(() => SavedComicBox.LoadAsync(comic.Img));
        }

        public Task AddToComicList(Comic comic)
        {
            comicListBindingSource.Add(comic);
            return Task.CompletedTask;
        }

        private async Task DeleteFromComicList(Comic comic)
        {
            await Task.Run(() =>
            {
                foreach (Comic item in comicListBindingSource)
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
                var comic = await _mediator.Send(new DBDeleteComicCommand((Comic)ComicList.SelectedItem));
                await DeleteFromComicList(comic);
            }  
        }

        private void SavedComicBox_MouseHover(object sender, EventArgs e)
        {
            if (ComicList.SelectedItem != null)
            {
                Comic comic = (Comic)ComicList.SelectedItem;
                _toolTip.SetToolTip(SavedComicBox, comic.Alt);
            }
        }
    }
}
