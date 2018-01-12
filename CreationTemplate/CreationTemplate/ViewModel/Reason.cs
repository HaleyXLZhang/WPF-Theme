using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CreationTemplate.ViewModel
{
    public class Reason
    {
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public bool IsChecked { get; set; }

        public static ObservableCollection<Reason> GetReaons()
        {
            ObservableCollection<Reason> reasons = new ObservableCollection<Reason>();
            reasons.Add(new Reason() { ShortCode = "SA" });
            reasons.Add(new Reason() { ShortCode = "SB" });
            reasons.Add(new Reason() { ShortCode = "SC" });
            reasons.Add(new Reason() { ShortCode = "SD" });
            reasons.Add(new Reason() { ShortCode = "SE" });
            reasons.Add(new Reason() { ShortCode = "SF" });
            reasons.Add(new Reason() { ShortCode = "SG" });
            return reasons;
        }
    }
}
