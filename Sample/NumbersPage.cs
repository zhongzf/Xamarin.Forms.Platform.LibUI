using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.LibUI.Controls;

namespace Sample
{
    public class NumbersPage : TabPage
    {
        private HorizontalBox _hBox;
        private Group _group;
        private VerticalBox _vBox;
        private ProgressBar _ip;
        private Combobox _comboBox;
        private EditableCombobox _editableComboBox;
        private RadioButtons _radioButtons;

        private Spinbox _spinBox;
        private Slider _slider;
        private ProgressBar _progressBar;

        public NumbersPage(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _hBox = new HorizontalBox() {Padded = true};
            this.Child = _hBox;

            _group = new Group("Numbers") {Margined = true};
            _hBox.Append(_group, true);

            _vBox = new VerticalBox() {Padded = true};
            _group.Child = _vBox;

            _spinBox = new Spinbox(0, 100);
            _slider = new Slider(0, 100);

            _progressBar = new ProgressBar();

            _spinBox.Changed += (sender, args) =>
            {
                var value = _spinBox.Value;
                _slider.Value = value;
                _progressBar.Value = value;
            };

            _slider.Changed += (sender, args) =>
            {
                var value = _slider.Value;
                _spinBox.Value = value;
                _progressBar.Value = value;
            };

            _vBox.Append(_spinBox);
            _vBox.Append(_slider);
            _vBox.Append(_progressBar);

            _ip = new ProgressBar();
            _ip.Value = -1;
            _vBox.Append(_ip);

            _group = new Group("Lists") {Margined = true};
            _hBox.Append(_group, true);

            _vBox = new VerticalBox() {Padded = true};
            _group.Child = _vBox;

            _comboBox = new Combobox();
            _comboBox.Append("Combobox Item 1");
            _comboBox.Append("Combobox Item 2");
            _comboBox.Append("Combobox Item 3");
            _vBox.Append(_comboBox);

            _editableComboBox = new EditableCombobox();
            _editableComboBox.Append("Editable Item 1");
            _editableComboBox.Append("Editable Item 2");
            _editableComboBox.Append("Editable Item 3");
            _vBox.Append(_editableComboBox);

            _radioButtons = new RadioButtons();
            _radioButtons.Append("Radio Button 1");
            _radioButtons.Append("Radio Button 2");
            _radioButtons.Append("Radio Button 3");
            _vBox.Append(_radioButtons);
        }
    }
}
