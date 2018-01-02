/*
* ==============================================================================
*
* File name: Person.cs
* Description: 
* 
*
* Version: 1.0
* Created: 1/3/2018 1:16:30 AM
*
* Author: Haley X L Zhang
* Company: Chinasoft International
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CreationTemplate.ViewModel
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public static ObservableCollection<Person> SouthPark = new ObservableCollection<Person>() {
            new Person() { Name = "Eric", Surname="Cartman" },
            new Person() { Name = "Stan", Surname="Marsh" },
            new Person() { Name = "Kyle", Surname="Broflovski" },
            new Person() { Name = "Kenny", Surname="McCormick" },
            new Person() { Name = "Bebe", Surname="Stevens" },
            new Person() { Name = "Clyde", Surname="Donovan" },
            new Person() { Name = "Craig", Surname="Tucker" },
            new Person() { Name = "Jimmy", Surname="Vulmer" },
            new Person() { Name = "Pip", Surname="Pirrup" },
            new Person() { Name = "Token", Surname="Black" },
            new Person() { Name = "Tweek", Surname="Tweak" },
            new Person() { Name = "Wendy", Surname="Testaburger" },
            new Person() { Name = "Annie", Surname="Polk" },
            new Person() { Name = "Randy", Surname="Marsh" },
            new Person() { Name = "Sharon", Surname="Marsh" },
            new Person() { Name = "Shelley", Surname="Marsh" },
            new Person() { Name = "Marvin", Surname="Marsh" },
            new Person() { Name = "Jimbo", Surname="Kern" },
            new Person() { Name = "Gerald", Surname="Broflovski" },
            new Person() { Name = "Sheila", Surname="Broflovski" },
            new Person() { Name = "Ike", Surname="Broflovski" },
            new Person() { Name = "Kyle", Surname="Schwartz" },
            new Person() { Name = "Liane", Surname="Cartman" },
            new Person() { Name = "Stuart", Surname="McCormick" },
            new Person() { Name = "Carol", Surname="McCormick" },
            new Person() { Name = "Kevin", Surname="McCormick" },
            new Person() { Name = "Stephen", Surname="Stotch" },
            new Person() { Name = "Linda", Surname="Stotch" },
            new Person() { Name = "Richard", Surname="Tweak" }
        };
    }
}
