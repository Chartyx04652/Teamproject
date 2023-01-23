using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QrSystem1
{
    internal class Class1
    {
        
        public String encrypt(char[] password)
        {
            List<String>encryptedPassword = new List<String>();
            
            
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i].Equals('a'))
                {
                    encryptedPassword.Add("e");
                }
                else if (password[i].Equals('A'))
                {
                    encryptedPassword.Add("E");
                }
                else if (password[i].Equals('b'))
                {
                    encryptedPassword.Add("f");
                }
                else if (password[i].Equals('B'))
                {
                    encryptedPassword.Add("F");
                }
                else if (password[i].Equals('c'))
                {
                    encryptedPassword.Add("g");
                }
                else if (password[i].Equals('C'))
                {
                    encryptedPassword.Add("G");
                }
                else if (password[i].Equals('d'))
                {
                    encryptedPassword.Add("h");
                }
                else if (password[i].Equals('D'))
                {
                    encryptedPassword.Add("H");
                }
                else if (password[i].Equals('e'))
                {
                    encryptedPassword.Add("i");
                }
                else if (password[i].Equals('E'))
                {
                    encryptedPassword.Add("I");
                }
                else if (password[i].Equals('f'))
                {
                    encryptedPassword.Add("j");
                }
                else if (password[i].Equals('F'))
                {
                    encryptedPassword.Add("J");
                }
                else if (password[i].Equals('g'))
                {
                    encryptedPassword.Add("k");
                }
                else if (password[i].Equals('G'))
                {
                    encryptedPassword.Add("K");
                }
                else if (password[i].Equals('h'))
                {
                    encryptedPassword.Add("l");
                }
                else if (password[i].Equals('H'))
                {
                    encryptedPassword.Add("L");
                }
                else if (password[i].Equals('i'))
                {
                    encryptedPassword.Add("m");
                }
                else if (password[i].Equals('I'))
                {
                    encryptedPassword.Add("M");
                }
                else if (password[i].Equals('j'))
                {
                    encryptedPassword.Add("n");
                }
                else if (password[i].Equals('J'))
                {
                    encryptedPassword.Add("N");
                }
                else if (password[i].Equals('k'))
                {
                    encryptedPassword.Add("o");
                }
                else if (password[i].Equals('K'))
                {
                    encryptedPassword.Add("O");
                }
                else if (password[i].Equals('l'))
                {
                    encryptedPassword.Add("p");
                }
                else if (password[i].Equals('L'))
                {
                    encryptedPassword.Add("P");
                }
                else if (password[i].Equals('m'))
                {
                    encryptedPassword.Add("q");
                }
                else if (password[i].Equals('M'))
                {
                    encryptedPassword.Add("Q");
                }
                else if (password[i].Equals('n'))
                {
                    encryptedPassword.Add("r");
                }
                else if (password[i].Equals('N'))
                {
                    encryptedPassword.Add("R");
                }
                else if (password[i].Equals('o'))
                {
                    encryptedPassword.Add("s");
                }
                else if (password[i].Equals('O'))
                {
                    encryptedPassword.Add("S");
                }
                else if (password[i].Equals('p'))
                {
                    encryptedPassword.Add("t");
                }
                else if (password[i].Equals('P'))
                {
                    encryptedPassword.Add("T");
                }
                else if (password[i].Equals('q'))
                {
                    encryptedPassword.Add("u");
                }
                else if (password[i].Equals('Q'))
                {
                    encryptedPassword.Add("U");
                }
                else if (password[i].Equals('r'))
                {
                    encryptedPassword.Add("v");
                }
                else if (password[i].Equals('R'))
                {
                    encryptedPassword.Add("V");
                }
                else if (password[i].Equals('s'))
                {
                    encryptedPassword.Add("w");
                }
                else if (password[i].Equals('S'))
                {
                    encryptedPassword.Add("W");
                }
                else if (password[i].Equals('t'))
                {
                    encryptedPassword.Add("x");
                }
                else if (password[i].Equals('T'))
                {
                    encryptedPassword.Add("X");
                }
                else if (password[i].Equals('u'))
                {
                    encryptedPassword.Add("y");
                }
                else if (password[i].Equals('U'))
                {
                    encryptedPassword.Add("Y");
                }
                else if (password[i].Equals('v'))
                {
                    encryptedPassword.Add("z");
                }
                else if (password[i].Equals('V'))
                {
                    encryptedPassword.Add("Z");
                }
                else if (password[i].Equals('w'))
                {
                    encryptedPassword.Add("a");
                }
                else if (password[i].Equals('W'))
                {
                    encryptedPassword.Add("A");
                }
                else if (password[i].Equals('x'))
                {
                    encryptedPassword.Add("b");
                }
                else if (password[i].Equals('X'))
                {
                    encryptedPassword.Add("B");
                }
                else if (password[i].Equals('y'))
                {
                    encryptedPassword.Add("c");
                }
                else if (password[i].Equals('Y'))
                {
                    encryptedPassword.Add("C");
                }
                else if (password[i].Equals('z'))
                {
                    encryptedPassword.Add("d");
                }
                else if (password[i].Equals('Z'))
                {
                    encryptedPassword.Add("D");
                }
                else if (password[i].Equals('0'))
                {
                    encryptedPassword.Add("4");
                }
                else if (password[i].Equals('1'))
                {
                    encryptedPassword.Add("5");
                }
                else if (password[i].Equals('2'))
                {
                    encryptedPassword.Add("6");
                }
                else if (password[i].Equals('3'))
                {
                    encryptedPassword.Add("7");
                }
                else if (password[i].Equals('4'))
                {
                    encryptedPassword.Add("8");
                }
                else if (password[i].Equals('5'))
                {
                    encryptedPassword.Add("9");
                }
                else if (password[i].Equals('6'))
                {
                    encryptedPassword.Add("0");
                }
                else if (password[i].Equals('7'))
                {
                    encryptedPassword.Add("1");
                }
                else if (password[i].Equals('8'))
                {
                    encryptedPassword.Add("2");
                }
                else if (password[i].Equals('9'))
                {
                    encryptedPassword.Add("3");
                }
            }

            return String.Join("", encryptedPassword.ToArray());
        }
    }
}
