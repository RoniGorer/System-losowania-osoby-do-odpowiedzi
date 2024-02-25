using Losowanie.Models;
using Microsoft.Maui.Controls;
using System;

namespace Losowanie
{
    public partial class MainPage : ContentPage
    {
        private List<Person> People;
        private PersonManager PersonManager;

        public MainPage()
        {
            InitializeComponent();
            PersonManager = new PersonManager();
            People = PersonManager.LoadPeople();
        }

        private async void AddPerson_Clicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Add Person", "Enter the name of the person:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                People.Add(new Person { Name = name });
            }
        }

        private async void EditPerson_Clicked(object sender, EventArgs e)
        {
            string selectedPersonName = await DisplayActionSheet("Select Person to Edit", "Cancel", null, People.Select(p => p.Name).ToArray());
            if (selectedPersonName != "Cancel")
            {
                string newName = await DisplayPromptAsync("Edit Person", "Enter the new name:", initialValue: selectedPersonName);
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    var personToEdit = People.FirstOrDefault(p => p.Name == selectedPersonName);
                    if (personToEdit != null)
                    {
                        personToEdit.Name = newName;
                    }
                }
            }
        }

        private async void DeletePerson_Clicked(object sender, EventArgs e)
        {
            string selectedPersonName = await DisplayActionSheet("Select Person to Delete", "Cancel", null, People.Select(p => p.Name).ToArray());
            if (selectedPersonName != "Cancel")
            {
                var personToDelete = People.FirstOrDefault(p => p.Name == selectedPersonName);
                if (personToDelete != null)
                {
                    People.Remove(personToDelete);
                }
            }
        }

        private void SaveList_Clicked(object sender, EventArgs e)
        {
            PersonManager.SavePeople(People);
            DisplayAlert("Success", "List saved successfully!", "OK");
        }

        private void PickRandomPerson_Clicked(object sender, EventArgs e)
        {
            RandomPicker randomPicker = new RandomPicker();
            Person randomPerson = randomPicker.PickRandomPerson(People);
            if (randomPerson != null)
            {
                DisplayAlert("Random Person", $"The randomly picked person is: {randomPerson.Name}", "OK");
            }
            else
            {
                DisplayAlert("Error", "No people available to pick from.", "OK");
            }
        }
    }
}