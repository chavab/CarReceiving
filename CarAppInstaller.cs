using CarReceivingApp.Prototypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WCFCarReceivingAppTest
{
    partial class CarAppInstaller : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public static void Main()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
                ServiceBase.Run(new CarAppInstaller());
            else
            {
                var a = new CarAppInstaller();
                a.OnStart(new string[] { "" });
                Console.ReadLine();
            }
        }
        public CarAppInstaller()
        {
            ServiceName = "WCFCarReceivingAppTest";
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null) serviceHost.Close();

            string strAdrHTTP = "http://localhost:9017/WCFCarReceivingAppTest";
            string strAdrTCP = "net.tcp://localhost:9032/WCFCarReceivingAppTest";

            Uri[] adrbase = { new Uri(strAdrHTTP), new Uri(strAdrTCP) };
            serviceHost = new ServiceHost(typeof(CarAppService), adrbase);

            ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
            //   serviceHost.Description.Behaviors.Add(mBehave);

            BasicHttpBinding httpb = new BasicHttpBinding();
            serviceHost.AddServiceEndpoint(typeof(IService), httpb, strAdrHTTP);
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
            MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            NetTcpBinding tcpb = new NetTcpBinding(SecurityMode.None);
            serviceHost.AddServiceEndpoint(typeof(IService), tcpb, strAdrTCP);
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
            MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

    }
}
