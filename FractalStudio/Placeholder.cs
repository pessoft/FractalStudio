using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;


namespace FractalStudio
{
    [ProvideProperty("Placeholder", typeof(Control))]

    public class Placeholder :  Component,IExtenderProvider
    {
        private struct PlaceProperty
        {
            public string value;
            public Font font;
            public Color foreColor;
            public bool isText;
        }

        public Placeholder()
        {
            
            _collectionPlaceholder = new Dictionary<Control, PlaceProperty>();
        }
        
        Dictionary<Control, PlaceProperty> _collectionPlaceholder;
        
        public bool CanExtend(object extendee)
        {
            bool result = false;

            if ((extendee is TextBox) ||
                (extendee is ComboBox))
                result = true;

            return result;
        }

        [Description("Выводит текст внутри текстового поля, который исчезает при получении фокуса")]
        [DisplayName("Placeholder")]
        [Category("Внешний вид")]
               public string GetPlaceholder(Control control)
        {
            string result = "";
            if (_collectionPlaceholder.ContainsKey(control))
                result = _collectionPlaceholder[control].value;

            return result;
        }

        
        private void SetPlaceholder(Control control)
        {
            PlaceProperty placeProperty = _collectionPlaceholder[control];
            if (Site==null)
            {
                control.Font = new Font(placeProperty.font, FontStyle.Italic);
                control.ForeColor = Color.Gray;
            }

            control.Text = placeProperty.value;
            placeProperty.isText = false;

            _collectionPlaceholder[control] = placeProperty;
        }

        
        public void SetPlaceholder(Control control, string value)
        {

            PlaceProperty placeProperty = new PlaceProperty();
            placeProperty.font = new Font(control.Font, control.Font.Style);
            placeProperty.foreColor = control.ForeColor;
            placeProperty.value = value;
            placeProperty.isText = false;

            if (_collectionPlaceholder.ContainsKey(control))
                _collectionPlaceholder.Remove(control);
            _collectionPlaceholder.Add(control, placeProperty);

            control.Enter += ControlEnter;
            control.Leave += ControlLeave;
            control.PreviewKeyDown += ControlPreviewKeyDown;
            control.TextChanged += ControlTextChanged;

            SetPlaceholder(control);
        }

        private void ControlPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Control control = (Control)sender;
            PlaceProperty placeProperty = _collectionPlaceholder[control];

            placeProperty.isText = true;

            if (control.Text.Trim().Length == 0 && !char.IsLetterOrDigit((char)e.KeyValue))
                placeProperty.isText = false;

            _collectionPlaceholder[control] = placeProperty;

        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            PlaceProperty placeProperty = _collectionPlaceholder[control];

            string text = control.Text;
            if (text.Length == 0 )
                placeProperty.isText = false;

            _collectionPlaceholder[control] = placeProperty;
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            PlaceProperty placeProperty = _collectionPlaceholder[control];

            control.ForeColor = placeProperty.foreColor;
            control.Font = new Font(placeProperty.font, placeProperty.font.Style);

            if (!placeProperty.isText)
                SetPlaceholder(control);
        }

        private void ControlEnter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            PlaceProperty placeProperty = _collectionPlaceholder[control];

            control.ForeColor = placeProperty.foreColor;
            control.Font = new Font(placeProperty.font, placeProperty.font.Style);

            if (!placeProperty.isText)
                control.Text = "";
        }

    }
}
