﻿using System;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            // Loop through the directory and open each .notes.txt file and read it, then add it to a list
            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            // Note take the notes list, and create a list view using it
            listView.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList();
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