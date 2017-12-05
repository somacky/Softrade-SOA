using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSoft.Template.Dominio.UsuarioDominio
{
    public sealed class CriptografiaDominio          
    {
        private const string Codes64 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";

        public static string DecodePWD(string aData, string aSecurityString)
        {
            string result = aData;
            string s1 = string.Empty;
            string s2 = string.Empty;
            string ss = string.Empty;

            int i = 0;
            int x = 0;
            int x2 = 0;

            if (aSecurityString.Length < 16)
                return result;

            for (i = 0; i < aSecurityString.Length; i++)
            {
                s1 = aSecurityString.Substring(i + 1);
                if (s1.IndexOf(aSecurityString[i]) > -1)
                    return result;
                if (Codes64.IndexOf(aSecurityString[i]) <= -1)
                    return result;
            }

            //s1 = Codes64;
            ss = aSecurityString;

            for (i = 0; i < aData.Length; i++)
            {
                if (ss.IndexOf(aData[i]) > -1)
                    s2 += aData[i];
            }

            aData = s2;
            s2 = string.Empty;

            if (aData.Length%2 != 0)
                return result;

            int k = 0;
            for (i = 0; i <= (aData.Length/2) - 1; i++)
            {
                k = i*2;

                x = ss.IndexOf(aData[k]);
                if (x < 0) return result;

                ss = ss.Substring(ss.Length - 1, 1) + ss.Substring(0, ss.Length - 1);

                x2 = ss.IndexOf(aData[k + 1]);
                if (x2 < 0) return result;

                x = x + x2*16;
                s2 = s2 + Convert.ToChar(x);
                ss = ss.Substring(ss.Length - 1, 1) + ss.Substring(0, ss.Length - 1);
            }

            return s2;
        }

        public static string EncodePWD(string aData, string aSecurityString)
        {
            string result = string.Empty;
            string s1 = string.Empty;
            string s2 = string.Empty;
            string ss = string.Empty;

            int i = 0;
            int x = 0;
            int minV = 0;
            int MaxV = 5;
            if (minV > MaxV)
            {
                i = minV;
                minV = MaxV;
                MaxV = i;
            }

            if (minV < 0)
                minV = 0;
            if (MaxV > 100)
                MaxV = 100;
            //Decodifica();
            result = string.Empty;

            if (aSecurityString.Length < 16)
                Console.WriteLine(result);

            for (i = 0; i < aSecurityString.Length; i++)
            {
                s1 = aSecurityString.Substring(i + 1);
                if (s1.IndexOf(aSecurityString[i]) > -1)
                    Console.WriteLine(result);
                if (Codes64.IndexOf(aSecurityString[i]) <= -1)
                    Console.WriteLine(result);
            }
            s1 = Codes64;
            s2 = "";

            for (i = 0; i < aSecurityString.Length; i++)
            {
                string sAux = s1;
                x = s1.IndexOf(aSecurityString[i]);
                if (x > -1)
                    s1 = s1.Substring(0, x) + s1.Substring(x + 1);
            }
            ss = aSecurityString;
            for (i = 0; i < aData.Length; i++)
            {
                s2 = s2 + ss[Convert.ToInt32(aData[i]) % 16]; //s2 := s2 + ss[Ord(Data[i]) mod 16 + 1];
                ss = ss.Substring(ss.Length - 1, 1) + ss.Substring(0, ss.Length - 1);  //ss := Copy(ss, Length(ss), 1) + Copy(ss, 1,Length(ss) - 1);    
                s2 = s2 + ss[Convert.ToInt32(aData[i]) / 16];//s2 := s2 + ss[Ord(Data[i]) div 16 + 1];
                ss = ss.Substring(ss.Length - 1, 1) + ss.Substring(0, ss.Length - 1);  //ss := Copy(ss, Length(ss), 1) + Copy(ss, 1,Length(ss) - 1);    
            }
            DelphiRandom ran = new DelphiRandom(1);
            DelphiRandom ran2 = new DelphiRandom(1);
            int aux = ran.Next(MaxV - minV) + minV + 1;
            result = MakeRNDString(s1, aux);
            for (i = 0; i < s2.Length; i++)
                result = result + s2[i] + MakeRNDString(s1, ran.Next(MaxV - minV) + minV);
            return result;
        }
        static string MakeRNDString(string chars, int count)
        {
            int i, x;
            string Result = string.Empty;
            DelphiRandom ran = new DelphiRandom(1);
            for (i = 0; i < count; i++)
            {
                int d = ran.Next(chars.Length);
                x = (chars.Length - d);
                Result = Result + chars[x - 1];
                chars = chars.Substring(0, x - 1) + chars.Substring(x);
            }

            return Result;
        }
    }
         class DelphiRandom
    {
        int _seed;

        public DelphiRandom(int seed)
        {
            _seed = seed;
        }

        int GetNext() // note: returns negative numbers too
        {
            _seed = _seed * 0x08088405 + 1;
            return _seed;
        }

        public int Next(int maxValue)
        {
            ulong result = (ulong)(uint)GetNext() * (ulong)(uint)maxValue;
            return (int)(result >> 32);
        }
    }
}
