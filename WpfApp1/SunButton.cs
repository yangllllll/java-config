using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class SunButton : Button
    {
        #region 属性
        public int BorderRadius
        {
            get { return (int)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }

        }

        public static readonly DependencyProperty BorderRadiusProperty = DependencyProperty.Register("BorderRadius", typeof(int), typeof(SunButton), new FrameworkPropertyMetadata());

        #endregion 属性

    }

}
