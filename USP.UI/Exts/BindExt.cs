using System;
using System.Windows.Forms;

namespace USP.UI
{
    public static class BindExt
    {
        public static void BindToEnumName(this ComboBox cmb, Type enumType, int selectIndex = 0)
        {
            cmb.DataSource = Enum.GetNames(enumType);
        }

        public static T GetSelectedItemToEnum<T>(this ComboBox cmb)
        {
            return (T)Enum.Parse(typeof(T), cmb.SelectedItem.ToString(), false);
        }

        public static void SetSelectedItemToEnum<T>(this ComboBox cmb, T t)
        {
            cmb.SelectedItem = t.ToString();
        }
    }
}
