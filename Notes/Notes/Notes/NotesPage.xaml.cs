using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        // When the page loads on the device, this method is called
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Get all the notes in the database, and create a listview of them
            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        // Method to run when the Add Note button is pressed in the toolbar
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage and create a new Note instance
            await Navigation.PushAsync(new NoteEntryPage 
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}