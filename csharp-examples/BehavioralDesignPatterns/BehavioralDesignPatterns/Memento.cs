using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralDesignPatterns
{
    class EditorMemento
    {
        private string mContent;
        public EditorMemento(string content)
        {
            mContent = content;
        }
        public string Content
        {
            get { return mContent; }
        }
    }

    class Editor
    {
        private string mContent = string.Empty;
        private EditorMemento memento;
        public Editor()
        {
            memento = new EditorMemento(string.Empty);
        }
        public void Type(string words)
        {
            mContent = String.Concat(mContent," ",words);
        }
        public string Content
        {
            get { return mContent; }
        }
        public void Save()
        {
            memento= new EditorMemento(mContent);
        }
        public void Restore()
        {
            mContent = memento.Content;
        }
    }

    internal class Memento
    {
        public void Main()
        {
            var editor =  new Editor();

            //Type some Stuff
            editor.Type("This is First Testing Sentence.");
            editor.Type("This is Second Testing Sentence.");

            //Save the state to restore to : This is the first sentencr. This is second. 
            editor.Save();

            //Type Some more 
            editor.Type("This is Third Testing Sentence.");

            //Ouput the content
            Console.WriteLine(editor.Content);

            //Restoring the Last saved State
            editor.Restore();
            Console.WriteLine(editor.Content);//First and Second sentence
        }
    }
}
