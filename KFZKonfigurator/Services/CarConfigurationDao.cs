using System;
using System.Collections.Generic;
using System.Web.SessionState;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.Data;

namespace KFZKonfigurator.Services
{
    public class CarConfigurationDao : IDao<CarConfiguration>
    {
        private static readonly Dictionary<string, object> _httpSession = new Dictionary<string, object>();

        public CarConfigurationDao()
        {
//            _httpSession = ;
        }

        public CarConfiguration Read(Guid id)
        {
            return (CarConfiguration) _httpSession[id.ToString()];
        }

        public CarConfiguration Update(Guid id, string propertyName, object newValue)
        {
            var configuration = Read(id);
            configuration?.GetType().GetProperty(propertyName)?.SetValue(configuration, newValue);
            _httpSession[id.ToString()] = configuration;
            return configuration;
        }
    }
}