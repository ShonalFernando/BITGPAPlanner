using UnitTester.View.ViewPainter;

internal class Program
{
    private static void Main(string[] args)
    {
        SubjectsViewer _subjectsViewer = new();

        Dictionary<string, Action> menuItems = new Dictionary<string, Action>
        {
            { "Option 1", _subjectsViewer.ViewSubjectsMenu},
            { "Option 2", _subjectsViewer.ViewSubjectsMenu },
            { "Option 3", _subjectsViewer.ViewSubjectsMenu}
        };

        MenuPainter menu = new MenuPainter(menuItems);
        menu.ShowMenu();
    }
}