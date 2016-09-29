namespace WebScrap.Presenter
{
    public interface IViewMain
    {
        void GetData(object obj, object obj1, string ticker);
        void ViewLabel(object obj, string s);
        void ViewTextBox(object obj, string s);
    }
}