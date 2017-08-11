using Autofac;
using Autofac.Core;

namespace DIAutoFac
{
    internal class DataModule : Module
    {
        private string _connStr;

        public DataModule(string connStr)
        {
            this._connStr = connStr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DIAutoFacContext(_connStr)).InstancePerRequest();
            base.Load(builder);
        }
    }
}