//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net;
//using System.Net.Sockets;
//using System.IO;
//using DBA.Structure;

//namespace DBA_Server_Test.Transit_Agent
//{
//    class TransitAgent
//    {
//        Socket Listener;
//        Socket Prime;
//        IPEndPoint IPE;
//        //XML.XMLParser Parser = new XML.XMLParser();

//        int Port;
//        const int BufferSize = 8192;

//        bool verified = false;

//        byte[] buffer;

//        public TransitAgent(int port)
//        {
//            Parser.ParseDeclaration();
//            Parser.parseServer();

//            IPE = new IPEndPoint(IPAddress.Any, 2271);
//            Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            Listener.Bind(IPE);
//            Listener.Listen(120);

//            while (true)
//            {
//                Prime = Listener.Accept();
//                Standby();
//            }
//        }

//        void Standby()
//        {
//            while (true)
//            {
//                buffer = new byte[8192];
//                Prime.Receive(buffer, 0, 8192, SocketFlags.None);
//                string Recieved = System.Text.Encoding.UTF8.GetString(buffer).Replace("\0","");
//                if (Recieved.Contains("Verify"))
//                {
//                    string S = Recieved.Replace("Verify", "");
//                    if (Server.Verify(S))
//                    {
//                        verified = true;
//                        buffer = null;
//                        buffer = Encoding.Default.GetBytes("Verified");
//                        Prime.Send(buffer);
//                    }
//                    else
//                    {
//                        verified = true;
//                        buffer = null;
//                        buffer = Encoding.Default.GetBytes("Credentials incorrect");
//                        Prime.Send(buffer);
//                        break;
//                    }
//                }
//                else if (Recieved.Contains("Terminate") && verified)
//                {
//                    break;
//                }
//                else if (Recieved.Contains("Survey Server") && verified)
//                {
//                    buffer = null;
//                    string DBsSt = "";

//                    foreach (Database db in Server.DBS)
//                    {
//                        DBsSt += db.Name+"~";
//                    }
//                    buffer = BitConverter.GetBytes(DBsSt.Length);
//                    Prime.Send(buffer, SocketFlags.None);
//                    buffer = Encoding.Default.GetBytes(DBsSt);
//                    Prime.Send(buffer, SocketFlags.None);
//                }
//                //else if (Recieved.Contains("Survey Database Tables") && verified)
//                //{
//                //    List<Table> Temp = Server.DBS.Find(X=> X.Name==Recieved.Split(' ')[3]).Tables;

//                //    buffer = null;
//                //    string Response = "";

//                //    foreach (Table Tbl in Temp)
//                //    {
//                //        Response+=Tbl.Name+"~";
//                //    }

//                //    if (Temp.Count == 0)
//                //    {
//                //        Response += "~";
//                //    }

//                //    buffer = BitConverter.GetBytes(Response.Length);
//                //    Prime.Send(buffer, SocketFlags.None);
//                //    buffer = Encoding.Default.GetBytes(Response);
//                //    Prime.Send(buffer, SocketFlags.None);
//                //}

//                //else if (Recieved.Contains("Survey Table Keys") && verified)
//                //{
//                //    List<Key> Temp = Server.DBS.Find(X => X.Name == Recieved.Split(' ')[3].Split('.')[1]).Tables.Find(Y=>Y.Name==Recieved.Split(' ')[3].Split('.')[0]).Keys;

//                //    buffer = null;
//                //    string Response = "";

//                //    foreach (Key Kx in Temp)
//                //    {
//                //        Response += Kx.Name+Kx.Restrictions + "~";
//                //    }

//                //    if (Temp.Count == 0)
//                //    {
//                //        Response += "~";
//                //    }

//                //    buffer = BitConverter.GetBytes(Response.Length);
//                //    Prime.Send(buffer, SocketFlags.None);
//                //    buffer = Encoding.Default.GetBytes(Response);
//                //    Prime.Send(buffer, SocketFlags.None);
//                //}

