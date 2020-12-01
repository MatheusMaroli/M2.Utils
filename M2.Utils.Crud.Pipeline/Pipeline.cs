using System;
using System.Reflection;
using System.Threading.Tasks;

namespace M2.Utils.Crud.Pipeline
{
    public class Pipeline
    {
        private bool _stopPropagation = false;
        private string _assemblyName = "";

        public void StopPropagation() => _stopPropagation = true;

        public  Pipeline(string assemblyName)
        {
            _assemblyName = assemblyName;
        }

        public Task<object> Do(object command)
        {
            var assembly = Assembly.Load(_assemblyName);
            var classes = assembly.GetTypes();
            foreach (var _class in classes) 
                System.Console.WriteLine(_class.FullName);
            return null;
        }

        
    }

}
