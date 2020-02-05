using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNT.Core.Helpers.Data
{
    public class DataProcessing
    {
        private const SelectOption byJsonProperty = SelectOption.ByJsonProperty;

        public IEnumerable<object> getIEnumerable(IEnumerable<object> list, string[] param)
        {
            return list.SelectOnly(false, byJsonProperty, param);
        }

        public IQueryable<object> getIQueryable(IQueryable<object> list, string[] param)
        {
            return list.SelectOnly(false, byJsonProperty, param);
        }
    }
}
