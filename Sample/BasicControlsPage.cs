using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.LibUI.Controls;

namespace Sample
{
    public class BasicControlsPage : TabPage
    {
        private VerticalBox _verticalBox;
        private HorizontalBox _horizontalBox;
        private Group _group;
        private Form _form;

        private Button _button;
        private Checkbox _checkBox;
        private Label _label;

        private HorizontalSeparator _horizontalSeparator;

        private Entry _entry;
        private PasswordEntry _passwordEntry;
        private SearchEntry _searchEntry;
        private MultilineEntry _multilineEntry;
        private MultilineEntry _multilineNoWrappingEntry;

        public BasicControlsPage(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _verticalBox = new VerticalBox {Padded = true};
            this.Child = _verticalBox;
            _horizontalBox = new HorizontalBox {Padded = true};
            _verticalBox.Append(_horizontalBox);
            _button = new Button("Button");
            _horizontalBox.Append(_button);
            _checkBox = new Checkbox("CheckBox");
            _horizontalBox.Append(_checkBox);
            _label = new Label("This is a label. Right now, labels can only span one line.");
            _verticalBox.Append(_label);
            _horizontalSeparator = new HorizontalSeparator();
            _verticalBox.Append(_horizontalSeparator);
            _group = new Group("Entries") { Margined = true};
            _verticalBox.Append(_group, true);
            _form = new Form {Padded = true};
            _group.Child = _form;
            _entry = new Entry();
            _form.Append("Entry", _entry);
            _passwordEntry = new PasswordEntry();
            _form.Append("Password Entry", _passwordEntry);
            _searchEntry = new SearchEntry();
            _form.Append("Search Entry", _searchEntry);
            _multilineEntry = new MultilineEntry();
            _form.Append("Multiline Entry", _multilineEntry, true);
            _multilineNoWrappingEntry = new NonWrappingMultilineEntry();
            _form.Append("Multiline Entry No Wrap", _multilineNoWrappingEntry, true);
        }
    }
}
