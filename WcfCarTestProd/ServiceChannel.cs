using Prototypes.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WcfCarTestProd
{
    public static class ServiceChannel
    {
        private static readonly TimeSpan _timeout = SetTimeout();
        private static ChannelFactory<IService> _channel;

        private static readonly object _locker = new object();
        private static IService _service;
        public static IService GetService
        {
            get
            {

                if (_service == null || _channel.State != CommunicationState.Opened)
                {
                    lock (_locker)
                    {
                        if (_service == null || _channel.State != CommunicationState.Opened)
                        {

                            string uri = string.Format("net.tcp://172.30.190.37:19030/sampleService");
                            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                            XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas
                            {
                                MaxStringContentLength = int.MaxValue,
                                MaxArrayLength = int.MaxValue,
                                MaxBytesPerRead = int.MaxValue,
                                MaxDepth = int.MaxValue,
                                MaxNameTableCharCount = int.MaxValue
                            };

                            binding.GetType().GetProperty("ReaderQuotas").SetValue(binding, myReaderQuotas, null);

                            binding.MaxBufferSize = int.MaxValue;
                            binding.MaxReceivedMessageSize = int.MaxValue;
                            _channel = new ChannelFactory<IService>(binding);

                            _channel.Faulted += ChannelFaulted;
                            _channel.Closing += ChannelClosing;

                            EndpointAddress endPoint = new EndpointAddress(uri);

                            binding.OpenTimeout = _timeout;
                            binding.CloseTimeout = _timeout;
                            binding.SendTimeout = _timeout;
                            binding.ReceiveTimeout = _timeout;
                            binding.ReliableSession.Enabled = true;
                            binding.ReliableSession.InactivityTimeout = _timeout;

                            _service = _channel.CreateChannel(endPoint);


                        }
                    }

                }
                return _service;
            }
        }

        private static void ChannelClosing(object sender, EventArgs e)
        {
            AbortChannel();
        }

        private static void ChannelFaulted(object sender, EventArgs e)
        {
            AbortChannel();
        }

        public static void AbortChannel()
        {
            if (_channel != null)
            {
                _channel.Abort();
            }
        }

        /// <summary>
        /// create new instance of TimeSpan from app.config value
        /// </summary>
        /// <returns></returns>
        private static TimeSpan SetTimeout()
        {
            return new TimeSpan(9, 0, 0);
        }

        /// <summary>
        /// This function is for testing connection before every call 
        /// if the CheckStatus throw exception we abort channel,
        /// so the next call will be through new channel
        /// </summary>
        public static void CheckStatus()
        {
            try
            {
                GetService.CheckStatus();
            }
            catch (Exception)
            {
                AbortChannel();
            }
        }

    }
}
