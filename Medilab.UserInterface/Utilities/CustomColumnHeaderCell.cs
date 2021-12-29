using System.ComponentModel;
using System.Windows.Forms;

namespace Medilab.UserInterface.Utilities
{
    public class CustomColumnHeaderCell : DataGridViewColumnHeaderCell
    {
        private ListSortDirection? _sortOrderDirection;
        public ListSortDirection SortOrderDirection {
            get 
            {
                if (_sortOrderDirection == null)
                {
                    _sortOrderDirection = ListSortDirection.Ascending;
                }
                return _sortOrderDirection.Value;
            }
            set
            {
                _sortOrderDirection = value;
            }
        } // defaults to zero = SortOrder.None;

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            switch (_sortOrderDirection)
            {
                    case ListSortDirection.Ascending:
                        SortGlyphDirection = SortOrder.Ascending;
                        break;
                    case ListSortDirection.Descending:
                        SortGlyphDirection = SortOrder.Descending;
                        break;
                    default:
                        SortGlyphDirection = SortOrder.None;
                        break;
            }
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        public override object Clone()
        {
            var result = (CustomColumnHeaderCell)base.Clone();
            result.SortOrderDirection = SortOrderDirection;
            return result;
        }

        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            _sortOrderDirection = (_sortOrderDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            base.OnClick(e);
        }

        public void ResetSortDirection()
        {
            _sortOrderDirection = null;
        }
    }
}
