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

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CreationTemplate.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel()
        {
            Messenger.Default.Register<GenericMessage<string>>(this, "Save", msg =>
            {

                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new System.Windows.Forms.MethodInvoker(() =>
                {
                    MessageList.Add(msg.Content);
                }));
            });
        }


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




        private ObservableCollection<Reason> reasonList = Reason.GetReaons();

        public ObservableCollection<Reason> ReasonList
        {

            get { return reasonList; }
        }



        private ObservableCollection<string> messageList = new ObservableCollection<string>();
        public ObservableCollection<string> MessageList
        {
            get { return messageList; }
            set
            {
                if (messageList != value)
                {
                    messageList = value;
                    RaisePropertyChanged("MessageList");
                }
            }
        }

        //start
        /// <summary>
        /// DropDownList Binding Case
        /// </summary>
        private ObservableCollection<Person> personList = Person.SouthPark;
        public ObservableCollection<Person> PersonList
        {
            get { return personList; }
            set
            {
                if (personList != value)
                {
                    personList = value;
                    RaisePropertyChanged("PersonList");
                }
            }
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







        private string runContent = "Run";

        public string RunContent
        {

            get { return runContent; }
            set
            {
                if (runContent != value)
                {
                    runContent = value;
                    RaisePropertyChanged("RunContent");
                }
            }
        }









        //start
        /// <summary>
        /// Command Binding Case
        /// </summary>
        private bool _canExecute = true;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    RaisePropertyChanged("CanExecute");
                }
            }
        }

        private RelayCommand _canExecuteCommand;
        public RelayCommand CanExecuteCommand
        {
            get
            {

                if (_canExecuteCommand == null)
                    _canExecuteCommand = new RelayCommand(() =>
                            {
                                CancellationTokenSource cancellTokenSource = new CancellationTokenSource();
                                TaskFactory taskFactory = new TaskFactory();
                                if (RunContent == "Cancel")
                                {
                                    RunContent = "Run";
                                    cancellTokenSource.Cancel();
                                }
                                taskFactory.StartNew(() =>
                                {
                                    RunContent = "Cancel";

                                    while (true)
                                    {
                                        if (cancellTokenSource.IsCancellationRequested)
                                        {
                                            break;
                                        }

                                        Thread.Sleep(500);
                                    }

                                }, cancellTokenSource.Token);
                            });
                return _canExecuteCommand;
            }
        }
        //end


        private RelayCommand _executeCommand;
        public RelayCommand ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                    _executeCommand = new RelayCommand(() =>
                    {
                        CanExecute = false;
                        TaskFactory taskFactory = new TaskFactory();
                        int count = 0;
                        taskFactory.StartNew(() =>
                        {




                            while (true)
                            {
                                if (count > 100)
                                {
                                    break;
                                }
                                count++;
                                Thread.Sleep(1000);

                                Messenger.Default.Send<GenericMessage<string>>(new GenericMessage<string>("Hello,world"), "Save");
                            }

                            CanExecute = true;
                        });
                    });
                return _executeCommand;
            }
        }





    }
}
