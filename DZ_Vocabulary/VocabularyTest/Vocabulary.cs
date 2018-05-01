using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using My_Vocabulary;

namespace VocabularyTest
{
    [TestClass]
    public class Vocabulary
    {
        MyVocabulary vc = new MyVocabulary();
        /// <summary>
        /// return word if key present
        /// </summary>
        [TestMethod]
        public void VocabularyReturnTest()
        {
            Assert.AreEqual("яблоко", vc.ReturnValue("apple"));
            Assert.AreEqual("car", vc.ReturnValue("машина"));
            Assert.AreEqual("apple", vc.ReturnValue("яблоко"));
        }
        /// <summary>
        /// add key and word to vocabulary
        /// </summary>
        [TestMethod]
        
        public void VocabularyAddTest()
        {
            vc.Add("string","строка");
            vc.Add("мячь","ball");
            Assert.AreEqual("мячь", vc.ReturnValue("ball"));
            Assert.AreEqual("string", vc.ReturnValue("строка"));
            Assert.AreEqual("строка", vc.ReturnValue("string"));
            Assert.AreEqual("ball", vc.ReturnValue("мячь"));
        }


        /// <summary>
        /// open document with vocabulary
        /// </summary>
        [TestMethod]
        public void VocabularyOpenTest()
        {
        }
    }
}
