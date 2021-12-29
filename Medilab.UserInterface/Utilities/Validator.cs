using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Utilities
{
    public class Validator
    {
        public static bool RequiredFieldValidator(TextBox control, ErrorProvider errorProvider)
        {
            if (string.IsNullOrEmpty(control.Text) || string.IsNullOrWhiteSpace(control.Text))
            {
                errorProvider.SetError(control, "Este campo es requerido");
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }
        public static bool RequiredFieldValidator(MaskedTextBox control, ErrorProvider errorProvider)
        {
            if (string.IsNullOrEmpty(control.Text) || string.IsNullOrWhiteSpace(control.Text))
            {
                errorProvider.SetError(control, "Este campo es requerido");
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }

        public static bool RequiredFieldValidator(CheckedListBox control, ErrorProvider errorProvider)
        {
            if (control.CheckedItems.Count == 0)
            {
                errorProvider.SetError(control, "Debe seleccionar al menos una opcion");
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }

        public static bool CompareFieldValidator(TextBox firstControl, TextBox secondControl,
                                                 ErrorProvider errorProvider)
        {
            if (!firstControl.Text.Equals(secondControl.Text))
            {
                errorProvider.SetError(secondControl, "Las claves no coinciden");
                return false;
            }
            errorProvider.SetError(secondControl, string.Empty);
            return true;
        }

        public static bool MinLengthValidator(TextBox control, int minLength, ErrorProvider errorProvider)
        {
            if (control.Text.Length < minLength)
            {
                errorProvider.SetError(control, string.Format("La longitud minima es de {0} caracteres", minLength));
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }

        public static bool InvalidCharsValidator(TextBox control, string charList, ErrorProvider errorProvider)
        {
            var charArray = charList.ToCharArray();
            if (control.Text.IndexOfAny(charArray) > 0)
            {
                var list = string.Join(",", charArray);
                errorProvider.SetError(control, string.Format("El texto no debe contener {0}", list));
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }

        public static bool RequiredFieldValidator(ComboBox control, ErrorProvider errorProvider)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                errorProvider.SetError(control, "Debe seleccionar al menos una opción");
                return false;
            }
            if (control.SelectedItem == null)
            {
                errorProvider.SetError(control, "La opción seleccionada no es válida.");
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }

        public static bool CheckNotNullValidator(Control control, ErrorProvider errorProvider, object objectToCheck)
        {
            if (objectToCheck == null)
            {
                errorProvider.SetError(control, "Ingrese un dato válido");
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }

        public static bool RequiredCommentValidator(Control container, ErrorProvider errorProvider, string requiredValueForComment, TextBox control)
        {
            var radioButton = container.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (radioButton != null)
            {
                var tagValue = radioButton.Tag.ToString();
                if (tagValue.Equals(requiredValueForComment))
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        errorProvider.SetError(control, "Debe agregar un comentario");
                        return false;
                    }
                }
                errorProvider.SetError(control, string.Empty);
                return true;
            }
            return true;
        }

        public static bool RequiredCommentValidator(Control container, ErrorProvider errorProvider, TextBox control)
        {
            return RequiredCommentValidator(container, errorProvider, "Patologico", control);
        }

        public static bool RangeValidator(int value, int lowerLimit, int upperLimit, Control control,
                                          ErrorProvider errorProvider)
        {
            if (value >= lowerLimit && value <= upperLimit)
            {
                errorProvider.SetError(control, string.Empty);
                return true;
            }
            errorProvider.SetError(control,
                                       string.Format("El valor debe estar entre {0} y {1}", lowerLimit, upperLimit));
            return false;
        }

        public static bool CheckIntType(TextBox control, ErrorProvider errorProvider)
        {
            int result;
            if (int.TryParse(control.Text, out result))
            {
                errorProvider.SetError(control, string.Empty);
                return true;
            }
            errorProvider.SetError(control, "El valor debe ser un número entero");
            return false;
        }
        public static bool CheckDoubleType(TextBox control, ErrorProvider errorProvider)
        {
            double result;
            if (double.TryParse(control.Text, out result))
            {
                errorProvider.SetError(control, string.Empty);
                return true;
            }
            errorProvider.SetError(control, "El valor debe ser un número");
            return false;
        }
        public static bool RangeValidator(double value, double lowerLimit, double upperLimit, Control control,
                                          ErrorProvider errorProvider)
        {
            if (value >= lowerLimit && value <= upperLimit)
            {
                errorProvider.SetError(control, string.Empty);
                return true;
            }
            errorProvider.SetError(control,
                                       string.Format("El valor debe estar entre {0} y {1}", lowerLimit, upperLimit));
            return false;
        }
        public static bool GraterThanValidator(double value, double lowerLimit, Control control, ErrorProvider errorProvider)
        {
            if (value > lowerLimit)
            {
                errorProvider.SetError(control, string.Empty);
                return true;
            }
            errorProvider.SetError(control,
                                       string.Format("El valor debe ser mayor que {0}", lowerLimit));
            return false;
        }

        public static bool MaxNumberOfItemsValidator(CheckedListBox control, int maxNumber, ErrorProvider errorProvider)
        {
            if (control.CheckedItems.Count > maxNumber)
            {
                errorProvider.SetError(control, string.Format("Debe seleccionar {0} opciones como máximo", maxNumber));
                return false;
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }
    }
}
