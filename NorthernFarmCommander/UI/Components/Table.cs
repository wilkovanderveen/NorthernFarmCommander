namespace NorthernFarmCommander.UI.Components
{
    public class Table
    {
        private IList<Column> _columns;

        public Table(ConsoleColor panelBackgroundColor, ConsoleColor titleColor, ConsoleColor foregroundColor, int width, int height)
        {
            _columns = new List<Column>();
            PanelBackgroundColor = panelBackgroundColor;
            TitleColor = titleColor;
            ForegroundColor = foregroundColor;
            Width = width;
            Height = height;
        }

        public IEnumerable<Column> Columns
        {
            get
            {
                return _columns;
            }
        }

        public ConsoleColor PanelBackgroundColor { get; }
        public ConsoleColor TitleColor { get; }
        public ConsoleColor ForegroundColor { get; }
        public int Width { get; }
        public int Height { get; }

        public void Draw()
        {
            foreach (Column column in Columns)
            {
                if (column != _columns.Last())
                {
                    column.Draw();
                  
                    continue;
                }
                column.Draw(drawSeparator: false);
            }
        }

        internal void AddColumn(string name, int percentage)
        {
            int columnWidth = (int)((float)Width / 100 * percentage);
            _columns.Add(new Column(name, columnWidth, Height, PanelBackgroundColor, TitleColor, ForegroundColor));
        }
    }
}