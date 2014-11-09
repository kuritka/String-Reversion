using System;
using System.Collections;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace StringReversion.Test
{
    public partial class UnitTest1
    {

        private const string Sentence = "Life is short. Buy the shoes!";
        private const string RevertedSentence = "shoes! the Buy short. is Life";

        [TestFixtureSetUp]
        public void Init()
        {
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
        }


        private static string Revert(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            var stack = new Stack();
            var word = new StringBuilder();
            foreach (var c in s)
            {
                if (!char.IsWhiteSpace(c))
                {
                    word.Append(c);
                }
                else
                {
                    if (word.Length > 0)
                    {
                        stack.Push(word.ToString());
                        word.Clear();
                    }
                    stack.Push(c);
                }
            }
            if (!string.IsNullOrEmpty(word.ToString()))
            {
                stack.Push(word);
            }        
            return string.Concat(stack.ToArray());
        }





      
        private static string RevertLinq(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            var reversedSplit = s.Split(' ').Reverse();
            var stringBuilder = new StringBuilder(s.Length);
            var i = reversedSplit.Count();
            reversedSplit.ToList().ForEach(d =>
            {
                stringBuilder.Append(d);
                if(--i > 0)
                    stringBuilder.Append(' ');
            });
            return stringBuilder.ToString();
            
            //Cannot use aggregate, It doesnt internally use StringBuilder
            //and it is extremelly slow !! 
            //return 
            //    new Stack<string>(s.Split(' ')).ToArray().Aggregate( (x,y) => x + " " +y );
        }



        private string GetLongString(string value, int count = 5000000)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 1; i <= count; i++)
            {
                stringBuilder.Append(value);
                if (i < count)
                {
                    stringBuilder.Append(' ');
                }
            }
            return stringBuilder.ToString();
        }

    }
}
