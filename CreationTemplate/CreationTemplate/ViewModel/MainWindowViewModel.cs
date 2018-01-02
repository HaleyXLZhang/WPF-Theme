/*
* ==============================================================================
*
* File name: MainWindowViewModel.cs
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
using CreationTemplate.Common;
using CreationTemplate.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace CreationTemplate.ViewModel
{
    public class MainWindowViewModel : NotifyObject
    {
        //start
        /// <summary>
        /// TextBox Binding case
        /// </summary>
        private string _textBoxValue = "TestMVVM";
        public string TextBoxValue
        {
            get { return _textBoxValue; }

            set
            {
                if (_textBoxValue != value)
                {
                    _textBoxValue = value;

                    RaisePropertyChanged("TextBoxValue");
                }
            }
        }
        //end

        //start
        /// <summary>
        /// DropDownList Binding Case
        /// </summary>
        private ObservableCollection<Person> personList = Person.SouthPark;
        public ObservableCollection<Person> PersonList
        {
            get { return personList; }
        }
        //end

        //start
        /// <summary>
        /// DorpDownList get Binding data  Case
        /// </summary>
        private Person _dropDownListSelectedPerson = null;
        public Person DropDownListSelectedPerson
        {
            get
            {
                return _dropDownListSelectedPerson;
            }
            set
            {
                if (_dropDownListSelectedPerson != value)
                {
                    _dropDownListSelectedPerson = value;
                    RaisePropertyChanged("DropDownListSelectedPerson");
                }
            }
        }
        //end


        //start
        /// <summary>
        /// Command Binding Case
        /// </summary>
        private bool _canExecute;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                _canExecute = value;
                RaisePropertyChanged("CanExecute");
            }
        }
        private MyCommand _canExecuteCommand;
        public MyCommand CanExecuteCommand
        {
            get
            {
                if (_canExecuteCommand == null)
                    _canExecuteCommand = new MyCommand(
                        new Action<object>(
                            o => MessageBox.Show("命令可以执行！")),
                        new Func<object, bool>(
                            o => CanExecute));
                return _canExecuteCommand;
            }
        }
        //end
    }
}
