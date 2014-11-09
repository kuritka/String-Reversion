using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringReversion.Test
{

    //Various cultures or charsets - no, it doesnt require test
    //As Async - no, because async is suitable for non-locking operations like I/O, service calls etc. This is blocking op.
    //
    [TestFixture]
    partial class UnitTest1
    {

        [Test]
        public void CorrectSentense()
        {
            Revert(Sentence).Should().Be(RevertedSentence);
        }

        [Test]
        public void CorrectSentenseWithEmptyString()
        {
            Revert(string.Empty).Should().Be(string.Empty);
        }

        [Test]
        public void CorrectSentenseWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => Revert(null));
        }

        [Test]
        public void CorrectSentenseWithSacesBehind()
        {    
            const string space = "       ";
            const string sentence = Sentence + space;
            Revert(sentence).Should().Be(space + RevertedSentence);
        }

        [Test]
        public void CorrectSentenseWithSacesAbove()
        {
            const string space = "       ";
            const string sentence = space + Sentence;
            Revert(sentence).Should().Be(RevertedSentence + space);
        }


        [Test]
        public void CorrectSentenseWithBigData()
        {
            var t = DateTime.Now;
            var longString = GetLongString("Hello");
            Revert(longString).Should().Be(longString);
            Console.WriteLine("{0:c} seconds", DateTime.Now - t); 
        }

        [Test]
        public void CorrectSentenseWithLinq()
        {
          RevertLinq(Sentence).Should().Be(RevertedSentence);
        }


        [Test]
        public void CorrectSentenseWithBigDataLinq()
        {
            var t = DateTime.Now;
            var longString = GetLongString("Hello");
            RevertLinq(longString).Should().Be(longString);
            Console.WriteLine("{0:c} seconds", DateTime.Now - t); 
        }


        [Test]
        public void CorrectSentenseWithEmptyStringLinq()
        {
            Revert(string.Empty).Should().Be(string.Empty);
        }

        [Test]
        public void CorrectSentenseWithNullLinq()
        {
            Assert.Throws<ArgumentNullException>(() => RevertLinq(null));
        }
    }
}
