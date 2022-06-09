using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace protect_inf_LR1
{
    public partial class Form1 : Form
    {
        private const int SizeOfBlock = 128;
        private const int SizeOfChar = 16;

        private const int ShiftKey = 2;

        private const int QuantityOfRounds = 16;

        private string[] _blocks;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (textBoxEncodeKeyWord.Text.Length > 0)
            {
                var s = "";
                var key = textBoxEncodeKeyWord.Text;

                var sr = new StreamReader("in.txt");
                while (!sr.EndOfStream)
                {
                    s += sr.ReadLine();
                }

                sr.Close();

                s = StringToRightLength(s);
                CutStringIntoBlocks(s);

                key = CorrectKeyWord(key, s.Length / (2 * _blocks.Length));
                textBoxEncodeKeyWord.Text = key;
                key = StringToBinaryFormat(key);

                for (var j = 0; j < QuantityOfRounds; j++)
                {
                    for (var i = 0; i < _blocks.Length; i++)
                        _blocks[i] = EncodeDES_One_Round(_blocks[i], key);

                    key = KeyToNextRound(key);
                }

                key = KeyToPrevRound(key);
                
                textBoxDecodeKeyWord.Text = StringFromBinaryToNormalFormat(key);
                
                var result = _blocks.Aggregate("", (current, t) => current + t);

                var sw = new StreamWriter("out1.txt");
                sw.WriteLine(StringFromBinaryToNormalFormat(result));
                sw.Close();

                Process.Start("out1.txt");
            }
            else
                MessageBox.Show(@"Enter key word!");
        }

        private void buttonDecipher_Click(object sender, EventArgs e)
        {
            if (textBoxDecodeKeyWord.Text.Length > 0)
            {
                var s = "";

                var key = StringToBinaryFormat(textBoxDecodeKeyWord.Text);

                var sr = new StreamReader("out1.txt");

                while (!sr.EndOfStream)
                {
                    s += sr.ReadLine();
                }

                sr.Close();

                s = StringToBinaryFormat(s);

                CutBinaryStringIntoBlocks(s);

                for (var j = 0; j < QuantityOfRounds; j++)
                {
                    for (var i = 0; i < _blocks.Length; i++)
                        _blocks[i] = DecodeDES_One_Round(_blocks[i], key);

                    key = KeyToPrevRound(key);
                }

                key = KeyToNextRound(key);

                textBoxEncodeKeyWord.Text = StringFromBinaryToNormalFormat(key);

                var result = _blocks.Aggregate("", (current, t) => current + t);

                var sw = new StreamWriter("out2.txt");
                sw.WriteLine(StringFromBinaryToNormalFormat(result));
                sw.Close();

                Process.Start("out2.txt");
            }
            else
                MessageBox.Show(@"Enter key word!");
        }

        private static string StringToRightLength(string input)
        {
            while (((input.Length * SizeOfChar) % SizeOfBlock) != 0)
                input += "#";

            return input;
        }

        private void CutStringIntoBlocks(string input)
        {
            _blocks = new string[(input.Length * SizeOfChar) / SizeOfBlock];

            var lengthOfBlock = input.Length / _blocks.Length;

            for (var i = 0; i < _blocks.Length; i++)
            {
                _blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
                _blocks[i] = StringToBinaryFormat(_blocks[i]);
            }
        }

        private void CutBinaryStringIntoBlocks(string input)
        {
            _blocks = new string[input.Length / SizeOfBlock];

            var lengthOfBlock = input.Length / _blocks.Length;

            for (var i = 0; i < _blocks.Length; i++)
                _blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
        }

        private string StringToBinaryFormat(string input)
        {
            var output = "";

            for (var i = 0; i < input.Length; i++)
            {
                var charBinary = Convert.ToString(input[i], 2);

                while (charBinary.Length < SizeOfChar)
                    charBinary = "0" + charBinary;

                output += charBinary;
            }

            return output;
        }

        private static string CorrectKeyWord(string input, int lengthKey)
        {
            if (input.Length > lengthKey)
                input = input.Substring(0, lengthKey);
            else
                while (input.Length < lengthKey)
                    input = "0" + input;

            return input;
        }

        private string EncodeDES_One_Round(string input, string key)
        {
            var l = input.Substring(0, input.Length / 2);
            var r = input.Substring(input.Length / 2, input.Length / 2);

            return (r + Xor(l, F(r, key)));
        }

        private string DecodeDES_One_Round(string input, string key)
        {
            var l = input.Substring(0, input.Length / 2);
            var r = input.Substring(input.Length / 2, input.Length / 2);

            return (Xor(F(l, key), r) + l);
        }

        private static string Xor(string s1, string s2)
        {
            var result = "";

            for (var i = 0; i < s1.Length; i++)
            {
                var a = Convert.ToBoolean(Convert.ToInt32(s1[i].ToString()));
                var b = Convert.ToBoolean(Convert.ToInt32(s2[i].ToString()));

                if (a ^ b)
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }

        private static string F(string s1, string s2)
        {
            return Xor(s1, s2);
        }

        private static string KeyToNextRound(string key)
        {
            for (var i = 0; i < ShiftKey; i++)
            {
                key = key[key.Length - 1] + key;
                key = key.Remove(key.Length - 1);
            }
            return key;
        }

        private static string KeyToPrevRound(string key)
        {
            for (var i = 0; i < ShiftKey; i++)
            {
                key += key[0];
                key = key.Remove(0, 1);
            }

            return key;
        }

        private static string StringFromBinaryToNormalFormat(string input)
        {
            var output = "";

            while (input.Length > 0)
            {
                var charBinary = input.Substring(0, SizeOfChar);
                input = input.Remove(0, SizeOfChar);

                var degree = charBinary.Length - 1;

                var a = charBinary.Sum(c => Convert.ToInt32(c.ToString()) * (int) Math.Pow(2, degree--));

                output += ((char)a).ToString();
            }
            return output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
