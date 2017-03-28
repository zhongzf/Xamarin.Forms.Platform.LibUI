using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.LibUI.Controls;

namespace Sample
{
    public class MainWindow : Window
    {
        private Tab _tab;
        private BasicControlsPage _basicControlsPage;
        private NumbersPage _numbersPage;
        private DataChoosersPage _dataChoosersPage;

        public MainWindow(string title = "Sample", int width = 500, int height = 200, bool hasMemubar = false) : base(title, width, height, hasMemubar)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._tab = new Tab();
            this.Child = this._tab;

            this._basicControlsPage = new BasicControlsPage("Basic Controls");
            this._tab.Append(this._basicControlsPage);

            this._numbersPage = new NumbersPage("Numbers and Lists");
            this._tab.Append(this._numbersPage);

            this._dataChoosersPage = new DataChoosersPage("Data Choosers");
            this._tab.Append(this._dataChoosersPage);
        }
    }
}
