#region

using System.Collections.Generic;

#endregion

namespace WebScrap.Presenter
{
    public interface IViewScreener
    {
        void ViewLabel(object obj, string s);
        void FillCombobox(object obj, List<string> values);
    }
}