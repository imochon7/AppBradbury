using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBradbury.Utilities
{
    public class Preferences
    {
        private Color _primaryColor;

        public Color PrimaryColor
        {
            get { return _primaryColor = Color.FromHex("#3a4750"); }
        }

        private Color _secondaryColor;

        public Color SecondaryColor
        {
            get { return _secondaryColor = Color.FromHex("#be3144"); }
        }

    }
}
