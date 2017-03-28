using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.LibUI.Controls;
using static Xamarin.Forms.Platform.LibUI.Interop.NativeMethods;

namespace Sample
{
    public class DataChoosersPage : TabPage
    {
        private HorizontalBox _hBox;
        private VerticalBox _vBox;
        private Grid _grid;
        private Button _button;
        private Entry _entry;
        private Grid _msgGrid;
        private Entry _entry2;

        public DataChoosersPage(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _hBox = new HorizontalBox();
            this.Child = _hBox;

            _vBox = new VerticalBox();
            _hBox.Append(_vBox);

            _vBox.Append(new DatePicker());
            _vBox.Append(new TimePicker());
            _vBox.Append(new DateTimePicker());
            _vBox.Append(new FontButton());
            _vBox.Append(new ColorButton());

            _hBox.Append(new VerticalSeparator());

            _vBox = new VerticalBox() { Padded = true };
            _hBox.Append(_vBox);

            _grid = new Grid();
            _vBox.Append(_grid);

            _button = new Button("Open File");
            _entry = new Entry() {ReadOnly = true};

            _button.Clicked += (sender, args) =>
            {
                var fileName = Window.OpenFile(Program.Window);
                _entry.Text = fileName;
            };

            _grid.Append(_button, 0, 0, 1, 1, 0, uiAlign.Fill, 0, uiAlign.Fill);
            _grid.Append(_entry, 1, 0, 1, 1, 1, uiAlign.Fill, 0, uiAlign.Fill);

            _button = new Button("Save File");
            _entry2 = new Entry() { ReadOnly = true };

            _button.Clicked += (sender, args) =>
            {
                var fileName = Window.SaveFile(Program.Window);
                _entry2.Text = fileName;
            };

            _grid.Append(_button, 0, 1, 1, 1, 0, uiAlign.Fill, 0, uiAlign.Fill);
            _grid.Append(_entry2, 1, 1, 1, 1, 1, uiAlign.Fill, 0, uiAlign.Fill);

            _msgGrid = new Grid();
            _grid.Append(_msgGrid, 0, 2, 2, 1, 0, uiAlign.Center, 0, uiAlign.Start);

            _button = new Button("Message Box");
            _button.Clicked += (sender, args) =>
            {
                Window.MsgBox(Program.Window, "This is a normal message box.", "More detailed information can be shown here.");
            };
            _msgGrid.Append(_button, 0, 0, 1, 1, 0, uiAlign.Fill, 0, uiAlign.Fill);

            _button = new Button("Error Box");
            _button.Clicked += (sender, args) =>
            {
                Window.MsgBoxError(Program.Window, "This message box describes an error.", "More detailed information can be shown here.");
            };
            _msgGrid.Append(_button, 1, 0, 1, 1, 0, uiAlign.Fill, 0, uiAlign.Fill);
        }
    }
}
