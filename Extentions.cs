using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace MultiUIThread
{
    public static class NyExtentions
    {

        //Josef Kvita with my additions

        // <summary>
        /// Gets control property. Usage: label1.GetProperty2(() => label1.Text);
        /// </summary>
        public static object GetProperty2<TResult>(this Control @this, Expression<Func<TResult>> property)
        {
            object result = new object();
            try
            {
                var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
                result = @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType).GetValue(@this, null);
            }
            catch (ObjectDisposedException) { }
            return result;
        }

        /// <summary>
        /// Sets control property. Usage: label1.SetProperty2(() => label1.Text, "Zadej cestu k modelu.");
        /// </summary>
        public static void SetProperty2<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        {
            try
            {
                var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;

                if (@this.InvokeRequired)
                {
                    @this.Invoke(new SetPropertySafeDelegate<TResult>(SetProperty2), new object[] { @this, property, value });
                }
                else
                {
                    @this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
                }
            }
            catch (ObjectDisposedException) { }
        }
        private delegate void SetPropertySafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);
    }

}
