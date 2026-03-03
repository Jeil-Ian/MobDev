using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace ToDoMaui_Listview
{
    public partial class MainPage : ContentPage
    {
        // ObservableCollection to automatically update the ListView
        ObservableCollection<ToDoClass> toDoItems;

        int currentId = 1; // Unique ID generator
        ToDoClass? selectedItem = null; // Currently selected item for editing

        public MainPage()
        {
            InitializeComponent();

            // Initialize the list and bind it to the ListView
            toDoItems = new ObservableCollection<ToDoClass>();
            todoLV.ItemsSource = toDoItems;
        }

        // Add a new ToDo item
        private void AddToDoItem(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleEntry.Text))
                return;

            var newItem = new ToDoClass
            {
                id = currentId++,
                title = titleEntry.Text,
                detail = detailsEditor.Text
            };

            toDoItems.Add(newItem);

            // Clear input fields
            titleEntry.Text = string.Empty;
            detailsEditor.Text = string.Empty;
        }

        // Delete a ToDo item
        private void DeleteToDoItem(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int idToDelete = int.Parse(btn.ClassId);

            var item = toDoItems.FirstOrDefault(x => x.id == idToDelete);
            if (item != null)
                toDoItems.Remove(item);
        }

        // Handle selection from ListView for editing
        private void TodoLV_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            selectedItem = (ToDoClass)e.SelectedItem;

            // Load selected values into input fields
            titleEntry.Text = selectedItem.title;
            detailsEditor.Text = selectedItem.detail;

            // Toggle buttons
            addBtn.IsVisible = false;
            editBtn.IsVisible = true;
            cancelBtn.IsVisible = true;
        }

        // Edit the selected ToDo item
        private void EditToDoItem(object sender, EventArgs e)
        {
            if (selectedItem == null)
                return;

            selectedItem.title = titleEntry.Text;
            selectedItem.detail = detailsEditor.Text;

            // Reset UI
            titleEntry.Text = string.Empty;
            detailsEditor.Text = string.Empty;
            addBtn.IsVisible = true;
            editBtn.IsVisible = false;
            cancelBtn.IsVisible = false;
            todoLV.SelectedItem = null;

            selectedItem = null;
        }

        // Cancel the edit
        private void CancelEdit(object sender, EventArgs e)
        {
            selectedItem = null;
            titleEntry.Text = string.Empty;
            detailsEditor.Text = string.Empty;
            addBtn.IsVisible = true;
            editBtn.IsVisible = false;
            cancelBtn.IsVisible = false;
            todoLV.SelectedItem = null;
        }
    }
}