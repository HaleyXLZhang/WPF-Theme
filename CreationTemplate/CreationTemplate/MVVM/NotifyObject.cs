/*
* ==============================================================================
*
* File name: NotifyObject.cs
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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CreationTemplate.MVVM
{
    public class NotifyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
