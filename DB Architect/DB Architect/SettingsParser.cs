using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace DB_Architect
{
    class SettingsParser
    {
        const string ConfigDir = "Architcet_Config.ini";
        const int SettingsCount = 4;
        FileStream _fs;

        public Dictionary<string, Point> Windows = new Dictionary<string, Point>();

        public SettingsParser()
        {
            _fs = new FileStream(ConfigDir, FileMode.Open);
            string Peek = "";
            while (true)
            {
                Peek = ParseLine();
                if (Peek == "[EndOfFile]")
                {
                    break;
                }
                else if (Peek == "[ApplicationWindows]")
                {
                    Peek = ParseLine();
                    while (Peek != "[EndOfApplicationWindows]")
                    {
                        string[] ParseA = Peek.Split('=');
                        string[] ParseB = ParseA[1].Split(',');

                        int x = int.Parse(ParseB[0]);
                        int y = int.Parse(ParseB[1]);

                        Windows.Add(ParseA[0], new Point(x, y));
                        Peek = ParseLine();
                    }
                }
                else if (Peek == "[ConnectionConfiguration]")
                {
                    Peek = ParseLine();
                    while (Peek != "[EndOfConnectionConfiguration]")
                    {
                        string[] ParseA = Peek.Split('=');
                        if (ParseA[0] == "Port")
                        {
                            Program.Port = int.Parse(ParseA[1]);
                        }
                        Peek = ParseLine();
                    }
                }
            }
            _fs.Close();
        }

        string ParseLine()
        {
            string X = "";

            while (!X.Contains('\n'))
            {
                X += (char)_fs.ReadByte();
            }
            X = X.Replace("\n", "").Replace("\r", "");
            return X;
        }

        ~SettingsParser()
        {
            _fs = new FileStream(ConfigDir, FileMode.Open);
            byte[] buffer;
            buffer = Encoding.Default.GetBytes("[ConnectionConfiguration]\r\nPort=" + Program.Port.ToString() + "\r\n");
            _fs.Write(buffer, 0, buffer.Length);
            buffer = Encoding.Default.GetBytes("[EndOfConnectionConfiguration]" + "\r\n");
            _fs.Write(buffer, 0, buffer.Length);
            buffer = Encoding.Default.GetBytes("[ApplicationWindows]\r\n");
            _fs.Write(buffer, 0, buffer.Length);

            foreach (KeyValuePair<string, Point> KVP in Windows)
            {
                buffer = Encoding.Default.GetBytes(KVP.Key + "=" + KVP.Value.X.ToString() + "," + KVP.Value.Y.ToString() + "\r\n");
                _fs.Write(buffer, 0, buffer.Length);
            }
            buffer = Encoding.Default.GetBytes("[EndOfApplicationWindows]" + "\r\n");
            _fs.Write(buffer, 0, buffer.Length);
            buffer = Encoding.Default.GetBytes("[EndOfFile]" + "\r\n");
            _fs.Write(buffer, 0, buffer.Length);
            _fs.Close();
        }
    }
}