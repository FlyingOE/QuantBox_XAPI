﻿using QuantBox.XAPI.Callback;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace QuantBox.XAPI
{
    class Program
    {
        static void OnConnectionStatus(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            Console.WriteLine("333333" + status + userLogin.ErrorMsg());
        }

        static void OnConnectionStatus2(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            Console.WriteLine("22222" + status+userLogin.ErrorMsg());
        }

        static void OnRtnDepthMarketData(object sender, ref DepthMarketDataField marketData)
        {
            Debugger.Log(0, null, "CTP:C#");
            Console.WriteLine(marketData.InstrumentID);
            Console.WriteLine(marketData.ExchangeID);
            Console.WriteLine(marketData.LastPrice);
        }

        static void OnRspQryInstrument(object sender, ref InstrumentField instrument,int size1, bool bIsLast)
        {
            Console.WriteLine(instrument.InstrumentName);
        }

        static void OnRspQryTradingAccount(object sender, ref AccountField account, int size1, bool bIsLast)
        {

        }

        static void OnRspQrySettlementInfo(object sender, ref SettlementInfoField settlementInfo, int size1, bool bIsLast)
        {

        }

        static void OnRtnOrder(object sender, ref OrderField order)
        {
            Console.WriteLine("AA " + order.Status + order.ExecType + order.Text() + "AA " + order.ID + "AA " + order.OrderID);
        }

        static void OnRtnError(object sender, ref ErrorField error)
        {
            Console.WriteLine("BB" + error.ErrorID + error.ErrorMsg());
        }

        static void OnRtnTrade(object sender, ref TradeField trade)
        {
            Console.WriteLine("CC " + trade.Time + "CC " + trade.ID + "CC " + trade.TradeID);
        }

        static void Main(string[] args)
        {
            //for (int i = 0; i < 10000; ++i)
            {
                test_CTP_Main(args);
            }
            Console.ReadKey();
        }

        static void test_Linux_Main(string[] args)
        {
			XApi api = new XApi(@"libQuantBox_CTP_Quote.so");
            XApi api2 = new XApi(@"libQuantBox_CTP_Trade.so");

            api.Server.BrokerID = "1017";
            api.Server.Address = "tcp://ctpmn1-front1.citicsf.com:51213";

            api.User.UserID = "00000015";
            api.User.Password = "123456";

            api.OnConnectionStatus = OnConnectionStatus;
            api.OnRtnDepthMarketData = OnRtnDepthMarketData;

            api2.Server.BrokerID = "1017";
            api2.Server.Address = "tcp://ctpmn1-front1.citicsf.com:51205";
			api2.Server.PrivateTopicResumeType = ResumeType.Quick;

            api2.User.UserID = "00000015";
            api2.User.Password = "123456";


            api2.OnConnectionStatus = OnConnectionStatus2;
            api2.OnRspQryInstrument = OnRspQryInstrument;
            api2.OnRspQryTradingAccount = OnRspQryTradingAccount;
            api2.OnRspQrySettlementInfo = OnRspQrySettlementInfo;
            api2.OnRtnOrder = OnRtnOrder;
            api2.OnRtnError = OnRtnError;
            api2.OnRtnTrade = OnRtnTrade;

            api.Connect();
           	api2.Connect();

            api.Subscribe("IF1502;IF1503", "");

            Console.ReadKey();

			Thread.Sleep (10000);
			Console.WriteLine (123);
            api.Dispose();
            api2.Dispose();
        }

		#region LTS
        static void test_LTS_Main(string[] args)
        {
            XApi api = new XApi("QuantBox_LTS_Quote.dll");
            XApi api2 = new XApi("QuantBox_C2LTS_Trade.dll");

            api.Server.BrokerID = "2010";
            api.Server.Address = "tcp://211.144.195.163:44513";

            api.User.UserID = "00000015";
            api.User.Password = "123456";

            api.OnConnectionStatus = OnConnectionStatus;
            api.OnRtnDepthMarketData = OnRtnDepthMarketData;

            api2.Server.BrokerID = "2010";
            api2.Server.Address = "tcp://211.144.195.163:44505";

            api2.User.UserID = "0020090001134";
            api2.User.Password = "123321";

            api2.OnConnectionStatus = OnConnectionStatus2;
            api2.OnRspQryInstrument = OnRspQryInstrument;
            api2.OnRspQryTradingAccount = OnRspQryTradingAccount;
            api2.OnRspQrySettlementInfo = OnRspQrySettlementInfo;
            api2.OnRtnOrder = OnRtnOrder;
            api2.OnRtnError = OnRtnError;
            api2.OnRtnTrade = OnRtnTrade;

            api.Connect();
            api2.Connect();

            Console.ReadKey();

            api2.ReqQryInstrument("", "");

            Console.ReadKey();

            api.Dispose();
            api2.Dispose();
            //queue.Dispose();
        }
		#endregion

        static XApi api;

        static void test_CTP_Main(string[] args)
        {
            //api = new XApi(@"C:\Program Files\SmartQuant Ltd\OpenQuant 2014\XAPI\CTP\x86\QuantBox_CTP_Quote.dll");

            //api.Server.BrokerID = "1017";
            //api.Server.Address = "tcp://ctpmn1-front1.citicsf.com:51213";
            api = new XApi(@"C:\Program Files\SmartQuant Ltd\OpenQuant 2014\XAPI\CTP\x86\QuantBox_CTP_Trade.dll");

            api.Server.BrokerID = "1017";
            api.Server.Address = "tcp://ctpmn1-front1.citicsf.com:51205";
            api.Server.PrivateTopicResumeType = ResumeType.Undefined;

            api.User.UserID = "00000015";
            api.User.Password = "123456";

            api.OnConnectionStatus = OnConnectionStatus;
            api.OnRtnDepthMarketData = OnRtnDepthMarketData;
            api.OnRspQryInstrument = OnRspQryInstrument;

            api.Connect();
            Thread.Sleep(10 * 1000);
            //api.Subscribe("IF1502", "");
            api.ReqQryInstrument("", "");

            Thread.Sleep(300 * 1000);

            api.Dispose();

            Thread.Sleep(5 * 1000);
        }

        static void test_KingstarStock_Main(string[] args)
        {
            //ApiManager.QueuePath = @"C:\Program Files\SmartQuant Ltd\OpenQuant 2014\XAPI\QuantBox_CTP_Trade.dll";
            api = new XApi(@"C:\Program Files\SmartQuant Ltd\OpenQuant 2014\XAPI\KingstarStock\x86\QuantBox_KingstarStock_Trade.dll");

            api.Server.BrokerID = "1017";
            api.Server.Address = "tcp://ctpmn1-front1.citicsf.com:51205";

            api.User.UserID = "00000015";
            api.User.Password = "1234561";

            api.OnConnectionStatus = OnConnectionStatus;
            api.OnRtnDepthMarketData = OnRtnDepthMarketData;
            api.OnRtnError = OnRtnError;

            api.Connect();

            Thread.Sleep(5 * 1000);

            api.Dispose();

        }

        static void test_KingstarGold_Main(string[] args)
        {
            api = new XApi(@"C:\Program Files\SmartQuant Ltd\OpenQuant 2014\XAPI\KingstarGold\QuantBox_KingstarGold.dll");

            api.Server.BrokerID = "";
            api.Server.Address = "tcp://124.74.239.38:18961";

            api.User.UserID = "9843010200773696";
            api.User.Password = "123456";

            api.OnConnectionStatus = OnConnectionStatus;
            api.OnRtnDepthMarketData = OnRtnDepthMarketData;

            api.Connect();

            Console.ReadKey();
            api.Subscribe("IF1411", "");

            Console.ReadKey();

            api.Dispose();

            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