//                //else if (Recieved.Contains("PassiveQuery") && verified)
//                //{
//                //    string[] RecievedSplit = Recieved.Split('~');
//                //    try
//                //    {
//                //        Query Q = new Query(RecievedSplit[1], RecievedSplit[2]);
//                //        Table T = Q.ExecuteScript();
//                //        T.Records = T.Keys[0].records.Count;
//                //        T.KeysCount = T.Keys.Count;
//                //        buffer = null;
//                //        string Response = "";
//                //        foreach (Key K in T.Keys)
//                //        {
//                //            Response += "%K%"+K.Name+"~";
//                //            foreach (string S in K.records)
//                //            {
//                //                Response += "%R%"+S + "~";
//                //            }
//                //            Response += "%EOK%~";
//                //        }
//                //        Response+=("%EOT%~");
//                //        buffer = null;
//                //        buffer = BitConverter.GetBytes(Response.Length);
//                //        Prime.Send(buffer,SocketFlags.None);
//                //        buffer = Encoding.Default.GetBytes(Response);
//                //        Prime.Send(buffer, SocketFlags.None);

//                //    }
//                //    catch
//                //    {
//                //        buffer = Encoding.Default.GetBytes("Error");
//                //        Prime.Send(buffer, SocketFlags.None);
//                //    }
//                //}
//                //else if (Recieved.Contains("ActiveScript") && verified)
//                //{
//                //    string[] RecievedSplit = Recieved.Split('~');
//                //    try
//                //    {
//                //        ActiveScript AS = new ActiveScript(RecievedSplit[1], RecievedSplit[2]);
//                //        buffer = Encoding.Default.GetBytes("Activescript Execution Completed");
//                //        Prime.Send(buffer, SocketFlags.None);
//                //        Parser.Suspend();
//                //        Parser.UpdateServerFile();
//                //        Parser.ReEstablish();

//                //    }
//                //    catch (Exception e)
//                //    {
//                //        buffer = Encoding.Default.GetBytes("Error : "+e.Message);
//                //        Prime.Send(buffer, SocketFlags.None);
//                //    }
//                //}

//                //else if (Recieved.Contains("ServerScript") && verified)
//                //{
//                //    if (Recieved.Contains("%Database%"))
//                //    {
//                //        string[] RecievedSplit = Recieved.Split('~');
//                //        try
//                //        {
//                //            Database DB = new Database();
//                //            DB.Name = RecievedSplit[3];
//                //            DB.TablesCount = 0;
//                //            Server.DBS.Add(DB);
//                //            Server.Databases++;
//                //        }
//                //        catch
//                //        {
//                //        }
//                //    }
//                //    else if (Recieved.Contains("%Password%"))
//                //    {
//                //        string[] RecievedSplit = Recieved.Split('~');
//                //        try
//                //        {   
//                //            Server.Password = RecievedSplit[2];
//                //        }
//                //        catch
//                //        {

//                //        }
//                //    }
//                //    Parser.Suspend();
//                //    Parser.UpdateServerFile();
//                //    Parser.ReEstablish();
//                //}

//                //else if (Recieved.Contains("Properties"))
//                //{
//                //    string Response = "";
//                //    string Type = Recieved.Split(' ')[1];
//                //    if (Type == "Server")
//                //    {
//                //        Response = "Server ID : " + Server.ServerName + "~" + "Databases Count : " + Server.Databases.ToString() + "~" + "Server File : " + Server.ServerFile;
//                //    }
//                //    else if (Type == "Database")
//                //    {
//                //        Database DB=Server.DBS.First(X=>X.Name==Recieved.Split(' ')[2]);
//                //        Response="Name : "+DB.Name+"~"+"#Tables : "+DB.TablesCount;
//                //    }
//                //    else if (Type == "Table")
//                //    {
//                //        Table T = Server.DBS.First(X => X.Name == Recieved.Split(' ')[3]).Tables.First(Y => Y.Name == Recieved.Split(' ')[2]);
//                //        Response = "Name : " + T.Name + "~" + "#Keys : " + T.KeysCount + "~" +"#Records : " + T.Records;
//                //    }
//                //    buffer = Encoding.Default.GetBytes(Response);
//                //    Prime.Send(buffer, SocketFlags.None);

//                //}
                
//            }
//        }
//    }
//}