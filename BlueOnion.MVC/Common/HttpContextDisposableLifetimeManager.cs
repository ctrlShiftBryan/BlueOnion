using Microsoft.Practices.Unity;
using System;
using System.Threading;
using System.Web;

namespace BlueOnion.MVC.Common
{
    public class HttpContextDisposableLifetimeManager<T> : LifetimeManager, IDisposable
    {
        //gereate a key for the thread
        private string GetKey()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            return (typeof(T).AssemblyQualifiedName + threadId);
        }

        //get the value by key
        public override object GetValue()
        {
            var key = GetKey();

            return HttpContext.Current.Items[key];
        }

        //remove the value
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(GetKey());
        }

        //set value
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[GetKey()]
                = newValue;
        }

        //dispose
        public void Dispose()
        {
            var obj = (IDisposable)GetValue();
            obj.Dispose();
        }
    }
}