using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 7. Write a program that encodes and decodes a string using given
 * encryption key (cipher). The key consists of a sequence of characters.
 * The encoding/decoding is done by performing XOR (exclusive or)
 * operation over the first letter of the string with the first of the key,
 * the second – with the second, etc. When the last key character is reached,
 * the next is the first.
 */
class EncodeString
{
    static string Encode(string text, string cipher)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            result[i] = (char)(text[i] ^ cipher[i % cipher.Length]);
        }
        return new string(result);
    }

    static void Main()
    {
        string text = "The quick brown fox jumps over the drunken software developer.";
        string cipher = "AndSoYouCode";

        string codedText = Encode(text, cipher);
        Console.WriteLine("The coded text is: {0}", codedText);

        text = Encode(codedText, cipher);
        Console.WriteLine("Original text is: {0}", text);
    }
}
