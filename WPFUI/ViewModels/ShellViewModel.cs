﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Tim";
        private string _lastName;
        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "123", LastName = "345" });
            People.Add(new PersonModel { FirstName = "5325", LastName = "456" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }

        }

        public string FullName
        {
            get { return $"{ FirstName} {LastName}"; }
        }


        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; ; }
            set
            {
                _selectedPerson = value; NotifyOfPropertyChange(() => SelectedPerson);
            }
        }


        public bool CanClearText(string firstName, string lastName)/* => !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);*/
        {
            //return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);

            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }


        }
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChilViewModel());
        }

    }
}
