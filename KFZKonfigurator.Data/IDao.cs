using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFZKonfigurator.Data
{
    public interface IDao<TModel>
    {
        TModel Read(Guid id);

        TModel Update(Guid id, string propertyName, object newValue);
    }
}